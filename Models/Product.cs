using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }

        public User User { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
