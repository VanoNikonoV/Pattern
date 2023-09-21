using System;

namespace Pattern.Models.Save
{
    /// <summary>
    /// Статический класс с фабричным методом
    /// </summary>
    public static class KeeperSaveFactory
    {
        /// <summary>
        /// Фабричный метод создания KeeperSave
        /// </summary>
        /// <param name="NameClass">Type требуемого класса</param>
        /// <returns>Тип хранилища - abstract class KeeperSave </returns>
        public static KeeperSave GetKeeperSave(Type NameClass, string fileName)
        {
            return Activator.CreateInstance(NameClass, fileName) as KeeperSave;
        }
    }
}
