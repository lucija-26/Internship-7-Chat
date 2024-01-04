using ChatApp.Data.Entities;
using ChatApp.Data.Entities.Models;
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
        public ResponseResultType AddUserToGroup(int groupId, int userId)
        {
            var group = DbContext.Groups.Find(groupId);
            var user = DbContext.Users.Find(userId);

            if (group == null || user == null)
            {
                return ResponseResultType.NotFound;
            }

            var groupUser = new GroupUser { GroupId = groupId, UserId = userId };
            DbContext.GroupUsers.Add(groupUser);

            return SaveChanges();
        }
        public Group GetByName(string groupName)
        {
            return DbContext.Groups.FirstOrDefault(g => g.GroupName == groupName);
        }

        public ICollection<Group> AvailableChannels(int userId)
        {
            return DbContext.Groups
                .Where(g => !g.GroupUsers.Any(gu => gu.UserId == userId))
                .ToList();
        }
    }
}
