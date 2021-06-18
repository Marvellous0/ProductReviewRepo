using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using ProductReviewAuthentication.Services;

namespace ProductReviewAuthentication.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public ReviewController(IReviewService reviewService, IUserService userService, IProductService productService)
        {
            _reviewService = reviewService;
            _userService = userService;
            _productService = productService;
        }

        public IActionResult Index(ProductIndexViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            List<ProductIndexViewModel> productIndexVM = new List<ProductIndexViewModel>();

            var reviews = _reviewService.GetReviews(userId);

            foreach (var review in reviews)
            {
                ProductIndexViewModel productIndex = new ProductIndexViewModel
                {
                    Id = review.Id,
                    Comment = review.Comment,
                    Ratings = review.Ratings,
                    UserName = _userService.FindUserById(review.User.Id).Name,
                    ProductName = _productService.FindProductById(review.Product.Id).Name,
                };

                productIndexVM.Add(productIndex);
            }

            return View(productIndexVM);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            User user = _userService.FindUserById(userId);

            if (user == null) return RedirectToAction(nameof(Index));

            ViewBag.products = _productService.GetProductList(userId);
            ViewBag.userId = user.Name;

            return View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateReviewViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            _reviewService.AddReview(model.Comment, model.Ratings, userId, model.ProductId);

            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            var review = _reviewService.FindById(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);

        }

        [HttpPost]
        public IActionResult Update(UpdateReviewViewModel model)
        {
            _reviewService.UpdateReview(model.Id, model.Comment, model.Ratings);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(Guid id)
        {
            var review = _reviewService.FindById(id);
            if (review == null)
            {
                return NotFound();
            }

            _reviewService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            ViewBag.userName = user.Name;

            // Product product = _productService.FindProductById(id);

            // ViewBag.productName = product.Name;
            var review = _reviewService.FindById(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }
    }
}