using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductReviewAuthentication.Models;

namespace ProductReviewAuthentication.Repositories
{
    public interface IReviewRepository
    {
        public Review AddReview(Review review);

        public Review FindById(Guid id);
        public List<Review> FindByProductId(Guid ProductId);
        public List<Review> GetReview(Guid userId);
        public Review UpdateReview(Review review);
        public void Delete(Guid id);
        public List<Review> GetEachReview(Guid productId);
        public int GetTotalReview(Guid userId);
    }
}
