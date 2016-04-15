using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace GrocerServer
{
    class DatabaseTools
    {

        private SQLiteConnection m_dbConnection;



        public void create(string dbName)
        {
            SQLiteConnection.CreateFile(dbName);
        }

        public void connect(string dbName)
        {
            m_dbConnection = new SQLiteConnection("Data Source="+dbName+";Version=3;");
            m_dbConnection.Open();
        }

        public void createTable(string tableName, string[] tablePeramiters)
        {
            string peramiters = "";
            for(int i = 0; i < tablePeramiters.Count(); i++)
            {
                peramiters += tablePeramiters[i];
                if(i < tablePeramiters.Count() - 1)
                {
                    peramiters += ", ";
                }
            }
            string sql = "CREATE TABLE " + tableName + " (" + peramiters + ")";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //create("Groccer.sqlite");
                //createTable(tableName, tablePeramiters);
            }

        }
        
        public void insertIntoTable(string tableName, string[] peramiters, string[] values)
        {
            string peramitersString = "";
            string valuesString = "";
            for (int i = 0; i < peramiters.Count(); i++)
            {
                peramitersString += peramiters[i];
                if (i < peramiters.Count() - 1)
                {
                    peramitersString += ", ";
                }
            }

            for (int i = 0; i < values.Count(); i++)
            {

                valuesString += values[i];
                
                if (i < values.Count() - 1)
                {
                    valuesString += ", ";
                }
            }
            string sql = "INSERT INTO " + tableName + " (" + peramitersString + ") VALUES (" + valuesString + ")";
            //string sql = "INSERT INTO Tags (tag) VALUES (chunky)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }


        public SQLiteDataReader selectFromTable(string tableName, string conditions = "1=1", string Select = "*")
        {
            string sql;
            sql = "SELECT " + Select + " FROM " + tableName + " WHERE " + conditions;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    Console.WriteLine(reader["name"]);
                }
                catch(Exception)
                {
                    
                }
                
            }
            return reader;
        }

        public void deleteFromTable(string tableName, string conditions)
        {
            string sql = "DELETE FROM " + tableName + " WHERE " + conditions; // probably shouldn't use
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }


    }
}
