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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MercadoPago.SDK.AccessToken = "APP_USR-1099637394746666-052110-ff002ef660dc677146ed958c7162dfb9-571544946";
            Preference preference = new Preference();
            preference.Items.Add(
              new Item()
              {
                  Title = "Camion",
                  Quantity = 1,
                  CurrencyId = CurrencyId.ARS,
                  UnitPrice = 20
              }
            );
            preference.Save();
            ViewBag.id = preference.Id;
            ViewBag.Title = "Home Page";

            return View();
        }
        public bool ProcesarPago()
        {

            return true;
        }

    }
}
