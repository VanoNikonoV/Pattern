using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace Pattern.Models.Save
{
    public class KeeperSaveExel : IChordataSave
    {
        private string nameOfFile;

        public KeeperSaveExel(string NameOfFile)
        {
            this.nameOfFile = NameOfFile;
        }
        public async void SaveAsChordatas(ObservableCollection<Chordata> animal, ObservableCollection<DataGridColumn> dataGridColumns)
        {
            string temp = String.Format("{0},{1},{2},{3},{4}",
                               dataGridColumns[0].Header.ToString(),
                               dataGridColumns[1].Header.ToString(),
                               dataGridColumns[2].Header.ToString(),
                               dataGridColumns[3].Header.ToString(),
                               dataGridColumns[4].Header.ToString());

            await File.AppendAllTextAsync(nameOfFile, $"{temp}\n");

            for (int i = 0; i < animal.Count; i++)
            {
                temp = String.Format("{0},{1},{2},{3},{4}",
                                        animal[i].Id,
                                        animal[i].NameClass,
                                        animal[i].LivingEnvironment,
                                        animal[i].Size,
                                        animal[i].Detachment);
                await File.AppendAllTextAsync(nameOfFile, $"{temp}\n");
            }
        }
    }
}
