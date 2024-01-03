namespace ChatApp.Data.Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
        public ICollection<PrivateMessage> SentPrivateMessages { get; set; } = new List<PrivateMessage>();
        public ICollection<PrivateMessage> ReceivedPrivateMesssages { get; set; } = new List<PrivateMessage>();
        //public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<GroupMessage> GroupMessages { get; set; } = new List<GroupMessage>();

    }
}
