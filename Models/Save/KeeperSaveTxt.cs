using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pattern.Models.Save
{
    /// <summary>
    /// Класс для сохраненияя данных о существах в формате .txt
    /// </summary>
    public class KeeperSaveTxt : KeeperSave
    {
        /// <summary>
        /// Коструктор для сохраненияя данных о существах в формате .txt
        /// </summary>
        /// <param name="NameOfFile">Имя файла</param>
        public KeeperSaveTxt(string NameOfFile): base(NameOfFile) {  }
   
        public override void SaveAsChordatasAsync(ObservableCollection<Chordata> animal, ObservableCollection<DataGridColumn> dataGridColumns)
        {
            string temp = String.Format("{0},{1},{2},{3},{4}",
                                dataGridColumns[0].Header.ToString(),
                                dataGridColumns[1].Header.ToString(),
                                dataGridColumns[2].Header.ToString(),
                                dataGridColumns[3].Header.ToString(),
                                dataGridColumns[4].Header.ToString());

            File.AppendAllText(this.NameOfFile, $"{temp}\n");

            for (int i = 0; i < animal.Count; i++)
            {
                temp = String.Format("{0},{1},{2},{3},{4}",
                                        animal[i].Id,
                                        animal[i].NameClass,
                                        animal[i].LivingEnvironment,
                                        animal[i].Size,
                                        animal[i].Detachment);
                File.AppendAllText(this.NameOfFile, $"{temp}\n");
            }
        }
    }
}
