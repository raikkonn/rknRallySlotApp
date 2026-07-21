using System.Globalization;
using System.Text.RegularExpressions;

namespace rknRallySlotApp.Utilidades
{
    public static partial class TxtTools
    {
        // Define la expresión regular como un método parcial generado en compilación
        [GeneratedRegex(@"\s+")]
        private static partial Regex LimpiaEspaciosRegex();

        /// <summary>
        /// Limpia espacios y tabuladores duplicados usando el Regex generado en compilación.
        /// </summary>
        public static string TrimCleanAndTitle(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;
            else
                // Reemplaza usando el método generado
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LimpiaEspaciosRegex().Replace(texto.Trim(), " ").ToLower());

        }

        /// <summary>
        /// Limpia espacios y tabuladores duplicados usando el Regex generado en compilación.
        /// </summary>
        public static string TrimAndClean(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;
            else
                // Reemplaza usando el método generado
                return LimpiaEspaciosRegex().Replace(texto.Trim(), " ");
        }
    }
}

