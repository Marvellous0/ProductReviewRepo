using System;

namespace ProductReviewAuthentication.Models
{
    public class Review : BaseEntity
    {
        public User User { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

        public string Comment { get; set; }

        public double Ratings { get; set; }
    }
}
