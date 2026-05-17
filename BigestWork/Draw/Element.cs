namespace BigestWork.Draw;
public static class Element
{
    public static int Height { get; } = 60;
    public static int Weight { get; } = 120;

    public static void DrawElement(Graphics graphics, Pen pen, int x, int y)
    {
        graphics.DrawRectangle(pen, x, y, Weight, Height);
    }
}
