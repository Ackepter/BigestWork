namespace BigestWork.Draw;

public class DrawUtility
{
    private int _pictureWidth { get; set; }
    private int _pictureHeight { get; set; }

    public DrawUtility (int pictureWidth, int pictureHeight)
    {
        _pictureWidth = pictureWidth;
        _pictureHeight = pictureHeight;
    }

    public Bitmap? DrawElement(int x, int y)
    {
        Bitmap bmp = new(_pictureWidth, _pictureHeight);
        Graphics graphics = Graphics.FromImage(bmp);

        Element.DrawElement(graphics, x, y);

        return bmp;
    }
}
