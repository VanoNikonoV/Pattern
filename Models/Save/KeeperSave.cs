using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pattern.Models.Save
{
    public abstract class KeeperSave : IChordataSave
    {
        private string nameOfFile;
        public KeeperSave(string NameOfFile)
        {
            this.nameOfFile = NameOfFile;
        }

        public virtual void SaveAsChordatas(ObservableCollection<Chordata> animal, ObservableCollection<DataGridColumn> dataGridColumns)
        {
            throw new NotImplementedException();
        }
    }
}
