using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Pattern.Models.Save
{
    /// <summary>
    /// Абстрактный класс для сохраненияя данных о существах 
    /// </summary>
    public abstract class KeeperSave : IChordataSave
    {
        /// <summary>
        /// Имя файла для сохранения
        /// </summary>
        public string NameOfFile { get; private set; }
        public KeeperSave(string NameOfFile)
        {
            this.NameOfFile = NameOfFile;
        }

        /// <summary>
        /// Метод сохранения данных о существах
        /// </summary>
        /// <param name="animal">Коллекция существ</param>
        /// <param name="dataGridColumns">Коллекция колонок из DataGride</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void SaveAsChordatasAsync(ObservableCollection<Chordata> animal, ObservableCollection<DataGridColumn> dataGridColumns)
        {
            throw new NotImplementedException();
        }
    }
}
