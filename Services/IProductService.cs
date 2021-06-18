

using Microsoft.AspNetCore.Mvc.Rendering;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace ProductReviewAuthentication.Services
{
    public interface IProductService
    {
        public Product AddProduct(string name, string description, Guid userId);
        public List<ProductViewModel> GetProducts(Guid userId);
        public List<ProductViewModel> GetProductHomePage();

        public Product FindProductById(Guid id);
        public void Delete(Guid id);
        public Product UpdateProduct(Guid id, string name, string description);
        public List<Review> GetEachReview(Guid productId);
        public IEnumerable<SelectListItem> GetProductList(Guid userId);
        public double AverageRating(Guid productId);
        public List<ProductViewModel> GetProductHomePage(Guid userId);
        public int ProductCount(Guid userId);
    }
}
