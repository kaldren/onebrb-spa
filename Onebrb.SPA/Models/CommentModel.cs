namespace Onebrb.SPA.Models
{
    public class CommentModel
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string RecipientId { get; set; }

        public string RecipientFirstName { get; set; }

        public string RecipientLastName { get; set; }

        public string PhotoUrl { get; set; } = "https://placekitten.com/200/200";

        public short StarRating { get; set; } = 5;

        public DateTimeOffset Date { get; set; }
    }
}
