using System;
using System.Reflection;

namespace Pattern.Models.Save
{
    public static class KeeperSaveFactory
    {
        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <param name="NameClass">Type требуемого класса</param>
        /// <returns>Тип хранилища</returns>
        public static KeeperSave GetKeeperSave(Type NameClass, string fileName)
        {
            //System.Runtime.Remoting.ObjectHandle oh = Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().CodeBase,
            //                             NameClass.FullName);

            // return (KeeperSave)oh.Unwrap();


            return Activator.CreateInstance(NameClass, fileName) as KeeperSave;
        }
    }
}
