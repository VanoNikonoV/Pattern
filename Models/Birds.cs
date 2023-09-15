using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Models
{
    public class Birds:IChordata
    {
        public Birds()
        {
            
        }
        public Birds(string NameClass, string LivingEnvironment, int Size, string Detachment)
        {
            this.NameClass = NameClass;
            this.LivingEnvironment = LivingEnvironment;
            this.Size = Size;
            this.Detachment = Detachment;
        }
        public int ID { get; set; }
        public string NameClass { get; set; }
        public string LivingEnvironment { get; set; }
        public int Size { get; set; }
        public string Detachment { get; set; }

        public override string ToString() =>
        $"{this.NameClass} {this.LivingEnvironment} {this.NameClass} {this.Size}";
    }
}
