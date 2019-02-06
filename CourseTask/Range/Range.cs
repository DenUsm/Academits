namespace Range
{
    class Range
    {
        public double From { get; set; }
        public double To { get; set; }

        public Range()
        {

        }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLenght()
        {
            return To - From;
        }

        public bool IsInside(double doubleValue)
        {
            return ((doubleValue >= From) && (doubleValue <= To));
        }

        public Range GetIntersection(Range first, Range second)
        {
            if(first.IsInside(second.From))
            {
                return new Range(second.From, first.To);
            }
            else if (first.IsInside(second.To))
            {
                return new Range(first.From, second.To);
            }
            else
            {
                return null;
            }
        }
    }
}
