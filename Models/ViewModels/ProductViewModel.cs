using System;
using System.ComponentModel.DataAnnotations;

namespace ProductReviewAuthentication.Models.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string UserName { get; set; }

        public string Description { get; set; }

        public double AverageRating { get; set; }
    }

    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Product name is required")]
        [Display(Name = "Product Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Description is required")]
        [Display(Description = "Product Description:")]
        public string Description { get; set; }

    }

    public class UpdateProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [Display(Name = "Product Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Description is required")]
        [Display(Description = "Product Description:")]
        public string Description { get; set; }
    }

}
