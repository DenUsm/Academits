using System.ComponentModel;

namespace TextUiView
{
    public enum MainMenu
    {
        [Description("Новая игра")]
        NewGame = 0,
        [Description("Сложность")]
        Lavel = 1,
        [Description("Правила")]
        Rule = 2,
        [Description("Рекорды")]
        HighScores = 3,
        [Description("Выход")]
        Exit = 4
    }
}
