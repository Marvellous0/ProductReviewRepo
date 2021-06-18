using System;
using System.ComponentModel.DataAnnotations;

namespace ProductReviewAuthentication.Models.ViewModels
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public Product Product { get; set; }
        public string Comment { get; set; }

        [Range(1, 5)]
        public double Ratings { get; set; }
        public string UserName { get; set; }

    }

    public class ProductIndexViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public string Comment { get; set; }

        public double Ratings { get; set; }

        public string UserName { get; set; }

        public string ProductName { get; set; }
        public double AverageRating { get; set; }
    }

    public class SelectUserViewModel
    {
        [Required(ErrorMessage = "You must fill out this field!")]
        [Display(Name = "User Name:")]
        public int UserId { get; set; }

    }

    public class CreateReviewViewModel
    {
      

        [Required(ErrorMessage = "You must fill out this field!")]
        [Display(Name = "Product Name:")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Please make a Comment!!")]
        [Display(Name = "Comment Section:")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Rate Us Here!")]
        [Range(1, 5)]
        public double Ratings { get; set; }
    }

    public class UpdateReviewViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Update Comment required")]
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Range(1, 5)]
        public double Ratings { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

    }
}