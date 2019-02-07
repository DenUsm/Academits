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
            Range res = new Range(From, To);

            if (interval.IsInside(From))
            {
                if(interval.IsInside(To))
                {
                    return res;
                }
                res.To = interval.To;
                return res;
            }
            if(res.IsInside(interval.From))
            {
                if(res.IsInside(interval.To))
                {
                    return interval;
                }
                res.From = interval.From;
                return res;
            }
            return null;
        }

        //public Range [] GetUnion(Range interval)
        //{
        //    Range intersectionInterval = interval.GetIntersection(new Range(From, To));
        //    if(intersectionInterval == null)
        //    {
        //        return new Range[] { interval, new Range(From, To) }; 
        //    }
        //    else
        //    {
        //
        //    }
        //}
    }
}
