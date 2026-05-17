using BigestWork.Logic;
using Font = System.Drawing.Font;

namespace BigestWork.Draw;

file static class Palette
{
    public static readonly (Color bg, Color border, Color text)[] Colors =
    [
        (Color.FromArgb(238, 237, 254), Color.FromArgb(175, 169, 236), Color.FromArgb(60, 52, 137)),
        (Color.FromArgb(225, 245, 238), Color.FromArgb(93, 202, 165),  Color.FromArgb(8,  80, 65)),
        (Color.FromArgb(250, 236, 231), Color.FromArgb(240, 153, 123), Color.FromArgb(74, 27, 12)),
        (Color.FromArgb(230, 241, 251), Color.FromArgb(133, 183, 235), Color.FromArgb(4,  44, 83)),
        (Color.FromArgb(234, 243, 222), Color.FromArgb(151, 196, 89),  Color.FromArgb(23, 52, 4)),
        (Color.FromArgb(250, 238, 218), Color.FromArgb(239, 159, 39),  Color.FromArgb(65, 36, 2)),
        (Color.FromArgb(251, 234, 240), Color.FromArgb(237, 147, 177), Color.FromArgb(75, 21, 40)),
    ];
}

public class AnimatedElement
{
    public bool IsHighlighted { get; set; }
    public string Value { get; }
    public float CurrentY { get; set; }  
    public float TargetY { get; set; } 
    public float Alpha { get; set; }  
    public float TargetAlpha { get; set; }
    public float OffsetX { get; set; } 
    public bool IsPopping { get; set; } 
    public (Color bg, Color border, Color text) Color { get; }

    public AnimatedElement(string value, float startY, float targetY, int colorIndex)
    {
        Value = value;
        CurrentY = startY;
        TargetY = targetY;
        Alpha = 0f;
        TargetAlpha = 255f;
        OffsetX = 0f;
        Color = Palette.Colors[colorIndex % Palette.Colors.Length];
    }
}

public class DrawUtility
{
    private readonly int _width;
    private readonly int _height;

    private readonly List<AnimatedElement> _elements = [];
    private int _colorCounter = 0;

    private const float Speed = 0.18f;

