﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Models
{
    public class Mammals : IChordata
    {
        /// <summary>
        /// Конструктор для добавления существа в класса млекопитающих
        /// </summary>
        /// <param name="NameClass">Имя класса</param>
        /// <param name="LivingEnvironment">Среда обитания</param>
        /// <param name="Size">Численность существ в классе</param>
        /// <param name="Detachment">Отряд</param>
        public Mammals(string NameClass, string LivingEnvironment, int Size, string Detachment)
        {
            this.NameClass = NameClass;
            this.LivingEnvironment = LivingEnvironment; 
            this.Size = Size;   
            this.Detachment = Detachment;
        }
        public Mammals()
        {
            
        }

        public string NameClass { get; set; }
        public string LivingEnvironment { get; set ; }
        public int Size { get ; set; }
        public string Detachment { get; set; }

        public override string ToString() =>
        $"{this.NameClass} {this.LivingEnvironment} {this.NameClass} {this.Size}";
        

    }
}
