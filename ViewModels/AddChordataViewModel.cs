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
    public class AddChordataViewModel
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

        public AddChordataViewModel(Window window)
        {
            this._window = window;
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
