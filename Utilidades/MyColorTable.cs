namespace rknRallySlotApp.Utilidades;

public class MyColorTable(Color backColor, Color hoverColor, Color borderColor) : ProfessionalColorTable
{
    private readonly Color _backColor = backColor;
    private readonly Color _hoverColor = hoverColor;
    private readonly Color _borderColor = borderColor;

    // Fondo general de la barra
    public override Color ToolStripGradientBegin => _backColor;
    public override Color ToolStripGradientMiddle => _backColor;
    public override Color ToolStripGradientEnd => _backColor;
    public override Color MenuStripGradientBegin => _backColor;
    public override Color MenuStripGradientEnd => _backColor;

    // Color cuando pasas el ratón por encima (Hover) de un botón principal del menú
    public override Color MenuItemSelectedGradientBegin => _hoverColor;
    public override Color MenuItemSelectedGradientEnd => _hoverColor;

    // Color cuando el menú desplegable está abierto/activo
    public override Color MenuItemPressedGradientBegin => _hoverColor;
    public override Color MenuItemPressedGradientEnd => _hoverColor;

    // Fondo de los elementos dentro del desplegable (submenús) al pasar el ratón
    public override Color ButtonSelectedGradientBegin => _hoverColor;
    public override Color ButtonSelectedGradientEnd => _hoverColor;
    public override Color MenuItemSelected => _hoverColor;

    // Color de los bordes del menú y submenús
    public override Color MenuBorder => _borderColor;
    public override Color MenuItemBorder => _borderColor;
    public override Color ToolStripBorder => _borderColor;

    // Color de los bordes de la imagen de los elementos del menú
    public override Color ImageMarginGradientBegin => _backColor;
    public override Color ImageMarginGradientMiddle => _backColor;
    public override Color ImageMarginGradientEnd => _backColor;
}

