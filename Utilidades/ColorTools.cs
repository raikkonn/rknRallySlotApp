namespace rknRallySlotApp.Utilidades;

public static class ColorTools
{
    /// <summary>
    /// Determina si el mejor contraste para un color de fondo es Blanco o Negro.
    /// </summary>
    /// <param name="colorFondo">El color de fondo analizado.</param>
    /// <returns>Color.White o Color.Black según convenga.</returns>
    public static Color GetBestContrast(Color colorFondo)
    {
        // 1. Aplicar la fórmula estándar W3C para luminancia relativa (sRGB)
        double r = CorregirGamma(colorFondo.R / 255.0);
        double g = CorregirGamma(colorFondo.G / 255.0);
        double b = CorregirGamma(colorFondo.B / 255.0);

        double luminancia = 0.2126 * r + 0.7152 * g + 0.0722 * b;

        // 2. Si la luminancia es mayor a 0.5 (color claro), el texto debe ser negro.
        // De lo contrario (color oscuro), el texto debe ser blanco.
        return luminancia > 0.5 ? Color.Black : Color.White;
    }

    private static double CorregirGamma(double c)
    {
        return (c <= 0.03928) ? c / 12.92 : System.Math.Pow((c + 0.055) / 1.055, 2.4);
    }
}