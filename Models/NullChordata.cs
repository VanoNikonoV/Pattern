using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Models
{
    internal class NullChordata:Chordata
    {
        public NullChordata() 
        {
            this.NameClass = "Неизвестный класс";
            this.LivingEnvironment = "Неизвестная среда";
            this.Size = default;
            this.Detachment = "Без названия";
        }

        public override string ToString() =>
        $"{this.NameClass} {this.LivingEnvironment} {this.NameClass} {this.Size}";
    }
}
