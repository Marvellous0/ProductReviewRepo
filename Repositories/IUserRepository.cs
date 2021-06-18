using ProductReviewAuthentication.Models;
using System;

namespace ProductReviewAuthentication.Repositories
{
    public interface IUserRepository
    {
        public User AddUser(User user);


        public User UpdateUser(User user);

        public User FindUserByEmail(string email);

        public User FindUserById(Guid id);

    }
}
