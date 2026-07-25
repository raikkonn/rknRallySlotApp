using System;
using System.Collections.Generic;
using System.Text;

namespace rknRallySlotApp.Utilidades
{
    public static partial class Helpers
    {
        /// <summary>
        /// Intenta obtener un valor int desde un string.
        /// </summary>
        public static bool EsEnteroValido(string texto, out int resultado)
        {
            return int.TryParse(texto.Trim(), out resultado);
        }

        /// <summary>
        /// Intenta obtener un valor decimal desde un string tolerando coma y punto.
        /// </summary>
        public static bool EsDecimalValido(string texto, out decimal resultado)
        {
            texto = texto.Trim().Replace('.', ',');
            return decimal.TryParse(texto, out resultado);
        }
    }
}
