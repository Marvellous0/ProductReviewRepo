using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductReviewAuthentication.Models;

namespace ProductReviewAuthentication.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ProductAuthenticationDbContext _dbContext;

        public ReviewRepository(ProductAuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Review AddReview(Review review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
            return review;
        }

        public Review FindById(Guid id)
        {
            return _dbContext.Reviews.Find(id);
        }

        public List<Review> FindByProductId(Guid ProductId)
        {
            return _dbContext.Reviews.Where(review => review.Product.Id == ProductId).ToList();
        }

        public List<Review> GetReview(Guid userId)
        {
            return _dbContext.Reviews.Include(r => r.Product).Include(r => r.User).ToList();
        }

        public Review UpdateReview(Review review)
        {

            _dbContext.Reviews.Update(review);
            _dbContext.SaveChanges();
            return review;

        }

        public void Delete(Guid id)
        {
            var user = FindById(id);
            {
                if (user != null)
                {
                    _dbContext.Reviews.Remove(user);
                    _dbContext.SaveChanges();
                }
            }
        }

        public List<Review> GetEachReview(Guid productId)
        {
            return _dbContext.Reviews.Where(review => review.ProductId == productId).ToList();
        }

        public int GetTotalReview(Guid userId)
        {
            return _dbContext.Reviews.Where(p => p.UserId == userId).Count();
        }

    }
}
