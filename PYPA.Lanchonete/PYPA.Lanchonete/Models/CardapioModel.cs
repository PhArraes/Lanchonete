using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PYPA.Lanchonete.Models
{
    public class CardapioModel
    {
        public String Nome { get; set; }
        public List<LancheModel> Lanches { get; set; }
    }
}
