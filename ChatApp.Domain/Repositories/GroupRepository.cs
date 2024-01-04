using ChatApp.Data.Entities;
using ChatApp.Domain.Enums;
using Group = ChatApp.Data.Entities.Models.Group;


namespace ChatApp.Domain.Repositories
{
    public class GroupRepository : BaseRepository
    {
        public GroupRepository(ChatAppDbContext dbContext) : base(dbContext)
        {
        }
        public ResponseResultType AddGroup(Group group)
        {
            DbContext.Groups.Add(group);

            return SaveChanges();
        }
    }
}
