using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventoryTracker.Models.Item;

namespace InventoryTracker.Models
{
    public class Inventory
    {
       private List<Item> items;
       public Inventory()
       {
            items = new List<Item>();
       }

       public void AddItem(Item item)
       {
            items.Add(item);
       }
        public List<Item> GetItems()
        {
            return items;
        }
        public void RemoveItem(string itemname)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (itemname == items[i].Name)
                {
                    items.Remove(items[i]);
                }
            }
        }
        
        public void UpdateItem(string name, int availeble, int minimum, string location, string supplier, CategoryType category)
        {
            foreach (Item i in items)
            {
                if (i.Name == name)
                {
                    i.AvailebleQuantity = availeble;
                    i.MinimumQuantity = minimum;
                    i.Location = location;
                    i.Supplier = supplier;
                    i.Category = category;  
                }
            }
        }
       
        public List<Item> GerneralReport()
        {
            return items;
        }
        public List<Item> ShoppingList()
        {
            List<Item> shoppingList = new List<Item>();
            foreach (Item i in items)
            {
                if (i.AvailebleQuantity < i.MinimumQuantity)
                {
                    shoppingList.Add(i);
                }
            }
            return shoppingList;
        }
        
    //A method to load items from a file(s)}

        public void LoadItems(string fileName)
        {
            string[] allRecords = File.ReadAllLines(fileName);
            foreach (string record in allRecords)
            {
                //Create an empty item
                Item item = new Item();
                //set the CSV property
                item.CSVData = record;
                //add to list
                items.Add(item);
            }
        }
        public void SaveItems(string saveLocation)
        {
            StringBuilder records = new StringBuilder();
            //loop over all elements in the list and save them to a file
            for (int i = 0; i < items.Count; i++)
            {
                records.AppendLine(items[i].CSVData);
                //MessageBox.Show(inventory.GetItems()[i].CSVData);
            }
            File.WriteAllText(saveLocation, records.ToString());
        }
    }

}
