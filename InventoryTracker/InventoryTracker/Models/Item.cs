using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Models
{
    public class Item
    {
        //Add data field
        private string name;
        private int availablequantity;
        private int minimumquantity;
        private string location;
        private string supplier;
        private CategoryType category;
        public Item()
        {

        }
        public Item(string name_, int availablequantity_, int minimumquantity_, string location_, string supplier_, CategoryType category_)
        {
            name = name_;
            availablequantity = availablequantity_;
            minimumquantity = minimumquantity_;
            location = location_;
            supplier = supplier_;
            category = category_;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int AvailebleQuantity
        {
            get
            {
                return availablequantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Available quantity can't be less than 0");
                }
                else
                {
                    availablequantity = value;
                }
            }
        }
        public int MinimumQuantity
        {
            get
            {
                return minimumquantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Minimum quantity can't be less than 0");
                }
                else
                {
                    minimumquantity = value;
                }

            }
        }
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }
        public string Supplier
        {
            get
            {
                return supplier;
            }
            set
            {
                supplier = value;
            }
        }
        public CategoryType Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }
        //use for copy
        public string FullInfo
        {
            get
            {
                return string.Format(
                "{0,-20}" + Name + "\n" +
                "{1,-21}" + AvailebleQuantity + "\n" +
                "{2,-20}" + MinimumQuantity + "\n" +
                "{3,-21}" + Location + "\n" +
                "{4,-20}" + Supplier + "\n" +
                "{5,-20}" + Category,
                "Name:", "Availeble Quantity:", "Minimum Quantity:", "Location:", "Supplier:", "Category:");
            }
        }
        public string CSVData
        {
            get { return string.Format($"{Name},{AvailebleQuantity},{MinimumQuantity},{Location},{Supplier},{Category}"); }
            set
            {
                try
                {
                    //will get a record, comma separated and split it and save the value is this object
                   
                    string[] data = value.Split(',');
                    Name = data[0];
                    AvailebleQuantity =int.Parse(data[1]);
                    MinimumQuantity = int.Parse(data[2]);
                    Location = data[3];
                    Supplier = data[4];
                    Category = (CategoryType)Enum.Parse(typeof(CategoryType), data[5]);
                }
                catch (Exception)
                {
                    throw new ArgumentException("CSV Data property not valid input", "CVSData");
                }
            }
        }
        public enum CategoryType
        {
            Pantry,
            Dairy,
            Drinks,
            FrozenFood,
            Fruit,
            Vegetable,
            Bakery,
            CleaningSupplies,
            Others
        }
    }
}
