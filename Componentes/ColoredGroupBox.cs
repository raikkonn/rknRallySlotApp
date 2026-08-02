using System.ComponentModel;

namespace rknRallySlotApp.Componentes;

public class ColoredGroupBox : GroupBox
{
    private Color _borderColor = Color.Black;

    [Category("Appearance")]
    [Description("Color del borde del GroupBox")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

    public Color BorderColor
    {
        get => _borderColor;
        set
        {
            _borderColor = value;
            this.Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Color borderColor = this.Enabled ? _borderColor : Color.Gray;

        using Pen pen = new(borderColor, 1);
        if (string.IsNullOrEmpty(this.Text))
        {
            // Si el texto está vacío, dibujamos el rectángulo completo (con un pequeño margen superior de 4px)
            Rectangle rect = new Rectangle(0, 4, this.ClientSize.Width - 1, this.ClientSize.Height - 5);
            g.DrawRectangle(pen, rect);
        }
        else
        {
            // Si hay texto, calculamos el espacio y dejamos el hueco superior para el título
            Size tSize = TextRenderer.MeasureText(this.Text, this.Font);
            Rectangle rect = new(0, tSize.Height / 2, this.ClientSize.Width - 1, this.ClientSize.Height - (tSize.Height / 2));

            // Dibujar el rectángulo del borde
            g.DrawRectangle(pen, rect);

            // Limpiar el fondo detrás del texto para que la línea superior no lo atraviese
            Rectangle textRect = new(10, 0, tSize.Width, tSize.Height);
            using (SolidBrush brushBack = new(this.BackColor))
            {
                g.FillRectangle(brushBack, textRect);
            }

            // Dibujar el texto del GroupBox
            using SolidBrush brushText = new(ForeColor);
            g.DrawString(this.Text, this.Font, brushText, textRect.X, textRect.Y);
        }
    }

    // Métodos de serialización estándar para el diseñador de Visual Studio
    public bool ShouldSerializeBorderColor()
    {
        return _borderColor != Color.Black;
    }

    public void ResetBorderColor()
    {
        _borderColor = Color.Black;
    }
}
