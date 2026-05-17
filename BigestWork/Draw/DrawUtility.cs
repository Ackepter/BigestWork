using BigestWork.Base;
using BigestWork.Logic;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace BigestWork.Draw;

public class DrawUtility
{
    private ActionWithStack _stack;
    private LinkedList<string> _list;
    private int _pictureWidth { get; set; }
    private int _pictureHeight { get; set; }

    public DrawUtility (int pictureWidth, int pictureHeight)
    {
        _pictureWidth = pictureWidth;
        _pictureHeight = pictureHeight;
    }

    public void SetStack(ActionWithStack stack)
    {
        if(stack != null) _stack = stack;
    }

    public Bitmap? DrawElements()
    {
        Bitmap bmp = new(_pictureWidth, _pictureHeight);

        using (Graphics graphics = Graphics.FromImage(bmp))
        using (Pen pen = new Pen(Color.Black))
        using (var font = new Font("Segoe UI", 14, FontStyle.Bold))
        using (var brush = new SolidBrush(Color.Yellow))
        using (var format = new StringFormat())
        {
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            _list = _stack.GetCopyOfInnerList();

            int x = _pictureWidth / 2 - Element.Weight / 2;
            int y = 50;
            int step = 30 + Element.Height;

            var temp = _list.First;
            
            while (y < _pictureHeight && temp != null)
            {
                Element.DrawElement(graphics, pen, x, y);

                RectangleF textBounds = new RectangleF(x, y, Element.Weight, Element.Height);

                graphics.DrawString(temp.Value, font, brush, textBounds, format);

                y += step;
                temp = temp.Next;
            }
        }

        return bmp;
    }
}
