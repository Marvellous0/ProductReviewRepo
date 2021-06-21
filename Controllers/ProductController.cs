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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IReviewService _reviewService;

        public ProductController(IProductService productService, IUserService userService, IReviewService reviewService)
        {
            _productService = productService;
            _userService = userService;
            _reviewService = reviewService;
        }

        public IActionResult Index(ProductViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var productList = _productService.GetProducts(userId);

            return View(productList);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {

            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Product p = _productService.AddProduct(model.Name, model.Description, userId);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Update(Guid id)
        {
            var product = _productService.FindProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(UpdateProductViewModel model)
        {
            _productService.UpdateProduct(model.Id, model.Name, model.Description);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var product = _productService.FindProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(ProductIndexViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            ViewBag.userName = user.Name;

            ViewBag.reviewList = _reviewService.GetEachReview(model.ProductId);

            var product = _productService.FindProductById(model.Id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
