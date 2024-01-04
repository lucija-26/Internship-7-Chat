using ChatApp.Data.Entities;
using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Enums;


namespace ChatApp.Domain.Repositories
{
    public class GroupUserRepository : BaseRepository
    {
        public GroupUserRepository(ChatAppDbContext dbContext) : base(dbContext) { }


        public ResponseResultType Delete(int id)
        {
            var groupUserToDelete = DbContext.GroupUsers.Find(id);
            if (groupUserToDelete is null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.GroupUsers.Remove(groupUserToDelete);

            return SaveChanges();
        }
        public ResponseResultType Add(GroupUser groupUser)
        {
            DbContext.GroupUsers.Add(groupUser);

            return SaveChanges();
        }

    }
}
