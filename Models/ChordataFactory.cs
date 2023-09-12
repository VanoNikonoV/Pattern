using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pattern.Models
{
    public static class ChordataFactory
    {
        //private readonly List<Type> chotdataType = new List<Type>()
        //{
        //    typeof(Mammals),
        //    typeof(Amphibians),
        //    typeof(Birds),
        //    typeof(NullChordata)
        //};

        public static IChordata GetChordata(string NameClass)
        {

            //System.Runtime.Remoting.ObjectHandle oh =
            //Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().CodeBase,
            //                             typeof(Mammals).FullName);

            //// Call an instance method defined by the SomeType type using this object.
            //IChordata st = (IChordata)oh.Unwrap();

            //return st;

            return Activator.CreateInstance(typeof(Mammals)) as IChordata;
        }

    }
}
