using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;


namespace ChatApp.Presentation.Actions
{
    public class DisplayUsersChats : IAction
    {
        private readonly PrivateMessageRepository PrivateMessageRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Ispis svih korisnika s kojim si komunicirao";

        public DisplayUsersChats(PrivateMessageRepository directMessageRepository)
        {
            PrivateMessageRepository = directMessageRepository ?? throw new ArgumentNullException(nameof(directMessageRepository));
        }

        public void Open()
        {
            var activeUser = Login.GetCurrentUser();

            var interactions = PrivateMessageRepository.GetUsersInteractions(activeUser.UserId);

            if (interactions.Count == 0)
            {
                Console.WriteLine("Inbox empty.");
            }
            else
            {
                Console.WriteLine("Your interactions: ");

                foreach (var user in interactions)
                {
                    Console.WriteLine($"User ID: {user.UserId}, Email: {user.Email}");
                }
            }
        }
    }

}
