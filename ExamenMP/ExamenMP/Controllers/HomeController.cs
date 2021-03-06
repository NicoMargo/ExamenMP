﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Resources;
using MercadoPago.Common;
using System.Web.UI.WebControls;

namespace ExamenMP.Controllers
{
    public class HomeController : Controller      
    {
        public ActionResult ian()
        {
            return View();
        }
        public ActionResult Index()
        {
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
          

            /*Payment pago = new Payment()
            {
                TransactionAmount = float.Parse("100"),
                Description = "Título del producto",
                PaymentMethodId = "rapipago"
            };*/

            Preference preference = new Preference();
            preference.Items.Add(
              new Item()
              {
                  Title = "Camion",
                  Description = "Dispositivo móvil de Tienda e-commerce",
                  Id = "1234",
                  Quantity = 1,
                  CurrencyId = CurrencyId.ARS,
                  UnitPrice = 20,
                  PictureUrl = "url",
              }
            );

            

           

            Payer payer = new Payer()
            {
                Name = "Lalo",
                Surname = "Landa",
                Email = "test_user_63274575@testuser.com",
                Phone = new Phone()
                {
                    Number = "22223333",
                    AreaCode = "11"
                },
                Address = new Address()
                {
                    StreetName ="False",
                    StreetNumber = 123,
                    ZipCode = "1111"

                }
            };            

            preference.Payer = payer;
            preference.Save();
            ViewBag.id = preference.Id;
            ViewBag.Title = "Home Page";

            return View();
        }        

    }
}
