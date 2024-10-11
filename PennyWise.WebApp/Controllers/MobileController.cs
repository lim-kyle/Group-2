using Microsoft.AspNetCore.Mvc;
using PennyWise.Data.Models;
using PennyWise.Services.Interfaces;

namespace PennyWise.WebApp.Controllers
{
    public class MobileController : Controller
    {
        private readonly IMobileService _mobileService;

        public MobileController(IMobileService mobileService)
        {
            _mobileService = mobileService;
        }

        public IActionResult Index()
        {
            IQueryable<Mobile> mobiles = _mobileService.GetMobiles();
            return View(mobiles);
        }

        public IActionResult AddMobile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMobile(Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                _mobileService.AddMobile(mobile);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UpdateMobile(int id)
        {
            Mobile? mobile = _mobileService.GetMobile(id);

            if (mobile == null)
            {
                return NotFound();
            }
            return View(mobile);
        }

        [HttpPost]
        public IActionResult UpdateMobile(Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                _mobileService.UpdateMobile(mobile);
                return RedirectToAction("Index");
            }
            return View(mobile);
        }

        public IActionResult DeleteMobile(int id)
        {
            _mobileService.DeleteMobile(id);
            return RedirectToAction("Index");
        }
    }
}
