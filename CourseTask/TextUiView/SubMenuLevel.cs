using System.ComponentModel;

namespace TextUiView
{
    public enum SubMenuLevel
    {
        [Description("Новичок")]
        Beginner = 0,
        [Description("Любитель")]
        Medium = 1,
        [Description("Профессионал")]
        Professional = 2,
        [Description("Особые")]
        Special = 3,
        [Description("Назад")]
        Back = 4
    }
}
