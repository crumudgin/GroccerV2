package Groccer;

import java.util.ArrayList;
import java.sql.*;

/**
 * Created by zac on 2/27/16.
 */
public class FoodItem
{
    private String name;
    private double price;
    private ArrayList<String> tags;
    private String description;

    public FoodItem(String name, double price, ArrayList<String> tags, String description)
    {
        this.name = name;
        this.price = price;
        this.tags = tags;
        this.description = description;
    }

    public String getName()
    {
        return name;
    }

    public double getPrice()
    {
        return price;
    }

    public ArrayList<String> getTags()
    {
        return tags;
    }

    public String getDescription()
    {
        return description;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public void setPrice(double price)
    {
        this.price = price;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }

    public void addTag(String tag)
    {
        tags.add(tag);
    }

    public void addToDB()
    {

    }


}

