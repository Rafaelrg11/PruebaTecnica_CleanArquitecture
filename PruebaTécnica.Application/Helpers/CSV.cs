using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Helpers;

public class CSV
{
    public static string ConvertToCsv<T1, T2>(IEnumerable<T1> firstList, IEnumerable<T2> secondList)
    {
        var sb = new StringBuilder();

        // Generar la primera tabla
        if (firstList.Any())
        {
            sb.AppendLine(ConvertSingleListToCsv(firstList));
        }

        // Agregar una línea en blanco para separar las tablas
        sb.AppendLine();

        // Generar la segunda tabla
        if (secondList.Any())
        {
            sb.AppendLine(ConvertSingleListToCsv(secondList));
        }

        return sb.ToString();
    }

    private static string ConvertSingleListToCsv<T>(IEnumerable<T> items)
    {
        if (items == null || !items.Any())
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        var type = typeof(T);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Encabezados
        sb.AppendLine(string.Join(",", properties.Select(p => p.Name)));

        // Filas
        foreach (var item in items)
        {
            var values = properties.Select(p =>
            {
                var value = p.GetValue(item, null);
                return value != null ? value.ToString().Replace(",", " ") : string.Empty;
            });
            sb.AppendLine(string.Join(",", values));
        }

        return sb.ToString();
    }
}

