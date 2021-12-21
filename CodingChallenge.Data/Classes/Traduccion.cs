using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Traduccion
    {
        public string Lenguaje { get; set; }
        public string Key { get; set; }
        public bool Plural { get; set; }
        public string Texto { get; set; }
    }
}
