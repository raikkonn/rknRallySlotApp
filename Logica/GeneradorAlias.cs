using rknRallySlotApp.Datos;
using System.Globalization;
using System.Text;

namespace rknRallySlotApp.Logica;

public class GeneradorAlias
{
    private readonly AppDbContext db;

    public GeneradorAlias(AppDbContext context)
    {
        db = context;
    }

    /// <summary>
    /// Genera un alias único de EXACTAMENTE 3 caracteres para un piloto.
    /// Si detecta duplicados en la BD, intenta sustituir la 3.ª letra de atrás hacia adelante
    /// y, como último recurso, recurre a un sufijo numérico recortando la base.
    /// </summary>
    public string GenerarAliasUnico(string nombreEntrada)
    {
        if (string.IsNullOrWhiteSpace(nombreEntrada))
            return string.Empty;

        // 1. Limpiar acentos y pasar a mayúsculas
        string textoLimpio = RemoverAcentos(nombreEntrada.Trim().ToUpper());

        // Manejo de entradas con menos de 3 caracteres: se paddea a 3 posiciones
        if (textoLimpio.Length < 3)
        {
            textoLimpio = textoLimpio.PadRight(3, 'X');
        }

        // 2. Tomar los 3 primeros caracteres como base inicial
        char primera = textoLimpio[0];
        char segunda = textoLimpio[1];
        char tercera = textoLimpio[2];

        string candidatoInicial = $"{primera}{segunda}{tercera}";

        // Comprobación inicial
        if (!ExisteAliasEnBD(candidatoInicial))
        {
            return candidatoInicial;
        }

        // 3. Sustitución del 3.er carácter probando las letras de la entrada desde el final hacia atrás
        for (int i = textoLimpio.Length - 1; i >= 3; i--)
        {
            char letraSustitucion = textoLimpio[i];
            string candidato = $"{primera}{segunda}{letraSustitucion}";

            if (!ExisteAliasEnBD(candidato))
            {
                return candidato;
            }
        }

        // 4. Fallback numérico (manteniendo estrictamente 3 caracteres)
        return ResolverDuplicadoNumerico(candidatoInicial);
    }

    /// <summary>
    /// Sustituye los caracteres finales del alias base por un sufijo numérico 
    /// garantizando que la longitud resultante sea SIEMPRE de 3 caracteres.
    /// </summary>
    private string ResolverDuplicadoNumerico(string baseAlias)
    {
        int contador = 1;
        string candidato;

        do
        {
            string numeroStr = contador.ToString();
            int digitos = numeroStr.Length;

            // Si el número requiere 3 dígitos o más (p. ej. 100), se usará solo el número (hasta 999)
            if (digitos >= 3)
            {
                candidato = numeroStr.Substring(0, 3);
            }
            else
            {
                // Se conservan (3 - dígitos) caracteres de la base y se concatena el número
                string baseRecortada = baseAlias.Substring(0, 3 - digitos);
                candidato = $"{baseRecortada}{numeroStr}";
            }

            contador++;
        }
        while (ExisteAliasEnBD(candidato));

        return candidato;
    }

    /// <summary>
    /// Consulta si el alias existe en la tabla de Pilotos de la BD.
    /// </summary>
    private bool ExisteAliasEnBD(string alias)
    {
        return db.Pilotos.Any(p => p.Alias == alias);
    }

    /// <summary>
    /// Remueve tildes y diacríticos usando normalización FormD.
    /// </summary>
    private static string RemoverAcentos(string texto)
    {
        string textoNormalizado = texto.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();

        foreach (char c in textoNormalizado)
        {
            UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
            if (uc != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }

        return sb.ToString().Normalize(NormalizationForm.FormC);
    }
}




