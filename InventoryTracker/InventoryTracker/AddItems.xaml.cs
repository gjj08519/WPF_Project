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
    
    /// AddItems.xaml 的交互逻辑
    /// </summary>
    public partial class AddItems : Window
    {
        private Inventory inventory;
        public Item itemAdd;
        private string[] listofSupplier = { "Costco", "Walmart", "ABC", "Other" };
        private string[] listofCategory = {
            "Pantry",
            "Dairy",
            "Drinks",
            "FrozenFood",
            "Fruit",
            "Vegetable",
            "Bakery",
            "CleaningSupplies",
            "Others"};
            
        /// <summary>
        public AddItems(Inventory inventory)
        {
            InitializeComponent();
            this.inventory = inventory;
            cmbSupplier.ItemsSource = listofSupplier;
            cmbCategory.ItemsSource = listofCategory;
        }
        private Item GetItemObject()
        {
            //create an object using object-initialization syntax
            return new Item()
            {
                Name = ItemName.Text,
                AvailebleQuantity = int.Parse(Quantity.Text),
                MinimumQuantity = int.Parse(MinQuantity.Text),
                Location = Location.Text,
                Supplier = cmbSupplier.SelectedValue.ToString(),
               // Category = cmbCategory.SelectedValue.ToString(),
                Category = (CategoryType)Enum.Parse(typeof(CategoryType), cmbCategory.SelectedValue.ToString())
           
        };   
        }

        private void ClearForm()
        {
            ItemName.Text = string.Empty;
            Quantity.Text = string.Empty;
            Location.Text = string.Empty;
            MinQuantity.Text = string.Empty;
            cmbSupplier.SelectedIndex  = -1;
            cmbCategory.SelectedIndex = -1;
            
        }
        private bool CheckUserInput()
        {
            
            bool Ifnumber = int.TryParse(Quantity.Text, out int Test);
            bool Ifnumber1 = int.TryParse(MinQuantity.Text, out int Test1);

            StringBuilder msg = new StringBuilder();
            
            if (string.IsNullOrEmpty(ItemName.Text))
                msg.AppendLine("Name is a required field.");
                        
            if (string.IsNullOrEmpty(Quantity.Text)&& !Ifnumber)
                msg.AppendLine("Please provide a valid available quantity number!");
                        
            if (string.IsNullOrEmpty(MinQuantity.Text)&& !Ifnumber1)
                msg.AppendLine("Please provide a valid minimim quantity number!");

            if (string.IsNullOrEmpty(Location.Text))
                msg.AppendLine("Location is a required field.");

            if (cmbSupplier.SelectedIndex == -1)
                msg.AppendLine("A supplier was not selected.");
            if (cmbCategory.SelectedIndex == -1)
                msg.AppendLine("A category was not selected.");
            

            //Display a msg
            if (string.IsNullOrEmpty(msg.ToString()) && Ifnumber && Ifnumber1)
                return true;

            MessageBox.Show(msg.ToString(), "Form missing data", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        private void BtnAddSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (CheckUserInput())
            {

                itemAdd = GetItemObject();
                ClearForm();
                DialogResult = true;//add item success and close
            }
        }
    }
}
