using Microsoft.AspNetCore.Mvc;
using PennyWise.Data.Models;
using PennyWise.Services.Interfaces;

namespace PennyWise.WebApp.Controllers
{
    public class WishController : Controller
    {
        private readonly IWishService _wishService;

        public WishController(IWishService wishService)
        {
            this._wishService = wishService;
        }

        public IActionResult Index()
        {
            IQueryable <Wish> wishes = _wishService.GetWishes();
            return View(wishes);
        }

        public IActionResult AddWish()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWish(Wish wish)
        {
            if (ModelState.IsValid)
            {
                _wishService.AddWish(wish);
                TempData["SuccessMessage"] = "Wish added successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UpdateWish(int id)
        {
            Wish? wish = _wishService.GetWish(id);

            if (wish == null)
            {
                return NotFound();
            }
            return View(wish);
        }

        [HttpPost]
        public IActionResult UpdateWish(Wish wish)
        {
            if (ModelState.IsValid)
            {
                _wishService.UpdateWish(wish);
                TempData["SuccessMessage"] = "Wish Updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteWish(int id)
        {
            _wishService.DeleteWish(id);
            TempData["SuccessMessage"] = "Wish Deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
