namespace rknRallySlotApp.Utilidades;

// La clase DEBE ser "public static" para que se pueda usar en todo el proyecto sin hacer un "new"
public static class ImgTools
{
    /// <summary>
    /// Redimensiona una imagen simulando el efecto Zoom para encajar en el tamaño de destino.
    /// </summary>
    // 💡 TRUCO PRO: Al poner la palabra clave "this" antes del primer parámetro (this Image imagenOriginal),
    // transformas esta función en un MÉTODO DE EXTENSIÓN.
    public static Image Zoom(this Image imgOriginal, int anchoDestino, int altoDestino)
    {
        Bitmap bmp = new(anchoDestino, altoDestino);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            // Alta calidad de escalado
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // Calcular la proporción (Efecto Zoom)
            float ratio = Math.Min((float)anchoDestino / imgOriginal.Width, (float)altoDestino / imgOriginal.Height);
            int nuevoAncho = (int)(imgOriginal.Width * ratio);
            int nuevoAlto = (int)(imgOriginal.Height * ratio);

            // Centrar la imagen dentro del nuevo lienzo
            int x = (anchoDestino - nuevoAncho) / 2;
            int y = (altoDestino - nuevoAlto) / 2;

            g.DrawImage(imgOriginal, x, y, nuevoAncho, nuevoAlto);
        }
        return bmp;
    }

    public static void CfgBotonIcono(this Button boton, Image imagen)
    {
        boton.Image = imagen.Zoom(boton.Width - 5, boton.Height - 5);
        boton.ImageAlign = ContentAlignment.MiddleCenter;
    }
}
