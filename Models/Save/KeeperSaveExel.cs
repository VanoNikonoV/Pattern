using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Windows.Controls;

namespace Pattern.Models.Save
{
    /// <summary>
    /// Класс для сохраненияя данных о существах в формате .csv
    /// </summary>
    public class KeeperSaveExel : KeeperSave
    {
        /// <summary>
        /// Коструктор для сохраненияя данных о существах в формате .csv
        /// </summary>
        /// <param name="NameOfFile">Имя файла</param>
        public KeeperSaveExel(string NameOfFile) : base(NameOfFile) { }
      
        public override async void SaveAsChordatasAsync(ObservableCollection<Chordata> animal, ObservableCollection<DataGridColumn> dataGridColumns)
        {
            using (StreamWriter sw = new StreamWriter(NameOfFile, false, Encoding.Unicode))
            {
                for (int i = 0; i < dataGridColumns.Count; i++)
                {
                    await sw.WriteAsync($"{dataGridColumns[i].Header}\t");
                }

                for (int i = 0; i < animal.Count; i++)
                {
                    await sw.WriteAsync($"\n{animal[i].Id}\t");
                    await sw.WriteAsync($"{animal[i].NameClass}\t");
                    await sw.WriteAsync($"{animal[i].LivingEnvironment}\t"); 
                    await sw.WriteAsync($"{animal[i].Size}\t");
                    await sw.WriteAsync($"{animal[i].Detachment}\t");
                }
            }
        }
    }
}
