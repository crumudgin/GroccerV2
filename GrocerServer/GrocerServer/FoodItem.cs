using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerServer
{
    class FoodItem
    {
        private string name;
        private double price;
        private string description;
        private string[] tags;
        private string location;
        private int id;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        } 

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string[] Tags
        {
            get { return tags; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public FoodItem(string name, double price, string[] tags, string location, int id, string description = null)
        {
            this.name = name;
            this.price = price;
            this.location = location;
            this.tags = tags;
            this.description = description;
            this.id = id;
        }

    }
}
