using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductReviewAuthentication.Models
{
    public class User : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(6)]
        public string Gender { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string HashSalt { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
