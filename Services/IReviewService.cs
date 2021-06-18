using System;
using System.Collections.Generic;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;

namespace ProductReviewAuthentication.Services
{
    public interface IReviewService
    {
        public Review AddReview(string comment, double ratings, Guid userId, Guid productId);
        public List<Review> GetReviews(Guid userId);
        public Review UpdateReview(Guid id, string comment, double ratings);
        public void Delete(Guid id);
        public Review FindById(Guid id);
        public List<ProductIndexViewModel> GetEachReview(Guid productId);
        public int GetTotalReview(Guid userId);
    }
}
