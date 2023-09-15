using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Models
{
    public class Birds:Chordata
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
    

        public override string ToString() =>
        $"{this.NameClass} {this.LivingEnvironment} {this.NameClass} {this.Size}";
    }
}
