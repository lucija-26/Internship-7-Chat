using ChatApp.Data.Entities;
using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
