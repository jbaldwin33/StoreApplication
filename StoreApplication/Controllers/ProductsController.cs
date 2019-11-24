using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  public class ProductsController : Controller
  {
    private ProductCatalogModelSingleton catalogModel = ProductCatalogModelSingleton.Instance;
    private CartModelSingleton cartModelInstance = CartModelSingleton.Instance;

    public ActionResult AddToCart(string name)
    {
      try
      {
        // TODO: Add to cart logic here
        cartModelInstance.CartItems.Add(catalogModel.GetProductByName(name));
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: Products
    public ActionResult Index()
    {
      return View();
    }
  }
}