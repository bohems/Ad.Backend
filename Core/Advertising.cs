using Sieve.Attributes;

namespace Domain
{
    public class Advertising
    {
        public Guid Id { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int Number { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Text { get; set; }

        public string? ImageUrl { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int Rating { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime CreationDate { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime ExpiryDate { get; set; }

        public Guid UserId { get; set; }
    }
}
