using System.ComponentModel;

namespace ModelGame
{
    public enum Level
    {
        [Description("Новичок")]
        Beginner = 0,
        [Description("Любитель")]
        Medium = 1,
        [Description("Профессионал")]
        Professional = 2
    }
}
