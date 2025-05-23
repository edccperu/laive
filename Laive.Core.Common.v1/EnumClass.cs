using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laive.Core.Common
{
    public class EnumConectorFilter
    {
        public const string CONTIENE = "like";
        public const string IGUAL = "=";
        public const string DIFERENTE = "<>";
        public const string MENOR = "<";
        public const string MENORIGUAL = "<=";
        public const string MAYOR = ">";
        public const string MAYORIGUAL = ">=";
        public const string IN = "in";
        public const string RANGO = "Between";
    }
}
