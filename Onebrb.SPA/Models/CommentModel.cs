namespace Onebrb.SPA.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public long AuthorId { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string PhotoUrl { get; set; } = "https://placekitten.com/200/200";

        public short StarRating { get; set; } = 5;

        public DateTimeOffset Date { get; set; }
    }
}
