using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
  public sealed class ProductCatalogModelSingleton
  {
    private static ProductCatalogModelSingleton instance = null;
    private static readonly object catalogLock = new object();
    private List<ItemModel> products = new List<ItemModel>
    {
      new ItemModel(Guid.NewGuid(), "Elderberry syrup", 15.00),
      new ItemModel(Guid.NewGuid(), "Item #2", 10.00),
      new ItemModel(Guid.NewGuid(), "Item #3", 5.00),
      new ItemModel(Guid.NewGuid(), "Item #4", 10.00)
    };

    ProductCatalogModelSingleton()
    {
    }

    public static ProductCatalogModelSingleton Instance
    {
      get
      {
        lock (catalogLock)
        {
          if (instance == null)
            instance = new ProductCatalogModelSingleton();
          return instance;
        }
      }
    }

    public List<ItemModel> Products
    {
      get { return products; }
      set { products = value; }
    }

    public ItemModel GetProductByID(Guid id)
    {
      return Products.First(x => x.ItemID == id);
    }

    public ItemModel GetProductByName(string name)
    {
      return Products.First(x => x.ProductName == name);
    }

    public ItemModel GetProductByPrice(double price)
    {
      return Products.First(x => x.ProductPrice== price);
    }
  }
}
