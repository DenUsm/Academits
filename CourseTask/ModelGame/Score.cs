namespace ModelGame
{
    public class Score
    {
        public string Name { get; set; }
        public int TimeResult { get; set; }

        public Score(string name, int timeResult)
        {
            Name = name;
            TimeResult = timeResult; 
        }
    }
}
