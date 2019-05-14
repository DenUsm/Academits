using System.ComponentModel;

namespace TextUiView
{
    public enum MainMenu
    {
        [Description("Новая игра")]
        NewGame = 0,
        [Description("Правила")]
        Rule = 1,
        [Description("Рекорды")]
        HighScores = 2,
        [Description("О программе")]
        About = 3,
        [Description("Выход")]
        Exit = 4,
    }
}
