using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Pattern.Commands;
using Pattern.DataSource;
using Pattern.Models;
using Pattern.View;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using Pattern.Models.Save;
using System.Windows;

namespace Pattern.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public ChordataContext? ChordataContext { get; private set; }

        private ObservableCollection<Chordata>? reposipory;

        /// <summary>
        /// Коллекция с существаими полученная из базы данных
        /// </summary>
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

            //ChordataContext.Database.EnsureDeleted();

            ChordataContext.Database.EnsureCreated(); 
        }

        #region Команды

        private RelayCommand addCommand = null;
        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddChordataAsync));


        private RelayCommandT<Chordata> deleteCommand = null;
        public RelayCommandT<Chordata> DeleteCommand => 
            deleteCommand ?? (deleteCommand = new RelayCommandT<Chordata>(DeletChordata, CanDeletChordata));


        private RelayCommandT<Chordata> editCommand = null;
        public RelayCommandT<Chordata> EditCommand => 
            editCommand ?? (editCommand = new RelayCommandT<Chordata>(EditChordataAsync, CanEditChordata));


        private RelayCommandT<ObservableCollection<DataGridColumn>> saveCommand = null;
        public RelayCommandT<ObservableCollection<DataGridColumn>> SaveCommand =>
            saveCommand ?? (saveCommand = new RelayCommandT<ObservableCollection<DataGridColumn>>(SaveData));

        

        #endregion

        #region Методы
        /// <summary>
        /// Добавления существа
        /// </summary>
        private async void AddChordataAsync()
        {
            AddChordataWindow addChordataWindow = new AddChordataWindow()
            { Owner = System.Windows.Application.Current.MainWindow };

            AddChordataViewModel add = new(addChordataWindow); 

            addChordataWindow.DataContext = add;

            addChordataWindow.ShowDialog();

            if (addChordataWindow.DialogResult == true)
            {
                await ChordataContext.Chordata.AddAsync(add.Chordata);

                await ChordataContext.SaveChangesAsync();
            }
        }

        private bool CanDeletChordata(Chordata selectedChordata) => selectedChordata != null ? true : false;

        /// <summary>
        /// Удаляет выделенное существо
        /// </summary>
        /// <param name="customer"></param>
        private void DeletChordata(Chordata selectedChordata)
        {
            ChordataContext.Chordata.Remove(selectedChordata);

            ChordataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Включение/выключение кнопки в зависимость от условий:
        /// - наличие изменений в данных EntityState.Modified
        /// </summary>
        /// <param name="chordata">Выбранное существо</param>
        /// <returns>true - если сhordata не null, иначе false</returns>
        private bool CanEditChordata(Chordata chordata)
        {
            if (chordata != null)
            {
                return ChordataContext.Entry(chordata).State == EntityState.Modified ? true : false;   
            }
            return false;
        }

        /// <summary>
        /// Метод изменния данных о существе
        /// </summary>
        /// <param name="chordata">Выбранное существо</param>
        private async void EditChordataAsync(Chordata chordata)
        {
            ChordataContext.Chordata.Update(chordata);

            await ChordataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод сохранения данных в разных форматах
        /// </summary>
        /// <param name="dataGridColumns">Колекция столбцов таблицы</param>
        private void SaveData(ObservableCollection<DataGridColumn> dataGridColumns)
        {
            var saveDlg = new SaveFileDialog
            {
                Filter = "Документ Word|*.docx|Документ Exel|*.csv|Обычный тексты|*.txt",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (true == saveDlg.ShowDialog())
            {
                string fileName = saveDlg.FileName;

                switch (saveDlg.FilterIndex)
                {
                    case 1:

                        //KeeperSaveWord keeperSaveWord = new KeeperSaveWord(fileName);
                        KeeperSave keeperSaveWord = KeeperSaveFactory.GetKeeperSave(typeof(KeeperSaveWord), fileName);

                        keeperSaveWord.SaveAsChordatasAsync(Reposipory, dataGridColumns);

                        break;

                    case 2:

                        //KeeperSaveExel keeperSaveExel = new KeeperSaveExel(fileName);
                        KeeperSave keeperSaveExel = KeeperSaveFactory.GetKeeperSave(typeof(KeeperSaveExel), fileName);

                        keeperSaveExel.SaveAsChordatasAsync(Reposipory, dataGridColumns);

                        break;

                    case 3:

                        KeeperSave keeperSaveTxt = KeeperSaveFactory.GetKeeperSave(typeof(KeeperSaveTxt), fileName);

                        keeperSaveTxt.SaveAsChordatasAsync(Reposipory, dataGridColumns);

                    break;

                    default: MessageBox.Show("Данный формат не доступен", 
                                    "Неверный выбор", 
                                    MessageBoxButton.OK, 
                                    MessageBoxImage.Exclamation); 
                                    break;
                }
            }
           
            
        }
        #endregion
    }
}
