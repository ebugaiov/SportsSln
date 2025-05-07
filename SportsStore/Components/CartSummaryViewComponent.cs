using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components;

public class CartSummaryViewComponent(Cart cartService) : ViewComponent
{
    public IViewComponentResult Invoke() => View(cartService);
}
