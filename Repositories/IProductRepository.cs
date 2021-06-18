using ProductReviewAuthentication.Models;
using System;
using System.Collections.Generic;

namespace ProductReviewAuthentication.Repositories
{
    public interface IProductRepository
    {
        public Product AddProduct(Product product);

        public Product FindById(Guid id);

        public List<Product> GetProducts(Guid userId);
        public Product UpdateProduct(Product product);
        public void Delete(Guid id);
        public List<Review> GetEachReview(Guid productId);
        public List<Product> GetReviewList(Guid userId);
        public List<Product> GetProductHomePage();
        public List<Product> GetProductHomePage(Guid userId);
        public int ProductCount(Guid userId);
    }
}
