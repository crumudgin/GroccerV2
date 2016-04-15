using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerServer
{
    class Program
    {
        static void Main(string[] args)
        {
            FoodItemDatabase fdb = new FoodItemDatabase("groccer");
            string[] tags = { "cat", "barbaque chips" };
            FoodItem f = new FoodItem("testItem", 10.50, tags, "wegmans", 0, "test");
            fdb.enterFoodTag(0, 0);
            //fdb.enterTag("cat");
            //fdb.enterFoodItem(f);
            Console.ReadKey();


        }
    }
}
