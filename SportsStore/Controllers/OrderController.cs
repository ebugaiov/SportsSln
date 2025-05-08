using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers;

public class OrderController(IOrderRepository repo, Cart cart) : Controller
{
    public ViewResult Checkout() => View(new Order());

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        if (cart.Lines.Count() == 0)
            ModelState.AddModelError("", "Sorry, your cart is empty!");
        if (ModelState.IsValid)
        {
            order.Lines = cart.Lines.ToArray();
            repo.SaveOrder(order);
            cart.ClearCart();
            return RedirectToPage("/Completed", new { orderId = order.OrderID });
        }
        else
        {
            return View();
        }
    }
}