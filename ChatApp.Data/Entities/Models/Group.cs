namespace ChatApp.Data.Entities.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
        public ICollection<GroupMessage> GroupMessages { get; set; } = new List<GroupMessage>();
    }
}
