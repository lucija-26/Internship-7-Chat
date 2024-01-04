using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Presentation.Actions
{
        public class DisplayUsersToMessage : IAction
        {
            private readonly UserRepository UserRepository;
            private readonly PrivateMessageRepository PrivateMessageRepository;

            public int MenuIndex { get; set; }
            public string Name { get; set; } = "Nova poruka";

            public DisplayUsersToMessage(UserRepository userRepository, PrivateMessageRepository directMessageRepository)
            {
                UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                PrivateMessageRepository = directMessageRepository ?? throw new ArgumentNullException(nameof(directMessageRepository));
            }

            public void Open()
            {
                DisplayAllUsers();

                OpenPrivateChat();
            }

            private void DisplayAllUsers()
            {
                var users = UserRepository.GetAllUsers();

                Console.WriteLine("Users: ");
                foreach (var user in users)
                {
                    Console.WriteLine($"User ID: {user.UserId}, Email: {user.Email}");
                }
            }

            private void OpenPrivateChat()
            {
                Console.WriteLine("ID of user you want to interact with (or '/exit'):");
                var input = Console.ReadLine();

                if (input?.ToLower() == "/exit")
                {
                    Console.WriteLine("Exiting...");
                    return;
                }

                if (int.TryParse(input, out var selectedUserId))
                {
                    ProcessSelectedUser(selectedUserId);
                }
                else
                {
                    Console.WriteLine("Wrong ID. Try again.");
                    OpenPrivateChat();
                }
            }

            private void ProcessSelectedUser(int selectedUserId)
            {
                var selectedUser = UserRepository.GetById(selectedUserId);

                if (selectedUser != null)
                {
                    DisplayPrivateChat(selectedUser);
                }
                else
                {
                    Console.WriteLine($"User with that ID doesn't exist.");
                    OpenPrivateChat();
                }
            }

            private void DisplayPrivateChat(User selectedUser)
            {
                var privateMessages = PrivateMessageRepository.GetPrivateMessages(Login.GetCurrentUser().UserId, selectedUser.UserId);

                Console.WriteLine($"Privatni chat s {selectedUser.Email}");

                foreach (var message in privateMessages)
                {
                    Console.WriteLine($"[{message.DateTime}] {message.Sender.Email}: {message.Message}");
                }

                SendMessageToUser(selectedUser);
            }

            private void SendMessageToUser(User otherUser)
            {
                Console.WriteLine("Enter your message or type /exit:");

                while (true)
                {
                    var messageText = Console.ReadLine();

                    if (messageText?.ToLower() == "/exit")
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }

                    PrivateMessageRepository.Add(new PrivateMessage
                    {
                        SenderId = Login.GetCurrentUser().UserId,
                        ReceiverId = otherUser.UserId,
                        Message = messageText,
                        DateTime = DateTime.UtcNow
                    });
                }
            }
        }

    }
