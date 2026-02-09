using System;

namespace DSVSerializer.Core;

/// <summary>
/// Атрибут для игнорирования свойства в сериализации
/// </summary>
public class DsvIgnoreAttribute : Attribute
{
    /// <summary>
    /// Свойство, указывающее, нужно ли игнорировать свойство.
    /// Установить в false через конструктор, если свойство нужно сериализовать.
    /// </summary>
    public bool Ignore { get; private set; }

    /// <summary>
    /// Конструктор атрибута игнорирования свойства в сериализации.
    /// По умолчанию игнорируется. Но можно указать, что свойство не нужно игнорировать.
    /// </summary>
    /// <param name="ignore">Значение, указывающее, нужно ли игнорировать свойство.</param>
    public DsvIgnoreAttribute(bool ignore = true)
    {
        Ignore = ignore;
    }
}