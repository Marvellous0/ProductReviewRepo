using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using ProductReviewAuthentication.Services;
using System.Diagnostics;

namespace ProductReviewAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IReviewService reviewService)
        {
            _logger = logger;
            _productService = productService;
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productList = _productService.GetProductHomePage();

            return View(productList);
        }

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
