namespace Application.Common.Sieve
{
    public class FilterTerm
    {
        public string ProperyName { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }

        public FilterOperator OperatorParsed
        {
            get
            {
                return GetOperatorParsed(Operator);
            }
        }

        private FilterOperator GetOperatorParsed(string @operator)
        {
            switch (@operator)
            {
                case "==":
                    return FilterOperator.Equals;
                case "!=":
                    return FilterOperator.NotEquals;
                case "<":
                    return FilterOperator.LessThan;
                case ">":
                    return FilterOperator.GreaterThan;                
                default:
                    return FilterOperator.Equals;
            }
        }
    }
}
