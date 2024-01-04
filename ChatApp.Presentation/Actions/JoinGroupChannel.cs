

using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Enums;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;

namespace ChatApp.Presentation.Actions
{
    public class JoinGroupChannel : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Join a channel";

        public readonly GroupRepository? GroupRepository;
        public readonly UserRepository? UserRepository;
        User ActiveUser = Login.GetCurrentUser();
        public JoinGroupChannel(GroupRepository? groupRepository, UserRepository? userRepository)
        {
            GroupRepository = groupRepository;
            UserRepository = userRepository;
        }
        public void Open()
        {
            var notJoinedChannel = GroupRepository.AvailableChannels(ActiveUser.UserId);

            if(notJoinedChannel.Count == 0)
            {
                Console.WriteLine("User has joined all available channels.");
            }
            Console.WriteLine("Available channels:");
            foreach (var channel in notJoinedChannel)
            {
                Console.WriteLine($"Channel: {channel.GroupName}, Total Users: {channel.GroupUsers.Count}");
            }
            Console.WriteLine("Enter the name of the channel you want to join.");
            var channelName = Console.ReadLine();
            var chosenChannel = GroupRepository.GetByName(channelName);
            if(chosenChannel == null)
            {
                Console.WriteLine($"Channel '{channelName}' not found.");
                return;
            }
            var result = GroupRepository.AddUserToGroup(chosenChannel.GroupId, ActiveUser.UserId);

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine($"You have successfully joined the channel: '{chosenChannel.GroupName}'.");
            }
            else
            {
                Console.WriteLine($"Failed to join the channel: '{chosenChannel.GroupName}'.");
            }

        }
    }
}
