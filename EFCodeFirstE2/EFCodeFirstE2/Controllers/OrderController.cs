using EFCodeFirstE2.Auth;
using EFCodeFirstE2.EF;
using EFCodeFirstE2.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstE2.Controllers
{
    [Logged]
    public class OrderController : Controller
    {
        // GET: Order

        public ActionResult Index(int id = 1)
        {
            var db = new PMSDb();
            int itemperpage = 20;
            var products = db.Products.OrderBy(e => e.Id).Skip((id - 1) * itemperpage).Take(itemperpage).ToList();

            var pagescount = Math.Ceiling(db.Products.Count() / (decimal)itemperpage);
            ViewBag.Pages = pagescount;
            return View(products);
        }
        public ActionResult AddCart(int id)
        {
            PMSDb db = new PMSDb();
            List<Product> cart = null;
            if (Session["cart"] == null)
            {
                cart = new List<Product>();
            }
            else
            {
                cart = (List<Product>)Session["cart"];
            }

            var product = db.Products.Find(id);
            cart.Add(new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Cid = product.Cid,
                Qty = 1,
                Price = product.Price,
            });

            Session["cart"] = cart;

            TempData["Msg"] = "Successfully Added";
            return RedirectToAction("Index");
        }
        public ActionResult Cart()
        {

            var cart = (List<Product>)Session["cart"];
            if (cart != null)
            {
                return View(cart);
            }
            TempData["Msg"] = "Cart Empty";
            return RedirectToAction("Index");


        }

        public ActionResult Place()
        {
            int orderSum = 0;
            var cart = (List<Product>)Session["cart"];
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.Status = "Ordered";
            order.Amount = 0;
            PMSDb db = new PMSDb();
            db.Orders.Add(order);
            db.SaveChanges();
            foreach (var p in cart)
            {
                var od = new OrderDetail();
                od.OId = order.Id;
                od.PId = p.Id;
                od.Price = (int)p.Price;
                od.Qty = p.Qty;
                orderSum += (p.Qty * (int)p.Price);
                db.OrderDetails.Add(od);
            }
            order.Amount = orderSum;
            db.SaveChanges();
            Session["cart"] = null;
            TempData["Msg"] = "Order Placed Successfully";
            return RedirectToAction("Index");

        }

        [AdminAccess]
        public ActionResult AllOrders()
        {
            var db = new PMSDb();
            return View(db.Orders.ToList());
        }
        [AdminAccess]
        public ActionResult Details(int id)
        {
            var db = new PMSDb();
            var order = db.Orders.Find(id);
            return View(order);
        }

        [AdminAccess]
        public ActionResult Process(int id)
        {
            PMSDb ctx = new PMSDb();
            var order = ctx.Orders.Find(id);
            foreach (var od in order.OrderDetails)
            {
                var p = ctx.Products.Find(od.PId);
                p.Qty -= od.Qty;
            }
            order.Status = "Processing";
            ctx.SaveChanges();
            TempData["Msg"] = "Orded Placed Successfully";
            return RedirectToAction("AllOrders");

        }
        [AdminAccess]
        public ActionResult Cancel(int id)
        {
            PMSDb db = new PMSDb();
            var order = db.Orders.Find(id);
            order.Status = "Cancelled by Admin";
            db.SaveChanges();
            TempData["Msg"] = "Orded Cancelled";
            return RedirectToAction("AllOrders");
        }
    }
}