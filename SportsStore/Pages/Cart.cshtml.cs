using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Infrastructure;
using SportsStore.Models;

namespace SportsStore.Pages;

public class CartModel(IStoreRepository repository, Cart cartService) : PageModel
{
    public Cart Cart { get; set; } = cartService;
    public string ReturnUrl { get; set; } = "/";

    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
    }

    public IActionResult OnPost(long productId, string returnUrl)
    {
        Product? product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
        
        if (product != null)
        {
            Cart.AddItem(product, 1);
            HttpContext.Session.SetJson("cart", Cart);
        }

        return RedirectToPage(new { returnUrl = returnUrl });
    }

    public IActionResult OnPostRemove(long productId, string returnUrl)
    {
        Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductID == productId).Product);
        return RedirectToPage(new { returnUrl = returnUrl });
    }
}