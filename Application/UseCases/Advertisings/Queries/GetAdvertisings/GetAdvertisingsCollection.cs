namespace Application.UseCases.Advertisings.Queries.GetAdvertisings
{
    public class GetAdvertisingsCollection
    {
        public IList<GetAdvertisingsElement> Advertisings { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get { return (int)Math.Ceiling(CurrentPage / (double)PageSize); } }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
