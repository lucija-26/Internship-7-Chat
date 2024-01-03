using ChatApp.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ChatApp.Data.Seeds
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>
                {
                    new User()
                    {
                        UserId = 1,
                        Email = "lucija@gmail.com",
                        Password = "lucija123",
                        UserName = "lucija",
                        IsAdmin = true
                    },
                    new User()
                    {
                        UserId = 2,
                        Email = "gabriela@gmail.com",
                        Password = "gabriela123",
                        UserName = "gabriela",
                        IsAdmin = true
                    },
                    new User()
                    {
                        UserId = 3,
                        Email = "daria@gmail.com",
                        Password = "daria123",
                        UserName = "daria",
                        IsAdmin = true
                    },
                    new User()
                    {
                        UserId = 4,
                        Email = "tea@gmail.com",
                        Password = "tea123",
                        UserName = "tea",
                        IsAdmin = false
                    }
                });
            builder.Entity<PrivateMessage>()
                .HasData(new List<PrivateMessage>
                {
                    new PrivateMessage()
                    {
                        PrivateMessageId = 1,
                        SenderId = 1,
                        ReceiverId = 2,
                        Message = "Sretna Nova godina!",
                        DateTime = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new PrivateMessage()
                    {
                        PrivateMessageId = 2,
                        SenderId = 2,
                        ReceiverId = 1,
                        Message = "Sretna Nova godina :)",
                        DateTime = new DateTime(2024, 1, 1, 0, 0, 1, DateTimeKind.Utc)
                    }
                });
            builder.Entity<Group>()
                .HasData(new List<Group>
                {
                    new Group()
                    {
                        GroupId = 1,
                        GroupName = "Random"
                    },
                    new Group()
                    {
                        GroupId = 2,
                        GroupName = "General"
                    }
                });
            builder.Entity<GroupUser>()
                .HasData(new List<GroupUser>
                {
                    new GroupUser()
                    {
                        GroupId = 1,
                        UserId = 1
                    },
                    new GroupUser()
                    {
                        GroupId = 1,
                        UserId = 2
                    },
                    new GroupUser()
                    {
                        GroupId = 1,
                        UserId = 3
                    },
                    new GroupUser()
                    {
                        GroupId = 1,
                        UserId = 4
                    },
                    new GroupUser()
                    {
                        GroupId = 2,
                        UserId = 1
                    },
                    new GroupUser()
                    {
                        GroupId = 2,
                        UserId = 2
                    }
                });
            builder.Entity<GroupMessage>()
                .HasData(new List<GroupMessage>
                {
                    new GroupMessage()
                    {
                      GroupMessageId = 1,
                      SenderId = 1,
                      GroupId = 1,
                      Message = "Hello world",
                      DateTime = new DateTime(2024,1,1,19,50,0, DateTimeKind.Utc)
                    },
                    new GroupMessage()
                    {
                      GroupMessageId = 2,
                      SenderId = 2,
                      GroupId = 1,
                      Message = "Hello world",
                      DateTime = new DateTime(2024,1,1,19,11,0, DateTimeKind.Utc)
                    },
                    new GroupMessage()
                    {
                      GroupMessageId = 3,
                      SenderId = 1,
                      GroupId = 2,
                      Message = "Hello from the other side",
                      DateTime = new DateTime(2024,1,1,19,51,0, DateTimeKind.Utc)
                    }
                });
        }
    }
}
