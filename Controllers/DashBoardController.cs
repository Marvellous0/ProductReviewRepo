using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using ProductReviewAuthentication.Services;
using System;
using System.Linq;
using System.Security.Claims;

namespace ProductReviewAuthentication.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;

        public DashBoardController(IProductService productService, IReviewService reviewService, IUserService userService)
        {
            _productService = productService;
            _reviewService = reviewService;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index(ProductViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            ViewBag.TotalProducts = _productService.ProductCount(userId);
            ViewBag.TotalReviews = _reviewService.GetTotalReview(userId);
            ViewBag.UserName = user.Name;
            var productList = _productService.GetProductHomePage(userId);

            return View(productList);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Detail(ProductViewModel model)
        {
            var reviews = _reviewService.GetEachReview(model.Id);

            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

    }
}
