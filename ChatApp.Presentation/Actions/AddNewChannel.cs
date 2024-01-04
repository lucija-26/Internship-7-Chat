

using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Enums;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;

namespace ChatApp.Presentation.Actions
{
    public class AddNewChannel : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Add new channel";

        public readonly GroupRepository? GroupRepository;
        User? user1 = Login.GetCurrentUser();

        public AddNewChannel(GroupRepository groupRepository)
        {
            GroupRepository = groupRepository;
        }
        public void Open()
        {
            Console.WriteLine(user1.UserName);
            Console.WriteLine("Insert channel name: ");
            var channelName = Console.ReadLine();
            var newGroup = new Group { GroupName = channelName };
            var groupUser = new GroupUser
            {
                UserId = user1.UserId,
                User = user1,
                Group = newGroup
            };
            newGroup.GroupUsers = new List<GroupUser> { groupUser };
            if (GroupRepository.AddGroup(newGroup) == ResponseResultType.Success)
            {
                Console.WriteLine("Channel successfully added.");
            }
            else
            {
                Console.WriteLine("Channel was not added. ");
            }
        }
    }
}
