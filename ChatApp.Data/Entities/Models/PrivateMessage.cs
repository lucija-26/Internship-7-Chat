
namespace ChatApp.Data.Entities.Models
{
    public class PrivateMessage
    {
        public int PrivateMessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string? Message { get; set; }
        public DateTime DateTime { get; set; }

        public User? Sender { get; set; }
        public User? Receiver { get; set; }

    }
}
