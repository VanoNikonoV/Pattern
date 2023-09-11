using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Models
{
    public static class ChordataFactory
    {
        public static IChordata GetChordata(string NameClass, string LivingEnvironment, int Size, string Detachment)
        {
            switch (NameClass) 
            {
                case "Млекопитающие": return new Mammals(NameClass, LivingEnvironment, Size, Detachment);

                case "Птицы": return new Birds(NameClass, LivingEnvironment, Size, Detachment);

                case "Земноводные": return new Amphibians(NameClass, LivingEnvironment, Size, Detachment);

                default: return new NullChordata();
            }
        }

    }
}
