using System.Data;
using System.Reflection;

namespace rknRallySlotApp.Utilidades;

public static class ExtensionesDataTable
{
    // Convierte cualquier List o IEnumerable a un DataTable para que el DataGridView pueda ordenarlo
    public static DataTable ToDataTable<T>(this IEnumerable<T> items)
    {
        var dataTable = new DataTable(typeof(T).Name);
        PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo prop in props)
        {
            // Soporte para tipos anulables (ej. int?)
            var tipoColumna = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
            dataTable.Columns.Add(prop.Name, tipoColumna);
        }

        foreach (T item in items)
        {
            var valores = new object[props.Length];
            for (int i = 0; i < props.Length; i++)
            {
                valores[i] = props[i].GetValue(item, null) ?? DBNull.Value;
            }
            dataTable.Rows.Add(valores);
        }

        return dataTable;
    }
}