using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Pattern.Models.Save
{
    public interface IChordataSave
    {
        void SaveAsChordatas(ObservableCollection<Chordata> animal, ObservableCollection<DataGridColumn> dataGridColumns);
    }
}
