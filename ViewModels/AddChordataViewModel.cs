using Pattern.Commands;
using Pattern.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Pattern.ViewModels
{
    public class AddChordataViewModel:ViewModel
    {
        #region Свойства
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

        /// <summary>
        /// Тип хордовые. Нужно вернуть эксземпляр после работы класса
        /// </summary>
        public IChordata Chordata { get => chordata; }

        /// <summary>
        /// Коллекчия ключ-значение для заполнения Combobox ключами, 
        /// а значения для корретной работы фабрики
        /// </summary>
        public Dictionary<string, Type> TypesForFactory { get;  private set; }

        /// <summary>
        /// Источник значений для Combobox
        /// </summary>
        public IEnumerable<string> NameClassTypeOpions { get; private set; }

        /// <summary>
        /// Устанавливает тип данных для фабрики
        /// </summary>
        public string NameClassType
        {
            get { return nameClassType; }

            set
            {
                if (nameClassType == value || String.IsNullOrEmpty(value)) return;
                nameClassType = value;

                if (nameClassType == "Млекопитающие")
                {
                    chordata = ChordataFactory.GetChordata(TypesForFactory["Млекопитающие"]);
                    chordata.NameClass = value;
                };
                if (nameClassType == "Земноводные")
                {
                    chordata = ChordataFactory.GetChordata(TypesForFactory["Земноводные"]);
                    chordata.NameClass = value;
                };
                if (nameClassType == "Птицы")
                {
                    chordata = ChordataFactory.GetChordata(TypesForFactory["Птицы"]);
                    chordata.NameClass = value;
                };
                if (nameClassType == "Неизвестный тип")
                {
                    chordata = ChordataFactory.GetChordata(TypesForFactory["Неизвестный тип"]);
                    chordata.NameClass = value;
                };

                base.OnPropertyChanged(nameof(NameClassType));

            }
        }

        #endregion

        private string nameClassType = "Млекопитающие"; //начальное значение

        private IChordata chordata = null;

        private Window _window;

        public AddChordataViewModel(Window window) // вторым параметром можно передать Dictionary<string, Type>()
        {
            this._window = window;

            //иницализация и заполнение коллекции
            TypesForFactory = new Dictionary<string, Type>
            {
                { "Млекопитающие", typeof(Mammals) },
                { "Земноводные", typeof(Amphibians) },
                { "Птицы", typeof(Birds) },
                { "Неизвестный тип", typeof(NullChordata) }
            };

            NameClassTypeOpions = TypesForFactory.Keys;
        }

        #region Команды

        private RelayCommand addChordataCommand = null!;
        public RelayCommand AddChordataCommand => addChordataCommand ?? (new RelayCommand(AddChordata, CanAddChordata));

       

        private RelayCommand cancelCommand = null!;
        public RelayCommand CancelCommand => cancelCommand ?? (new RelayCommand(Cancel));

        #endregion

        /// <summary>
        /// Корретность данных для существа
        /// </summary>
        /// <returns>true - если данные корретны, в противном случае - false</returns>
        private bool CanAddChordata()
        {
            if(!String.IsNullOrEmpty(this.LivingEnvironment) && !String.IsNullOrEmpty(this.Detachment))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Заверщение работы окна с подвержение нового существа
        /// </summary>
        private void AddChordata()
        {
            chordata.LivingEnvironment = this.LivingEnvironment;
            chordata.Size = this.Size;
            chordata.Detachment = this.Detachment;

            _window.DialogResult = true;
        }

        /// <summary>
        /// Закртытие окна бесподверждения сохранения
        /// </summary>
        private void Cancel() => _window.DialogResult = false;
    }
}
