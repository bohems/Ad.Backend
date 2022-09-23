namespace Domain
{
    public class Ad
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public string? ImageUrl { get; set; }
        public int Rating { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Guid UserId { get; set; }
    }
}
