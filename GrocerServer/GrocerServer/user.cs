using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerServer
{
    class User
    {
        private int id;
        private Dictionary<string, List<FoodItem>> shoppingLists;

        public User(int id, Dictionary<string, List<FoodItem>> shoppingLists)
        {
            this.id = id;
            this.shoppingLists = shoppingLists;
        }
    }
}
