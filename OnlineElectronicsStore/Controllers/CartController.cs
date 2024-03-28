using Microsoft.AspNetCore.Mvc;

namespace OnlineElectronicsStore.Controllers;

public class CartController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}