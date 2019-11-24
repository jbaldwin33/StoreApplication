using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
  public sealed class CartModelSingleton
  {
    private static CartModelSingleton instance = null;
    private static readonly object cartLock = new object();

    private List<ItemModel> cartItems = new List<ItemModel>();
    private Dictionary<string, int> itemCountPairs = new Dictionary<string, int>();

    CartModelSingleton()
    {
    }

    public static CartModelSingleton Instance
    {
      get
      {
        lock (cartLock)
        {
          if (instance == null)
            instance = new CartModelSingleton();
          return instance;
        }
      }
    }

    public List<ItemModel> CartItems
    {
      get { return cartItems; }
      set { cartItems = value; }
    }

    public Dictionary<string, int> ItemCountPairs
    {
      get { return itemCountPairs; }
      set { itemCountPairs = value; }
    }

    public void UpdateCount()
    {
      foreach (var item in CartItems)
      {
        var count = CartItems.Select(x => x).Where(x => x.ProductName == item.ProductName).Count();

        if (itemCountPairs.ContainsKey(item.ProductName))
          itemCountPairs[item.ProductName] = count;
        else
          itemCountPairs.Add(item.ProductName, 1);
      }
    }
  }
}
