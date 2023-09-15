using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Pattern.Commands;
using Pattern.DataSource;
using Pattern.Models;
using Pattern.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Pattern.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public ChordataContext? ChordataContext { get; private set; }

        private ObservableCollection<Chordata>? reposipory;

        public ObservableCollection<Chordata>? Reposipory 
        { 
            get 
            {  
                if (reposipory == null && ChordataContext != null) 
                {
                    ChordataContext.Chordata.Load();
                    reposipory = ChordataContext?.Chordata.Local.ToObservableCollection();
                }
                return reposipory; 
            } 
        }

        public MainWindowViewModel()
        {
            ChordataContext = new();

            ChordataContext.Database.EnsureCreated();

            //this.reposipory = new ObservableCollection<IChordata>();

            //Random random = new Random();

            //for (int i = 0; i < 15; i++)
            //{
            //    switch (random.Next(4))
            //    {
            //        case 0: reposipory.Add(new Mammals("Млекопитающие", "Суша", 6500, "Лев")); break;

            //        case 1: reposipory.Add(new Birds("Птицы", "Воздух", 8400, "Ворона")); break;

            //        case 2: reposipory.Add(new Amphibians("Земноводные", "Суша", 4578, "Питон")); break;

            //        default: reposipory.Add(new NullChordata()); break;
            //    }
            //}
        }

        private RelayCommand addCommand = null;

        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddChordata));

        private async void AddChordata()
        {
            AddChordataWindow addChordataWindow = new AddChordataWindow()
            { Owner = Application.Current.MainWindow };

            AddChordataViewModel add = new(addChordataWindow); 

            addChordataWindow.DataContext = add;

            addChordataWindow.ShowDialog();

            if (addChordataWindow.DialogResult == true)
            {
                await ChordataContext.Chordata.AddAsync(add.Chordata);

                await ChordataContext.SaveChangesAsync();
                //Reposipory.Add(add.Chordata);
            }
        }

        //private void SaveRepo()
        //{
        //    var saveDlg = new SaveFileDialog
        //    {
        //        Filter = "Text files|*.json",
        //        InitialDirectory = Directory.GetCurrentDirectory()
        //    };

        //    if (true == saveDlg.ShowDialog())
        //    {
        //        string fileName = saveDlg.FileName;

        //        string json = JsonConvert.SerializeObject(BankRepository, Formatting.Indented);

        //        File.WriteAllText(fileName, json);

        //        foreach (var client in BankRepository as List<BankClient<Account>>)
        //        {
        //            client.Owner.IsChanged = false;

        //            AllClients.Refresh();
        //        }
        //    }

        //    string json2 = JsonConvert.SerializeObject(BankRepository.LogClient, Formatting.Indented);

        //    File.WriteAllText(pathLog, json2);
        //}

    }
}
