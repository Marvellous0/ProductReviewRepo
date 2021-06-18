
using Microsoft.EntityFrameworkCore;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductReviewAuthentication.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductAuthenticationDbContext _dbContext;

        public ProductRepository(ProductAuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public Product FindById(Guid id)
        {
            return _dbContext.Products.Find(id);
        }
        public Product UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return product;
        }

        public List<Product> GetProducts(Guid userId)
        {
            return _dbContext.Products.Include(p => p.User).Where(p => p.User.Id == userId).ToList();
        }

        public void Delete(Guid id)
        {
            var product = FindById(id);
            {
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    _dbContext.SaveChanges();
                }
            }
        }

        public List<Product> GetProductHomePage()
        {
            return _dbContext.Products.ToList();
        }

        public List<Product> GetProductHomePage(Guid userId)
        {
            return _dbContext.Products.Include(p => p.User).Where(product => product.UserId != userId).ToList();
        }

        public List<Review> GetEachReview(Guid productId)
        {
            return _dbContext.Reviews.Where(review => review.ProductId == productId).ToList();
        }

        public List<Product> GetReviewList(Guid userId)
        {
            return _dbContext.Products.Include(p => p.User).Where(product => product.User.Id != userId).ToList();
        }

        public int ProductCount(Guid userId)
        {
            return _dbContext.Products.Where(p => p.UserId == userId).Count();
        }

    }
}
