using System.ComponentModel;

namespace TextUiView
{
    public enum GameManagment
    {
        [Description("Z - Отметить/Убрать миину")]
        Flag = 0,
        [Description("X - Открыть ячейку")]
        Open = 1,
        [Description("Esc - Выйти в главное меню")]
        Back = 2
    }
}
