using System.Text.RegularExpressions;

namespace Application.Common.Sieve
{
    public class SieveModel
    {
        public string? Searching { get; set; }
        public string? Filters { get; set; }
        public string? SortProperty { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public List<FilterTerm> GetFiltersParsed()
        {
            if (Filters == null)
            {
                return null;
            }
            else
            {
                string filters = Regex.Replace(Filters, @"\s", string.Empty);
                string[] filtersArray = filters.Split(',');
                var regex = new Regex("=|<|>");

                var result = new List<FilterTerm>();

                foreach (var item in filtersArray)
                {
                    var match = regex.Match(item);

                    if (match.Success)
                    {
                        string[] options = item.Split(match.Value);

                        var filterTerm = new FilterTerm()
                        {
                            ProperyName = options[0],
                            Value = options[1],
                            Operator = match.Value
                        };

                        result.Add(filterTerm);
                    }
                }

                return result;
            }
        }
    }
}