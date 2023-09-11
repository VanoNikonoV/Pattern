using Pattern.Commands;
using Pattern.Models;
using Pattern.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pattern.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<IChordata>? Reposipory { get; set; }

        public MainWindowViewModel()
        {
            this.Reposipory = new ObservableCollection<IChordata>();

            Random random = new Random();

            for (int i = 0; i < 15; i++)
            {
                switch (random.Next(4))
                {
                    case 0: Reposipory.Add(new Mammals("Млекопитающие", "Суша", 6500, "Лев")); break;

                    case 1: Reposipory.Add(new Birds("Птицы", "Воздух", 8400, "Ворона")); break;

                    case 2: Reposipory.Add(new Amphibians("Земноводные", "Суша", 4578, "Питон")); break;

                    default: Reposipory.Add(new NullChordata()); break;
                }
            }
        }

        private RelayCommand addCommand = null;

        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddChordata));

        private void AddChordata()
        {
            AddChordataWindow addChordataWindow = new AddChordataWindow()
            { Owner = Application.Current.MainWindow };

            AddChordataViewModel add = new(addChordataWindow); 

            addChordataWindow.DataContext = add;

            addChordataWindow.ShowDialog();

            if (addChordataWindow.DialogResult == true)
            {
                Reposipory.Add(add.Chordata);
            }
        }
    }
}
