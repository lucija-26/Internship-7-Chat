using ChatApp.Data.Entities;
using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Enums;
using System.Text.RegularExpressions;
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
