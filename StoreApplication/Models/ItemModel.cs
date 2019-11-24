using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
  public class ItemModel
  {
    private Guid itemID;
    private string productName;
    private double productPrice;

    public ItemModel(Guid id, string name, double price)
    {
      ItemID = id;
      ProductName = name;
      ProductPrice = price;
    }

    public Guid ItemID
    {
      get { return itemID; }
      set { itemID = value; }
    }

    public string ProductName
    {
      get { return productName; }
      set { productName = value; }
    }

    public double ProductPrice
    {
      get { return productPrice; }
      set { productPrice = value; }
    }
  }
}
