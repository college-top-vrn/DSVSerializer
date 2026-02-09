using System.Reflection;
using System.Text;

namespace DSVSerializer.Core;

/// <summary>
/// Класс для сериализации объектов в DSV формат
/// </summary>
public static class DsvSerializer
{
    /// <summary>
    /// Сериализует объект в DSV формат.
    /// Первая строка - имена полей, вторая - значения полей.
    /// Сериализует только свойства класса
    /// </summary>
    /// <param name="obj">Объект для сериализации</param>
    /// <param name="delimiter">Разделитель между значениями, по умолчанию "|"</param>
    /// <typeparam name="T">Тип объекта для сериализации</typeparam>
    /// <returns>Сериализованный объект в виде строки</returns>
    public static string Serialize<T>(T obj, string delimiter = "|")
    {
        //var type = typeof(T);
        var type = obj.GetType();
        var properties = type.GetProperties();
        
        var builderForNames = new StringBuilder();
        foreach (var propertyInfo in properties)
        {
            var ignoreAttribute = propertyInfo.GetCustomAttribute<DsvIgnoreAttribute>();
            //if (ignoreAttribute != null && ignoreAttribute.Ignore) continue;
            if (ignoreAttribute is { Ignore: true }) continue;
            
            var name = propertyInfo.Name;
            builderForNames.Append($"{name}{delimiter}");
        }
        
        var builderForValues = new StringBuilder();
        foreach (var propertyInfo in properties)
        {
            var ignoreAttribute = propertyInfo.GetCustomAttribute<DsvIgnoreAttribute>();
            if (ignoreAttribute is { Ignore: true }) continue;
            
            var value = propertyInfo.GetValue(obj);
            builderForValues.Append($"{value}{delimiter}");
        }
        
        var result = $"{builderForNames}\n{builderForValues}";
        return result;
    }
}