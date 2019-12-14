using BotonesRelease.Extensions;
using BotonesRelease.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotonesRelease.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            Item i = new Item();
            i = i.Get(id);
            return View(i);
        }

        public ActionResult Cart()
        {
            Cart c = new Cart();
            if (Session["Cart"] != null)
            {
                c = Session["Cart"] as Cart;
            }

            return View(c);
        }

        [HttpPost]
        public ActionResult AddToCart(int qty, int id)
        {
            Cart c = new Cart();
            Item i = new Item();
            i = i.Get(id);

            if (Session["Cart"] != null)
            {
                c = Session["Cart"] as Cart;
            }

            if (c.ItemList.Exists(x => x.ID == id))
            {
                c.ItemList.Find(x => x.ID == id).QtyInCart = qty;
            }
            else
            {
                c.ItemList.Add(new ItemCart()
                {
                    ID = i.ID,
                    InStock = i.InStock,
                    Category = i.Category,
                    Cost = i.Cost,
                    Description = i.Description,
                    Material = i.Material,
                    Name = i.Name,
                    PictureUrl = i.PictureUrl,
                    Price = i.Price,
                    Provider = i.Provider,
                    QtyInCart = qty,
                    Total = qty * i.Price.Value
                });
            }

            Session["Cart"] = c;
            return RedirectToAction("Cart","Home");
        }

        public ActionResult DeleteItemFromCart(int id)
        {            
            Cart c = Session["Cart"] as Cart;
            c.ItemList.RemoveAll(x => x.ID == id);
            Session["Cart"] = c;
            return RedirectToAction("Cart","Home");
        }

        [HttpPost]
        public ActionResult ChangeQuantity(int id, int qty)
        {
            Cart c = Session["Cart"] as Cart;
            c.ItemList.FindAll(x => x.ID == id).FirstOrDefault().QtyInCart = qty;
            Session["Cart"] = c;
            return RedirectToAction("Cart", "Home");
        }

        public ActionResult Category(string category)
        {
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        public ActionResult SubmitContact(ContactModel m)
        {
            m.Add();
            ViewBag.Message = "Su información ha sido recibida, nos comunicaremos con usted lo antes posible.";
            //ViewBag.Message = "Your information was sent successfully, we will contact you as soon as possible.";
            return RedirectToAction("Index");
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult OrderNow()
        {
            // Read actual shopping cart from session
            List<ItemCart> cart = Session["Cart"] as List<ItemCart>;
            
            // 


            return View();
        }

        [HttpPost]
        public ActionResult SubmitOrder(OrderModel m)
        {
            string data = string.Empty;

            //Aquí es donde se envía la información a PayPal:
            Communicator.Post("https://www.sandbox.paypal.com/cgi-bin/webscr", data);



            //m.Add();
            //ViewBag.Message = "Su orden ha sido recibida exitosamente, nos comunicaremos con usted de necesitar más información para procesar la orden.";
            ////ViewBag.Message = "Your order was received successfully, we will contact you if more information is needed to process the order.";
            return Redirect();
        }


    }
}