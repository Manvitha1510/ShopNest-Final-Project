using Microsoft.AspNetCore.Mvc;

namespace ShopNest.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View(); // This will render Views/Manage/Index.cshtml
        }
    }
}
