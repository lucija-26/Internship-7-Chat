

using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;

namespace ChatApp.Presentation.Actions
{
    public class UserChannels : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "All user's channels";
        private readonly GroupRepository? GroupRepository;
        private readonly GroupMessageRepository? GroupMessageRepository;
        User activeUser = Login.GetCurrentUser();
        public UserChannels(GroupRepository groupRepository, GroupMessageRepository groupMessageRepository)
        {
            GroupRepository = groupRepository;
            GroupMessageRepository = groupMessageRepository;
        }
        public void Open()
        {
            var joinedChannels = GroupRepository.AvailableChannels(activeUser.UserId);
            Console.WriteLine("List of your channels: ");
            foreach(var channel in joinedChannels)
            {
                Console.WriteLine($"Channel: {channel.GroupName}, Total Users: {channel.GroupUsers.Count}");
            }
            var chosenChannel = GetChannel();
            DisplayMessages(chosenChannel);
            SendMessage(chosenChannel);
        }

        private void DisplayMessages(Group chosenChannel)
        {
            var channelMessages = GroupMessageRepository.GetChannelMessages(chosenChannel.GroupId);
            foreach(var message in channelMessages)
            {
                Console.WriteLine($"[{message.DateTime}] {message.Sender.UserName}: {message.Message}");
            }
        }

        private Group GetChannel()
        {
            Console.WriteLine("Enter channel name: ");
            var channel = Console.ReadLine();
            return GroupRepository.GetByName(channel);
        }

        private void SendMessage(Group chosenChannel)
        {
            Console.WriteLine("Enter your message: ");
            Console.WriteLine("If you wish to exit, type '/exit'");
            var message = Console.ReadLine();
            while(message?.ToLower()!= "/exit")
            {
                message = Console.ReadLine();
                if(message?.ToLower() != "/exit")
                    GroupMessageRepository.AddMessage(chosenChannel.GroupId, activeUser.UserId, message);
            }
        }
    }
}
