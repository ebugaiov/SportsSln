using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components;

public class NavigationMenuViewComponent(IStoreRepository repository) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        return View(repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
    }
}