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

        public List<User> GetUsersInteractions(int userId)
        {
            var senders = DbContext.PrivateMessages
                .Where(message => message.SenderId == userId)
                .OrderByDescending(message => message.DateTime)
                .Select(message => message.Receiver)
                .ToList();

            var receivers = DbContext.PrivateMessages
                .Where(message => message.ReceiverId == userId)
                .OrderByDescending(message => message.DateTime)
                .Select(message => message.Sender)
                .ToList();

            var interactions = senders.Concat(receivers).Distinct().ToList();

            return interactions;
        }


        public List<PrivateMessage> GetPrivateMessages(int senderId, int receiverId)
        {
            var sender = DbContext.Users.Find(senderId);
            var receiver = DbContext.Users.Find(receiverId);

            if (sender == null || receiver == null)
            {
                return new List<PrivateMessage>();
            }

            return DbContext.PrivateMessages
                .Where(message =>
                    (message.SenderId == senderId && message.ReceiverId == receiverId) ||
                    (message.SenderId == receiverId && message.ReceiverId == senderId))
                .OrderBy(message => message.DateTime)
                .ToList();
        }

    }
}
