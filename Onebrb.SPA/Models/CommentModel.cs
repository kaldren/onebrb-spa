namespace Onebrb.SPA.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; } = "https://placekitten.com/200/200";
    }
}
