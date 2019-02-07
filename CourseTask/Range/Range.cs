namespace Range
{
    class Range
    {
        public double From { get; set; }
        public double To { get; set; }

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

        public Range GetIntersection(Range interval)
        {
            if (interval.IsInside(From))
            {
                return new Range(From, interval.To);
            }
            else if (interval.IsInside(To))
            {
                return new Range(interval.From, To);
            }
            else
            {
                return null;
            }
        }
    }
}
