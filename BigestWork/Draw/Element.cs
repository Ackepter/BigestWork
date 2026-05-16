namespace BigestWork.Draw;
public static class Element
{
    private static int _height = 60;
    private static int _weight = 120;

    public static void DrawElement(Graphics graphics, int x, int y)
    {
        Pen pen = new Pen(Color.Black);

        graphics.DrawRectangle(pen, x, y, _weight, _height);
    }
}