    public DrawUtility(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public int ElementCount => _elements.Count;

    public void SetHighlight(int index)
    {
        for (int i = 0; i < _elements.Count; i++)
            _elements[i].IsHighlighted = (i == index);
    }

    public void ClearHighlight()
    {
        foreach (var el in _elements)
            el.IsHighlighted = false;
    }

    public void AnimatePush(string value)
    {
        foreach (var el in _elements)
            el.TargetY += ElementStep;

        float targetY = TopY;
        float startY = targetY - 60f;

        var newEl = new AnimatedElement(value, startY, targetY, _colorCounter++);
        _elements.Insert(0, newEl);
    }

    public void AnimatePop()
    {
        if (_elements.Count == 0) return;

        var top = _elements[0];
        top.IsPopping = true;
        top.TargetAlpha = 0f;

        for (int i = 1; i < _elements.Count; i++)
            _elements[i].TargetY -= ElementStep;
    }


    public bool Tick()
    {
        bool animating = false;

        for (int i = _elements.Count - 1; i >= 0; i--)
        {
            var el = _elements[i];

            el.CurrentY = Lerp(el.CurrentY, el.TargetY, Speed);
            el.Alpha = Lerp(el.Alpha, el.TargetAlpha, Speed);

            if (el.IsPopping)
                el.OffsetX = Lerp(el.OffsetX, 120f, Speed);

            bool yDone = Math.Abs(el.CurrentY - el.TargetY) < 0.5f;
            bool aDone = Math.Abs(el.Alpha - el.TargetAlpha) < 1f;

            if (!yDone || !aDone) animating = true;

            if (el.IsPopping && aDone)
                _elements.RemoveAt(i);
        }

        return animating;
    }

    public Bitmap Draw()
    {
        var bmp = new Bitmap(_width, _height);

        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        g.Clear(Color.FromArgb(245, 244, 242));

        using var titleFont = new Font("Segoe UI", 11, FontStyle.Regular, GraphicsUnit.Point);
        g.DrawString("верх стека", titleFont,
            new SolidBrush(Color.FromArgb(140, 140, 135)),
            new PointF(_width / 2f - 42, 12));

        int x = _width / 2 - Element.Weight / 2;

        if (_elements.Count == 0)
        {
            using var emptyFont = new Font("Segoe UI", 12, FontStyle.Regular, GraphicsUnit.Point);
            var emptyBrush = new SolidBrush(Color.FromArgb(180, 180, 175));
            var rect = new RectangleF(0, _height / 2f - 20, _width, 40);
            var fmt = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString("Стек пуст", emptyFont, emptyBrush, rect, fmt);
        }

        using var font = new Font("Segoe UI", 13, FontStyle.Bold, GraphicsUnit.Point);
        using var indexFont = new Font("Segoe UI", 9, FontStyle.Regular, GraphicsUnit.Point);
        using var fmt2 = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        for (int i = 0; i < _elements.Count; i++)
        {
            var el = _elements[i];
            int alpha = (int)Math.Clamp(el.Alpha, 0, 255);
            int drawX = x + (int)el.OffsetX;
            int drawY = (int)el.CurrentY;

            using var shadowBrush = new SolidBrush(Color.FromArgb(alpha / 6, 0, 0, 0));
            g.FillRoundedRectangle(shadowBrush, drawX + 3, drawY + 4, Element.Weight, Element.Height, 10);

            var bg = Color.FromArgb(alpha, el.Color.bg);
            using var bgBrush = new SolidBrush(bg);
            g.FillRoundedRectangle(bgBrush, drawX, drawY, Element.Weight, Element.Height, 10);

            var borderColor = Color.FromArgb(alpha, el.Color.border);
            using var pen = new Pen(borderColor, 1.5f);
            g.DrawRoundedRectangle(pen, drawX, drawY, Element.Weight, Element.Height, 10);

            var textColor = Color.FromArgb(alpha, el.Color.text);
            using var textBrush = new SolidBrush(textColor);
            var textBounds = new RectangleF(drawX, drawY, Element.Weight, Element.Height);
            g.DrawString(el.Value, font, textBrush, textBounds, fmt2);

            var idxColor = Color.FromArgb(alpha / 2, el.Color.text);
            using var idxBrush = new SolidBrush(idxColor);
            g.DrawString($"#{_elements.Count - i}", indexFont, idxBrush,
                new PointF(drawX + Element.Weight - 24, drawY + 4));

            if (el.IsHighlighted)
            {
                using var highlightPen = new Pen(Color.FromArgb(alpha, Color.Gold), 3f);
                g.DrawRoundedRectangle(highlightPen, drawX - 2, drawY - 2, Element.Weight + 4, Element.Height + 4, 12);
            }
        }

        return bmp;
    }

    private float TopY => 50f;
    private float ElementStep => Element.Height + 12f;
    private static float Lerp(float a, float b, float t) => a + (b - a) * t;
}

file static class GraphicsExtensions
{
    public static void FillRoundedRectangle(this Graphics g, Brush brush, int x, int y, int w, int h, int r)
    {
        using var path = RoundedRect(x, y, w, h, r);
        g.FillPath(brush, path);
    }

    public static void DrawRoundedRectangle(this Graphics g, Pen pen, int x, int y, int w, int h, int r)
    {
        using var path = RoundedRect(x, y, w, h, r);
        g.DrawPath(pen, path);
    }

    private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(int x, int y, int w, int h, int r)
    {
        var path = new System.Drawing.Drawing2D.GraphicsPath();
        path.AddArc(x, y, r * 2, r * 2, 180, 90);
        path.AddArc(x + w - r * 2, y, r * 2, r * 2, 270, 90);
        path.AddArc(x + w - r * 2, y + h - r * 2, r * 2, r * 2, 0, 90);
        path.AddArc(x, y + h - r * 2, r * 2, r * 2, 90, 90);
        path.CloseFigure();
        return path;
    }
}
