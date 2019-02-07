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
            if ((interval.From > To) || (interval.To < From))
            {
                return null;
            }
            return new Range(GetMax(From, interval.From), GetMin(To, interval.To));
        }

        private double GetMax(double firstValue, double secondValue)
        {
            return (firstValue > secondValue) ? firstValue : secondValue;
        }

        private double GetMin(double firstValue, double secondValue)
        {
            return (firstValue > secondValue) ? secondValue : firstValue;
        }

        public Range[] GetUnion(Range interval)
        {
            Range currentInterval = new Range(From, To);
            Range intersectionInterval = interval.GetIntersection(currentInterval);

            if (intersectionInterval == null)
            {
                return new Range[] { interval, currentInterval };
            }
            return new Range[] { new Range(GetMin(currentInterval.From, interval.From), GetMax(currentInterval.To, interval.To)) };
        }

        public Range[] GetDifference(Range interval)
        {
            Range currentInterval = new Range(From, To);
            Range intersectionInterval = interval.GetIntersection(currentInterval);

            if (intersectionInterval == null)
            {
                return new Range[] { currentInterval };
            }
            else if ((interval.From > currentInterval.From) && (interval.To > currentInterval.To))
            {
                return new Range[] { new Range(currentInterval.From, interval.From) };
            }
            else if ((interval.From < currentInterval.From) && (interval.To < currentInterval.To))
            {
                return new Range[] { new Range(interval.To, currentInterval.To) };
            }
            else if ((currentInterval.From < interval.From) && (currentInterval.To > interval.To))
            {
                return new Range[] { new Range(currentInterval.From, interval.From), new Range(interval.To, currentInterval.To) };
            }
            return null;
        }

    }
}
