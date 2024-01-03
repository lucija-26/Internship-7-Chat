namespace ChatApp.Data.Entities.Models
{
    public class GroupMessage
    {
        public int GroupMessageId { get; set; }
        public int SenderId { get; set; }
        public int GroupId { get; set; }
        public string? Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
