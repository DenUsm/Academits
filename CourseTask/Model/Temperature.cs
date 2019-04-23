namespace Model
{
    class Temperature
    {
        public string Scale { get; set; }
        private double Value { get; set; }

        public Temperature(string scale)
        {
            Scale = scale;
        }
    }
}
