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
using System.Windows.Shapes;
using static InventoryTracker.Models.Item;

namespace InventoryTracker
{
    /// <summary>
    /// UpdateItems.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateItems : Window
    {
        private Inventory inventory;
               
        public UpdateItems(Inventory inventory)
        {
            InitializeComponent();
            this.inventory = inventory;
            cmbItems.ItemsSource = inventory.GetItems();
            cmbItems.DisplayMemberPath = nameof(Item.Name);
        }
        public Inventory GetInventory()
        {
            return inventory;
        }
        private void BtnUpdateSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (CheckUserInput())
            {
                inventory.UpdateItem(cmbItems.Text, int.Parse(QuantityUpdate.Text), int.Parse(MinQuantityUpdate.Text), LocationUpdate.Text, supplierUpdate.Text, (CategoryType)Enum.Parse(typeof(CategoryType), categoryUpdate.Text));
                ClearForm();
                DialogResult = true;//update and after closed automatically
            }
            else
            {
                DialogResult = false;//just open the UpdateItems window and close
            }
        }
        private void ClearForm()
        {
            cmbItems.SelectedIndex = -1;
            QuantityUpdate.Text = string.Empty;
            MinQuantityUpdate.Text = string.Empty;
            LocationUpdate.Text = string.Empty;
            supplierUpdate.Text = string.Empty;
            categoryUpdate.Text = string.Empty;
        }
        private bool CheckUserInput()
        {
            //make sure Quantity and MinQuantity can be number
            bool Ifnumber = int.TryParse(QuantityUpdate.Text, out int Test);
            bool Ifnumber1 = int.TryParse(MinQuantityUpdate.Text, out int Test1);

            StringBuilder msg = new StringBuilder();

            if (cmbItems.SelectedIndex == -1)
                msg.AppendLine("A item was not selected.");
                        
            if (string.IsNullOrEmpty(QuantityUpdate.Text) && !Ifnumber)
                msg.AppendLine("Please provide a valid available quantity number!");

            if (string.IsNullOrEmpty(MinQuantityUpdate.Text) && !Ifnumber1)
                msg.AppendLine("Please provide a valid minimim quantity number!");

            if (string.IsNullOrEmpty(LocationUpdate.Text))
                msg.AppendLine("Location is a required field.");
            if (string.IsNullOrEmpty(supplierUpdate.Text))
                msg.AppendLine("Supplier is a required field.");
            if (string.IsNullOrEmpty(categoryUpdate.Text))
                msg.AppendLine("Category is a required field.");

            //Display a msg
            if (string.IsNullOrEmpty(msg.ToString()) && Ifnumber && Ifnumber1)
                return true;

            MessageBox.Show(msg.ToString(), "Form missing data", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        private void CmbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item I = cmbItems.SelectedItem as Item;
            this.DataContext = I;
        }

        private void BtnRemoveSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to remove this item ?", "Remove item Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                inventory.RemoveItem(cmbItems.Text);
              
                ClearForm();
               
                DialogResult = true;//remove and after closed automatically
            }
        }
    }
}
