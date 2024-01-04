

using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;
using System.Text.RegularExpressions;

namespace ChatApp.Presentation.Actions
{
    public class ProfileSettings : IAction
    {
        private readonly UserRepository? UserRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Profile Settings";
        public ProfileSettings(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public void Open()
        {
            var currentUser = Login.GetCurrentUser();

            Console.WriteLine("Select:");
            Console.WriteLine("1. Change password");
            Console.WriteLine("2. Change email");
            Console.WriteLine("3. Return");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ChangeUserPassword(currentUser);
                    break;
                case "2":
                    ChangeUserEmail(currentUser);
                    break;
                case "3":
                    Console.WriteLine("Return");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Open();
                    break;
            }
        }

        private void ChangeUserPassword(User activeUser)
        {
            Console.WriteLine("Current password:");
            var currentPassword = Console.ReadLine();

            if (currentPassword == activeUser.Password)
            {
                Console.WriteLine("New password: ");
                var newPassword = GetUserPassword();


                activeUser.Password = newPassword;
                UserRepository.Update(activeUser, activeUser.UserId);

                Console.WriteLine("Password changed");
            }
            else
            {
                Console.WriteLine("Wrong current password.");
            }
        }

        private void ChangeUserEmail(User activeUser)
        {
            var newEmail = GetUserEmail(UserRepository);

            activeUser.Email = newEmail;
            UserRepository.Update(activeUser, activeUser.UserId);

            Console.WriteLine("Email changed.");
        }

        public string GetUserPassword()
        {
            var password = Console.ReadLine();
            while (!IsValidPassword(password))
            {
                Console.WriteLine("Please try again. ");
                password = Console.ReadLine();
            }
            return password;
        }
        static bool IsValidPassword(string password)
        {

            const int minLength = 8;
            bool hasLetter = false;
            bool hasDigit = false;

            if (password.Length < minLength)
            {
                Console.WriteLine("Password should be at least 8 characters long.");
                return false;
            }

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }

            if (!hasLetter || !hasDigit)
            {
                Console.WriteLine("Password should contain a combination of letters and numbers.");
                return false;
            }

            return true;
        }
        static string GetUserEmail(UserRepository userRepository)
        {
            string email;

            do
            {
                Console.WriteLine("Please enter your email:");
                email = Console.ReadLine();

                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email format. Please enter a valid email address.");
                }

                if (userRepository.GetByEmail(email) != null)
                {
                    Console.WriteLine("This email is already in use. Please choose a different one.");
                }

            } while (!IsValidEmail(email) || userRepository.GetByEmail(email) != null);

            return email;
        }
        static bool IsValidEmail(string email)
        {
            // Regular expression for a simple email validation
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            // Using Regex class to validate the email
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
    }
}

