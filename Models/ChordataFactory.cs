using System;

namespace Pattern.Models
{
    /// <summary>
    /// Статические класс содержащий фабричный метод для типов хордовые
    /// </summary>
    public static class ChordataFactory
    {
        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <param name="NameClass">Type требуемого класса</param>
        /// <returns>Тип хордовые</returns>
        public static Chordata GetChordata(Type NameClass)
        {
            return Activator.CreateInstance(NameClass) as Chordata;
        }
    }
}
