using Pattern.Commands;
using Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pattern.ViewModels
{
    public class AddChordataViewModel:ViewModel
    {
        /// <summary>
        /// Имя класса 
        /// </summary>
        public string NameClass { get; set; }

        /// <summary>
        /// Среда обитания
        /// </summary>
        public string LivingEnvironment { get; set; }

        /// <summary>
        /// Численность существ в классе
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Отряд
        /// </summary>
        public string Detachment { get; set; }


        private IChordata chordata;
        public IChordata Chordata { get => chordata; } 

        private Window _window;
        /// <summary>
        /// Массив доступных классов
        /// </summary>
        public string[] NameClassTypeOpions { get => nameClassTypeOpions;  }

        private readonly string[] nameClassTypeOpions;

        private string nameClassType;

        public string NameClassType 
        { 
            get { return nameClassType; }
            set
            {
                if (nameClassType == value || String.IsNullOrEmpty(value)) return;
                nameClassType = value;

                //if (nameClassType == NameClassOpions[0])
                //{ 
                //    nameClassType = NameClassOpions[0];
                //};
                base.OnPropertyChanged(nameof(NameClassType));

            }
        }

        public AddChordataViewModel(Window window)
        {
            this._window = window;

            nameClassTypeOpions = new string[] { "Земноводные", "Млекопитающие", "Птицы", "Неизвестный тип"};

            nameClassType = nameClassTypeOpions[1];
        }

        #region Команды

        private RelayCommand addChordataCommand = null!;
        public RelayCommand AddChordataCommand => addChordataCommand ?? (new RelayCommand(AddChordata));


        private RelayCommand cancelCommand = null!;
        public RelayCommand CancelCommand => cancelCommand ?? (new RelayCommand(Cancel));

        #endregion

        /// <summary>
        /// Заверщение работы окна с подвержение нового клиента
        /// </summary>
        private void AddChordata()
        {
             chordata = ChordataFactory.GetChordata(this.NameClass, this.LivingEnvironment, this.Size, this.Detachment);

            _window.DialogResult = true;
        }

        /// <summary>
        /// Закртытие окна бесподверждения сохранения клиента
        /// </summary>
        private void Cancel() => _window.DialogResult = false;
    }
}
