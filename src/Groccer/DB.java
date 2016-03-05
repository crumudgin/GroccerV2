package Groccer;

import java.sql.*;

/**
 * Created by zac on 2/27/16.
 */
public class DB
{
    String dbName;
    Connection c;

    public DB(String name)
    {
        dbName = name;
    }

    public void createDB()
    {
        try
        {
            Class.forName("org.sqlite.JDBC");
            c = DriverManager.getConnection("jdbc:sqlite:"+dbName);
            c.setAutoCommit(false);
        } catch ( Exception e ) {
            System.err.println( "1"+e.getClass().getName() + ": " + e.getMessage() );
            System.exit(0);
        }
    }

    public void addItem(String table, String[] valueNames, String[] values)
    {
        String nameString ="";
        String valueString="";
        for (int i = 0; i < valueNames.length; i++)
        {
            nameString += valueNames[i];
            if(i != valueNames.length -1)
            {
                nameString += ",";
            }
        }
        for (int i = 0; i < values.length; i++)
        {
            valueString += values[i];
            if(i != values.length -1)
            {
                valueString += ",";
            }
        }
        try
        {
            Statement stmt = c.createStatement();
            String sql = "INSERT INTO "+table+" ("+nameString+") VALUES ("+valueString+");";
            stmt.executeUpdate(sql);
            stmt.close();
        }
        catch (Exception e)
        {
            System.err.println( "2"+e.getClass().getName() + ": " + e.getMessage() );
            System.exit(0);
        }
    }

    public void addTable(String table)
    {
        try
        {
            Statement stmt = c.createStatement();
            String sql = table;
            stmt.executeUpdate(sql);
            stmt.close();
        }
        catch (Exception e)
        {
            System.err.println( "3"+e.getClass().getName() + ": " + e.getMessage() );
            System.exit(0);
        }
    }

    public void addTable(String tableName, String[] tableItems)
    {
        String contents = " ";
        for (int i = 0; i < tableItems.length; i++)
        {
            contents += tableItems[i];
            if(i != tableItems.length - 1)
            {
                contents += ",";
            }
        }
        addTable("CREATE TABLE "+tableName +" ("+ contents+")");
    }

    public ResultSet selectTable(String table)
    {
        try
        {
            Statement stmt = c.createStatement();
            return stmt.executeQuery("SELECT * FROM " + table +";");
        }
        catch (Exception e)
        {
            System.err.println( e.getClass().getName() + ": " + e.getMessage() );
            System.exit(0);
        }
        return null;
    }

    public void deleteItem(String tableName, String identifier, String item)
    {
        try
        {
            Statement stmt = c.createStatement();
            stmt.executeUpdate("Delete from "+ tableName + " where "+ identifier + "=" + item +";");
            stmt.close();
        }
        catch (Exception e)
        {
            System.err.println( e.getClass().getName() + ": " + e.getMessage() );
            System.exit(0);
        }
    }

    public void deleteTable(String tableName)
    {
        try
        {
            Statement stmt = c.createStatement();
            stmt.executeUpdate("DROP TABLE "+tableName +";");
            stmt.close();
        }
        catch (Exception e)
        {
            System.err.println( e.getClass().getName() + ": " + e.getMessage() );
            System.exit(0);
        }
    }

    public void initDB()
    {
        createDB();
        String[] table = {"ID INTEGER PRIMARY KEY AUTOINCREMENT",
                      "Name VARCHAR(100) NOT NULL",
                      "Price FLOAT(2) NOT NULL",
                      "Description VARCHAR(1000)"};
        String[] valueNames = {"Name","Price","Description"};
        String[] values = {"'food'","10.00","'foooooood'"};
//        addTable("FoodItems", table);
//        addItem("FoodItems", valueNames, values);
        try
        {
            c.commit();
            c.close();
        }
        catch (Exception e)
        {
            System.err.println( e.getClass().getName() + ": " + e.getMessage() );
            System.exit(0);
        }

    }



    public static void main(String args[])
    {
        DB d = new DB("Groccer");
        d.initDB();
//        try
//        {
//            d.c.commit();
//            d.c.close();
//        }
//        catch (Exception e)
//        {
//            System.err.println( e.getClass().getName() + ": " + e.getMessage() );
//            System.exit(0);
//        }
    }
}
