using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace GrocerServer
{
    class FoodItemDatabase
    {
        private SQLiteConnection m_dbConnection;
        public FoodItemDatabase(string db)
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + db + ";Version=3;");
            m_dbConnection.Open();
            string FoodItemSql = "CREATE TABLE FoodItems (id INTEGER PRIMARY KEY, name TEXT NOT NULL, price FLOAT NOT NULL, location TEXT NOT NULL, description TEXT)";
            string TagSql = "CREATE TABLE Tags (TagID PRIMARY KEY, tag TEXT NOT NULL)";
            string ItemTagSql = "CREATE TABLE ItemTags (itemID INT NOT NULL, tagID INT NOT NULL)";
            SQLiteCommand command1 = new SQLiteCommand(FoodItemSql, m_dbConnection);
            SQLiteCommand command2 = new SQLiteCommand(TagSql, m_dbConnection);
            SQLiteCommand command3 = new SQLiteCommand(ItemTagSql, m_dbConnection);
            try
            {
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
        }


        public void enterFoodItem(FoodItem f)
        {
            string sql = "INSERT INTO FoodItems (name, price, location, description) VALUES ('"+f.Name+"',"+ f.Price.ToString()+", '"+f.Location+"', '"+f.Description+"')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public void enterTag(string tag)
        {
            string sql = "INSERT INTO Tags (tag) VALUES ('"+tag+ "')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public void enterFoodTag(int foodId, int tagId)
        {
            string sql = "INSERT INTO ItemTags (itemID, tagID) VALUES (" + foodId + ", '" + tagId + "')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        
    }
}
