using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    [Authorize]
    public class FrindProfileController : Controller
    {
        public IActionResult frindProfile()
        {
            return View();
        }
    }
}
