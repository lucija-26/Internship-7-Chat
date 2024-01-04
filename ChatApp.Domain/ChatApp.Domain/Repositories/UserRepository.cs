using System.Security.Cryptography;
using ChatApp.Data.Entities;
using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Domain.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(ChatAppDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(User user)
        {
            DbContext.Users.Add(user);

            return SaveChanges();
        }

        public ResponseResultType Delete(int id)
        {
            var userToDelete = DbContext.Users.Find(id);
            if (userToDelete is null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Users.Remove(userToDelete);

            return SaveChanges();
        }

        public ResponseResultType Update(User user)
        {
            var userToUpdate = DbContext.Users.Find(user.UserId);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Update(user);

            return SaveChanges();
        }
        public ICollection<User> GetAllUsers() => DbContext.Users.ToList();
        public User? GetByEmail(string email) => DbContext.Users.FirstOrDefault(u => u.Email == email);
        public User? GetById(int id) => DbContext.Users.FirstOrDefault(u => u.UserId == id);
    }
}
