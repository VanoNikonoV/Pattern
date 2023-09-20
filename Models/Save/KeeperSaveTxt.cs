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
    public class KeeperSaveTxt : KeeperSave
    {
        private string nameOfFile;
        public KeeperSaveTxt(string NameOfFile): base(NameOfFile) {  }
   
        public override void SaveAsChordatas(ObservableCollection<Chordata> animal, ObservableCollection<DataGridColumn> dataGridColumns)
        {
            string temp = String.Format("{0},{1},{2},{3},{4}",
                                dataGridColumns[0].Header.ToString(),
                                dataGridColumns[1].Header.ToString(),
                                dataGridColumns[2].Header.ToString(),
                                dataGridColumns[3].Header.ToString(),
                                dataGridColumns[4].Header.ToString());

            File.AppendAllText(nameOfFile, $"{temp}\n");

            for (int i = 0; i < animal.Count; i++)
            {
                temp = String.Format("{0},{1},{2},{3},{4}",
                                        animal[i].Id,
                                        animal[i].NameClass,
                                        animal[i].LivingEnvironment,
                                        animal[i].Size,
                                        animal[i].Detachment);
                File.AppendAllText(nameOfFile, $"{temp}\n");
            }
        }
    }
}
