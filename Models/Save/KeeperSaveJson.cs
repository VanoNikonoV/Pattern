using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace Pattern.Models.Save
{
    public class KeeperSaveJson : IChordataSave
    {
        private string nameOfFile;

        public KeeperSaveJson(string NameOfFile)
        {
            this.nameOfFile = NameOfFile;
        }
        public void SaveAsChordatas(ObservableCollection<Chordata> animal, ObservableCollection<DataGridColumn> dataGridColumns)
        {
            string json = JsonConvert.SerializeObject(animal, Formatting.Indented);

            File.WriteAllText(nameOfFile, json);
        }
    }
}
