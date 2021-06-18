using Microsoft.AspNetCore.Mvc.Rendering;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using ProductReviewAuthentication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductReviewAuthentication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserService _userService;
        private readonly IReviewRepository _reviewRepository;

        public ProductService(IProductRepository productRepository, IUserService userService, IReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _userService = userService;
            _reviewRepository = reviewRepository;
        }

        public Product AddProduct(string name, string description, Guid userId)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                CreatedAt = DateTime.Now,
                User = _userService.FindUserById(userId)
            };

            _productRepository.AddProduct(product);

            return product;
        }

        public Product FindProductById(Guid id)
        {
            return _productRepository.FindById(id);
        }

        public Product UpdateProduct(Guid id, string name, string description)
        {
            var product = _productRepository.FindById(id);
            product.Name = name;
            product.Description = description;

            return _productRepository.UpdateProduct(product);
        }

        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
        }

        public List<ProductViewModel> GetProducts(Guid userId)
        {
            var products = _productRepository.GetProducts(userId).Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UserName = _userService.FindUserById(p.UserId).Name,
                AverageRating = AverageRating(p.Id)
            }).ToList();

            return products;
        }

        public List<ProductViewModel> GetProductHomePage()
        {
            var products = _productRepository.GetProductHomePage().Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UserName = _userService.FindUserById(p.UserId).Name,
                AverageRating = AverageRating(p.Id)
            }).ToList();
            return products;
        }

        public List<ProductViewModel> GetProductHomePage(Guid userId)
        {
            var products = _productRepository.GetProductHomePage(userId).Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UserName = _userService.FindUserById(p.UserId).Name,
                AverageRating = AverageRating(p.Id)
            }).ToList();
            return products;
        }

        public List<Review> GetEachReview(Guid productId)
        {
            var review = _productRepository.GetEachReview(productId);
            return review;
        }

        public double AverageRating(Guid productId)
        {

            var reviews = _reviewRepository.FindByProductId(productId);
            double sum = 0;

            if (reviews.Count == 0) return 0;
            foreach (var review in reviews)
            {
                sum += review.Ratings;
            }
            double totalaverage = sum / reviews.Count;
            return totalaverage;

        }
        public IEnumerable<SelectListItem> GetProductList(Guid userId)
        {
            return _productRepository.GetReviewList(userId)
            .Select(u => new SelectListItem(u.Name, u.Id.ToString()));
        }

        public int ProductCount(Guid userId)
        {
            return _productRepository.ProductCount(userId);
        }
    }
}
