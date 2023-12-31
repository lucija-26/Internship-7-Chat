﻿using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Enums;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;
using System.Text.RegularExpressions;


namespace ChatApp.Presentation.Actions
{
    public class Register : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Register";
        

        private readonly UserRepository UserRepository;
        public Register(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public void Open()
        {
            var email = GetUserEmail(UserRepository);
            var password = GetUserPassword();
            var username = GetUsername(UserRepository);
            ConfirmPassword(password);
            string capcha = GenerateRandomCaptcha();
            ConfirmCaptcha(capcha);
            if (UserRepository.Add(new User()
            {
                Email = email,
                Password = password,
                UserName = username
            }
            ) == ResponseResultType.Success)
            Console.WriteLine("Successfully registered!");
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

        static string GetUsername(UserRepository userRepository)
        {
            string username;
            do
            {
                username = Console.ReadLine();
                if (!IsValidUsername(username))
                {
                    Console.WriteLine("Invalid username format. Please enter a valid username. ");
                }
                if (userRepository.GetByUsername(username) != null)
                {
                    Console.WriteLine("This username is already in use. Please choose a different one. ");
                }
            } while(!IsValidUsername(username) || userRepository.GetByUsername(username) != null);
            return username;
        }

        public string GetUserPassword()
        {
            var password = Console.ReadLine();
            while(!IsValidPassword(password))
            {
                Console.WriteLine("Please try again. ");
                password = Console.ReadLine();
            }
            return password;
        }

        public void ConfirmPassword(string initialPassword)
        {
            string confirmedPassword = "";
            do
            {
                Console.WriteLine("Repeat password: ");
                confirmedPassword = Console.ReadLine();
            } while (!ArePasswordsMatching(initialPassword, confirmedPassword));
        }

        public string GenerateRandomCaptcha()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            const int captchaLength = 4;

            Random random = new Random();
            string captcha = new string(Enumerable.Repeat(characters, captchaLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return captcha;
        }

        public void ConfirmCaptcha(string expectedCaptcha)
        {
            string userCaptcha = "";
            do
            {
                Console.WriteLine("Unesite captcha: ");
                userCaptcha = Console.ReadLine();
            } while (!IsValidCaptcha(userCaptcha, expectedCaptcha));
        }

        static bool IsValidEmail(string email)
        {
            // Regular expression for a simple email validation
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            // Using Regex class to validate the email
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
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
        static bool ArePasswordsMatching(string password, string confirmPassword)
        {
            return password.Equals(confirmPassword);
        }

        static bool IsValidCaptcha(string userEnteredCaptcha, string expectedCaptcha)
        {
            return userEnteredCaptcha == expectedCaptcha;
        }

        static bool IsValidUsername(string username)
        {
            // Define the regex pattern for a valid username
            string pattern = "^[a-zA-Z0-9_]{4,20}$";

            // Use Regex.IsMatch to check if the username matches the pattern
            return Regex.IsMatch(username, pattern);
        }

        
    }
}

