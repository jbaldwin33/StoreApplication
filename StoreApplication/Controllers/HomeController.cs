﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApplication.Models;

namespace StoreApplication.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private ProductCatalogModelSingleton catalogModelInstance = ProductCatalogModelSingleton.Instance;
    private CartModelSingleton cartModelInstance = CartModelSingleton.Instance;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Products()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    public IActionResult Contact()
    {
      return View();
    }

    public IActionResult Cart()
    {
      return View();
    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
      //Label1.Text = "You clicked the first button.";
    }

    public void AddToCart(object sender, EventArgs e)
    {
      try
      {
        //cartModelInstance.CartItems.Add(catalogModelInstance.GetProductByName(name));
        //return RedirectToAction(nameof(Products));
      }
      catch
      {
        //return View();
      }
    }

    public IActionResult RemoveFromCart(string name)
    {
      try
      {
        cartModelInstance.CartItems.Remove(catalogModelInstance.GetProductByName(name));
        return RedirectToAction(nameof(Cart));
      }
      catch
      {
        return View();
      }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
