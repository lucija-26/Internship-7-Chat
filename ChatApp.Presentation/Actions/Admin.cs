

using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;

namespace ChatApp.Presentation.Actions
{
    public class Admin : IAction
    {
            private readonly UserRepository UserRepository;
            private readonly User activeUser;

            public int MenuIndex { get; set; }
            public string Name { get; set; } = "User Management";

            public Admin(UserRepository userRepository)
            {
                UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                activeUser = Login.GetCurrentUser();
            }

            public void Open()
            {
                if (!IsCurrentUserAdmin())
                {
                    Console.WriteLine("You are not an admin.");
                    return;
                }

                DisplayAllUsers();
                ProcessUserSelection();
            }

            private bool IsCurrentUserAdmin()
            {
                return activeUser?.IsAdmin == true;
            }

            private void DisplayAllUsers()
            {
                var users = UserRepository.GetAllUsers();
                Console.WriteLine("List of all registered users:");
                foreach (var user in users)
                {
                    Console.WriteLine($"User ID: {user.UserId}, Email: {user.Email}, Admin: {user.IsAdmin}");
                }
            }

            private void ProcessUserSelection()
            {
                Console.WriteLine("Select a user by ID:");
                if (int.TryParse(Console.ReadLine(), out var selectedUserId))
                {
                    ProcessSelectedUser(selectedUserId);
                }
                else
                {
                    Console.WriteLine("Invalid ID.");
                }
            }

            private void ProcessSelectedUser(int selectedUserId)
            {
                var chosenUser = UserRepository.GetById(selectedUserId);

                if (chosenUser != null)
                {
                    DisplayUserActions(chosenUser);
                }
                else
                {
                    Console.WriteLine($"User with ID {selectedUserId} does not exist.");
                }
            }

            private void DisplayUserActions(User chosenUser)
            {
                Console.WriteLine($"Actions for User ID {chosenUser.UserId}:");
                Console.WriteLine("1. Delete profile");
                Console.WriteLine("2. Change email");
                Console.WriteLine("3. Promote to admin");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DeleteUserProfile(chosenUser);
                        break;
                    case "2":
                        ChangeUserEmail(chosenUser);
                        break;
                    case "3":
                        PromoteUserToAdmin(chosenUser);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            private void DeleteUserProfile(User chosenUser)
            {
                UserRepository.Delete(chosenUser.UserId);
                Console.WriteLine($"Profile with User ID {chosenUser.UserId} deleted.");
            }

            private void ChangeUserEmail(User chosenUser)
            {
                Console.WriteLine("Enter new email:");
                var newEmail = Console.ReadLine();
                UserRepository.UpdateEmail(chosenUser.UserId, newEmail);
                Console.WriteLine($"Email for User with ID {chosenUser.UserId} updated.");
            }

            private void PromoteUserToAdmin(User chosenUser)
            {
                UserRepository.UpdateRole(chosenUser.UserId, true);
                Console.WriteLine($"User with ID {chosenUser.UserId} promoted to admin.");
            }
        }

    }
