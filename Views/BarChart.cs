using System.ComponentModel;
namespace SdaTithe.Views;

using SdaTithe.Services;
// A small bar chart drawn with GDI+. Also used to draw the chart on printed reports.
public class BarChart : Control
{
    private List<(string label, long value)> _data = new();

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string ChartTitle { get; set; } = "";

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowPercent { get; set; }

    public BarChart()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
    }

    public void SetData(IEnumerable<(string label, long value)> data)
    {
        _data = data.ToList();
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Draw(e.Graphics, ClientRectangle);
    }

    public void Draw(Graphics g, Rectangle area)
    {
        g.FillRectangle(Brushes.White, area);
        using var titleFont = new Font("Segoe UI", 10, FontStyle.Bold);
        using var font = new Font("Segoe UI", 8);
        g.DrawString(ChartTitle, titleFont, Brushes.Black, area.Left + 6, area.Top + 4);

        var plot = new Rectangle(area.Left + 10, area.Top + 34, area.Width - 20, area.Height - 58);
        if (plot.Width <= 0 || plot.Height <= 20) return;

        if (_data.Count == 0 || _data.All(d => d.value == 0))
        {
            g.DrawString(Localizer.T("No data for this selection."), font, Brushes.Gray, plot.Left, plot.Top + 10);
            return;
        }

        long max = _data.Max(d => d.value);
        long sum = _data.Sum(d => d.value);
        float slot = (float)plot.Width / _data.Count;
        float barW = Math.Max(3f, slot * 0.6f);
        int step = Math.Max(1, (int)Math.Ceiling(42f / slot));   // skip labels when bars are narrow

        g.DrawLine(Pens.Gray, plot.Left, plot.Bottom, plot.Right, plot.Bottom);

        for (int i = 0; i < _data.Count; i++)
        {
            float h = (float)_data[i].value / max * (plot.Height - 16);
            float x = plot.Left + i * slot + (slot - barW) / 2;
            float y = plot.Bottom - h;
            g.FillRectangle(Brushes.SteelBlue, x, y, barW, h);

            if (i % step != 0) continue;
            DrawCentered(g, font, _data[i].label, x + barW / 2, plot.Bottom + 3);
            if (_data[i].value > 0)
                DrawCentered(g, font, ValueText(_data[i].value, sum), x + barW / 2, y - 14);
        }
    }

    private static void DrawCentered(Graphics g, Font font, string text, float centerX, float y)
    {
        var size = g.MeasureString(text, font);
        g.DrawString(text, font, Brushes.Black, centerX - size.Width / 2, y);
    }

    private string ValueText(long value, long sum) =>
        ShowPercent ? (value * 100.0 / sum).ToString("0") + "%" : Short(value);

    private static string Short(long v) =>
        v >= 1_000_000 ? (v / 1_000_000.0).ToString("0.#") + "M"
        : v >= 1_000 ? (v / 1_000.0).ToString("0.#") + "k"
        : v.ToString();
}