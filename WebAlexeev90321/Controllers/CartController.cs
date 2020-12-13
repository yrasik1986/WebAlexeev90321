using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAlexeev90321.DAL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAlexeev90321.Extensions;
using WebAlexeev90321.Models;

namespace WebAlexeev90321.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        private Cart _cart;
        public CartController(ApplicationDbContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }
        public IActionResult Index()
        {
            return View(_cart.Items.Values);
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            var item = _context.RadioComponents.Find(id);
            if (item != null)
            {
                _cart.AddToCart(item);
            }
            return Redirect(returnUrl);
        }

        public IActionResult Delete(int id)
        {
            _cart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}
