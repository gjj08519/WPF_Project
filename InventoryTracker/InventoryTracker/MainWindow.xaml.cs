using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

using Microsoft.Win32;

namespace InventoryTracker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Inventory inventory = new Inventory();


        //Data fields for saving
        private bool isNewDocument = true; //used to check if the file is new and never saved.
        private bool NewChange = false;//used to check if there are new changes.

        private string saveLocation; //once saved, keep the location for future saves

        public MainWindow()
        {
            InitializeComponent();
            lbItem.ItemsSource = inventory.GetItems();//for listbox
        }

        private void MainbtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddItems addItemsWindow = new AddItems(inventory);
            bool? success = addItemsWindow.ShowDialog();
            if (success == true)
            {
                bool addSameItem = false;//check if the same item to be added
                // lbItem.Items.Add(addItemsWindow.itemAdd);
                for (int i = 0; i < inventory.GetItems().Count; i++)
                {
                    if (addItemsWindow.itemAdd.Name == inventory.GetItems()[i].Name)
                    {
                        addSameItem = true;
                        MessageBox.Show("Cannot add a item that's already exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                if (!addSameItem)
                {
                    inventory.GetItems().Add(addItemsWindow.itemAdd);
                    lbItem.Items.Refresh();
                    NewChange = true;//item added
                }
            }
        }

        private void MainbtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateItems updateItemsWindow = new UpdateItems(inventory);
            bool? success= updateItemsWindow.ShowDialog();
            if (success==true)
            {
                this.inventory = updateItemsWindow.GetInventory();
                lbItem.Items.Refresh();
                NewChange = true;//update or remove change
            }
            
        }
        private void MainbtnReport_Click(object sender, RoutedEventArgs e)
        {
           
                GeneralReport reportWindow = new GeneralReport(inventory);
                reportWindow.ShowDialog();
            
        }

        private void MainbtnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if (isNewDocument)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV File|*.csv";
                if (saveFileDialog.ShowDialog() == true)
                {
                    MessageBox.Show(saveFileDialog.FileName);
                    saveLocation = saveFileDialog.FileName;
                    isNewDocument = false;
                }
                else
                    return;
            }
            SaveDataToFile();
        }

        //Method that writes any new data records to the file
        private void SaveDataToFile()
        {
            try
            {
                inventory.SaveItems(saveLocation);
                
                NewChange = false;
                txtStatusBar.Text = "Status: Records saved to " + saveLocation;
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot save: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void MainbtnLoad_Click(object sender, RoutedEventArgs e)
        {
            // Check before opening a new file that the current file is saved.
            if (CheckToLoadExit())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV Files|*.csv";

                if (openFileDialog.ShowDialog() == true)
                {
                    inventory.GetItems().Clear(); //Clear any current data
                    //Read from the CSV file
                    saveLocation = openFileDialog.FileName;
                    inventory.LoadItems(saveLocation);
                    lbItem.Items.Refresh();//Refresh UI

                    //Logic related to saving variables
                    isNewDocument = false;

                    //Status bar update
                    txtStatusBar.Text = "Status: File loaded from: " + saveLocation;


                }
            }
        }
        private bool CheckToLoadExit()
        {
            if (NewChange)
            {
                //Data the is not saved,warning msg
                MessageBoxResult result = MessageBox.Show("Data not saved.\nDo you want to save changes?", "Save Data Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                
                if (result == MessageBoxResult.Cancel)
                    return false;//Cancel,return false

               
                if (result == MessageBoxResult.No)
                    return true; //No, return true

                //Yes
                if (result == MessageBoxResult.Yes)
                    Save(); //Data is saved: true will be return outside
                if (NewChange)
                    return false; //Yes but Data is still not saved after asking to save)
            }
            return true; //Data is saved
        }

        private void Mainshoppinglist_Click(object sender, RoutedEventArgs e)
        {
            
                ShoppingList shoppingListWindow = new ShoppingList(inventory);
                shoppingListWindow.ShowDialog();
          
        }

        //Double click selected item,you can update or remove it
        private void LbItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item i = lbItem.SelectedItem as Item;//select item
            UpdateItems updateItemsWindow = new UpdateItems(inventory);

            updateItemsWindow.cmbItems.Text = i.Name;//selected item's name

            updateItemsWindow.ShowDialog();
             this.inventory = updateItemsWindow.GetInventory();//update MainWindow inventory after change

            lbItem.Items.Refresh();//Refresh UI
            NewChange = true;

        }
        
        //for right-click and copy
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Item i = lbItem.SelectedItem as Item;

            if (i != null)
                Clipboard.SetText(i.FullInfo);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (NewChange)
            {
                MessageBoxResult result = MessageBox.Show("Data not saved.\nDo you want to save changes?", "Save Data Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Cancel)
                    e.Cancel = true;
                if (result == MessageBoxResult.No)
                    e.Cancel = false;
                if (result == MessageBoxResult.Yes)
                {
                    Save();
                    e.Cancel = false;
                }
            }
            else
            {
                e.Cancel = false;
            }

        }

        //Convenient buttons to add Availeble Quantity
        private void AQ_add_Click(object sender, RoutedEventArgs e)
        {
            Item i = lbItem.SelectedItem as Item;
            if (i != null)
                i.AvailebleQuantity++;
            lbItem.Items.Refresh();
            NewChange = true;
        }
        //Convenient buttons to reduce Availeble Quantity
        private void AQ_minus_Click(object sender, RoutedEventArgs e)
        {
            Item i = lbItem.SelectedItem as Item;
            if (i.AvailebleQuantity > 0)
            {
                i.AvailebleQuantity--;
            }
            else
            {
                i.AvailebleQuantity = 0;
            }
            
            lbItem.Items.Refresh();
            NewChange = true;
        }
    } 
}


