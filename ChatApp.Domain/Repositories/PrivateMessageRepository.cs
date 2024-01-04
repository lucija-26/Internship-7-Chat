using ChatApp.Data.Entities.Models;
using ChatApp.Data.Entities;
using ChatApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Domain.Repositories
{
    public class PrivateMessageRepository : BaseRepository
    {
        public PrivateMessageRepository(ChatAppDbContext dbContext) : base(dbContext)
        {
        }
        public ResponseResultType Add(PrivateMessage DirectMessage)
        {
            DbContext.PrivateMessages.Add(DirectMessage);

            return SaveChanges();
        }
        public ResponseResultType DeletePrivateMessage(int messageId)
        {
            var messageToDelete = DbContext.PrivateMessages.Find(messageId);

            if (messageToDelete == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.PrivateMessages.Remove(messageToDelete);

            return SaveChanges();
        }

    }
}
