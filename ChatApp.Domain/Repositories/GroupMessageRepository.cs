using ChatApp.Data.Entities;
using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;


namespace ChatApp.Domain.Repositories
{
    public class GroupMessageRepository : BaseRepository
    {
        public GroupMessageRepository(ChatAppDbContext dbContext) : base(dbContext) { }

        public ResponseResultType Add(GroupMessage GroupMessage)
        {
            DbContext.GroupMessages.Add(GroupMessage);

            return SaveChanges();
        }

        public ICollection<GroupMessage> GetAll() => DbContext.GroupMessages.ToList();
        public ResponseResultType Delete(int id)
        {
            var MessageToDelete = DbContext.GroupMessages.Find(id);
            if (MessageToDelete is null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.GroupMessages.Remove(MessageToDelete);

            return SaveChanges();
        }
        public List<GroupMessage> GetChannelMessages(int groupId)
        {
            var messages = DbContext.GroupMessages
                .Include(gm => gm.Sender)
                .Where(gm => gm.GroupId == groupId)
                .OrderBy(gm => gm.DateTime)
                .ToList();

            return messages;
        }

        public ResponseResultType AddMessage(int groupId, int senderUserId, string mesage)
        {
            var group = DbContext.Groups.Find(groupId);
            var sender = DbContext.Users.Find(senderUserId);

            if (group == null || sender == null)
            {
                return ResponseResultType.NotFound;
            }

            var groupMessage = new GroupMessage
            {
                GroupId = groupId,
                SenderId = senderUserId,
                DateTime = DateTime.UtcNow,
                Message = mesage
            };

            DbContext.GroupMessages.Add(groupMessage);

            return SaveChanges();
        }
    }
}
