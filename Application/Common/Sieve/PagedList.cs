namespace Application.Common.Sieve
{
    public class PagedList<TEntity>
    {
        public IQueryable<TEntity> Items { get; init; }
        public int CurrentPage { get; init; }
        public int TotalPages { get; init; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(IQueryable<TEntity> items, int currentPage, int pageSize, int totalCount)
        {
            Items = items;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}
