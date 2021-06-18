using System;
using System.Collections.Generic;
using System.Linq;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using ProductReviewAuthentication.Repositories;

namespace ProductReviewAuthentication.Services
{
    public class ReviewService : IReviewService
    {
        public readonly IReviewRepository _reviewRepository;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ReviewService(IProductService productService, IUserService userService, IReviewRepository reviewRepository)
        {
            _productService = productService;
            _userService = userService;
            _reviewRepository = reviewRepository;
        }

        public Review AddReview(string comment, double ratings, Guid userId, Guid productId)
        {
            Review review = new Review
            {
                Id = Guid.NewGuid(),
                Comment = comment,
                Ratings = ratings,
                CreatedAt = DateTime.Now,
                User = _userService.FindUserById(userId),
                Product = _productService.FindProductById(productId)
            };

            _reviewRepository.AddReview(review);

            return review;
        }

        public Review UpdateReview(Guid id, string comment, double ratings)
        {
            var review = _reviewRepository.FindById(id);

            review.Comment = comment;

            review.Ratings = ratings;

            return _reviewRepository.UpdateReview(review);
        }

        public void Delete(Guid id)
        {
            _reviewRepository.Delete(id);
        }


        public List<Review> GetReviews(Guid userId)
        {
            return _reviewRepository.GetReview(userId);
        }

        public Review FindById(Guid id)
        {
            return _reviewRepository.FindById(id);
        }

        public List<ProductIndexViewModel> GetEachReview(Guid productId)
        {
            var reviews = _reviewRepository.GetEachReview(productId).Select(r => new ProductIndexViewModel
            {
                Id = r.Id,
                Comment = r.Comment,
                Ratings = r.Ratings,
                UserId = r.UserId,
                ProductId = r.ProductId,
                UserName = _userService.FindUserById(r.UserId).Name,
                ProductName = _productService.FindProductById(r.ProductId).Name,
            }).ToList();
            return reviews;
        }

        public int GetTotalReview(Guid userId)
        {
            return _reviewRepository.GetTotalReview(userId);
        }
    }
}
