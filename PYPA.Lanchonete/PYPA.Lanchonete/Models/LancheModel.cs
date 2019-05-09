using PYPA.Lanchonete.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PYPA.Lanchonete.Models
{
    public class LancheModel : ILanche
    {
        public String Nome { get; set; }
        public int TempoDePreparo { get; set; }
    }
}
