

using ChatApp.Data.Entities.Models;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;

namespace ChatApp.Presentation.Actions
{
    public class Login : IAction
    {
        private readonly UserRepository UserRepository;
        private static User? user1 = null;
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Login";

        public Login(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public void Open()
        {
            Console.WriteLine("Input your email: ");
            var email = Console.ReadLine();
            Console.WriteLine("Input your password: ");
            var password = Console.ReadLine();
            var user = UserRepository.GetByEmail(email);
            if(user != null && user.Password == password)
            {
                Console.WriteLine("Successfully logged in.");
                user1 = user;
                //Menu actions
            }
        }
    }
}
