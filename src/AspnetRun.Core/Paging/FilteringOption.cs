namespace AspnetRun.Core.Paging
{
    public class FilteringOption
    {
        public string Field { get; set; }

        public FilteringOperator Operator { get; set; }

        public object Value { get; set; }

        public enum FilteringOperator
        {
            //Empty,
            Contains,
            Not_Contains,
            LT,
            LE,
            GT,
            GE,
            NE,
            EQ,
            StartsWith,
            EndsWith,
            RangeInclusive,
            RangeExclusive,
            IN,
            NOT_IN,
            IN_CONTAINS,
            NOT_IN_CONTAINS
        }
    }
}
