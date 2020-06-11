using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Resources;
using MercadoPago.Common;

namespace ExamenMP.Controllers
{
    public class BackofficeController : Controller
    {
        
        public ActionResult Checkout(string image, string prodName, decimal price)
        {
            ViewBag.image = image;
            ViewBag.prodName = prodName;
            ViewBag.price = price;
            try
            {
                if (MercadoPago.SDK.AccessToken == null)
                {
                    MercadoPago.SDK.AccessToken = "APP_USR-6317427424180639-042414-47e969706991d3a442922b0702a0da44-469485398";
                }
            }
            catch
            {
                MercadoPago.SDK.AccessToken = "APP_USR-6317427424180639-042414-47e969706991d3a442922b0702a0da44-469485398";
            }


            Preference preference = new Preference();
            preference.Items.Add(
              new Item()
              {
                  
                  Title = prodName,
                  Description = "Dispositivo móvil de Tienda e-commerce",
                  Id = "1234",
                  Quantity = 1,
                  CurrencyId = CurrencyId.ARS,
                  UnitPrice = price,
                  PictureUrl = image,
              }
            );


           
            preference.ExternalReference = "nicomargo@protonmail.com";
            preference.Save();
            ViewBag.id = preference.Id;
            ViewBag.Title = "Home Page";

            return View();
            
        }

        public bool Webhook(JsonResult json = null)
        {
            Response.StatusCode = 200;
            Response.End();
            return true;
        }

       
    }
}
