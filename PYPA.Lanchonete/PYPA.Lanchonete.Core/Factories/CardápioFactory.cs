using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Lanchonete.Core.Factories
{
    public class CardápioFactory
    {
        public Cardápio Create(List<ILanche> lanches){
            if (lanches == null || lanches.Count == 0) throw new Exception("Não é possível criar um cardápio sem lanches");
            var cardápio = new Cardápio();
            lanches.ForEach(l => {
                cardápio.AdicionarLanche(new Lanche(l.Nome, l.TempoDePreparo));
            });
            return cardápio;
        }
    }
}
