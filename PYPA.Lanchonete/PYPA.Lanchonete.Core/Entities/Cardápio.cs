using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PYPA.Lanchonete.Core
{
    public class Cardápio
    {
        public List<Lanche> Lanches { get; private set; }

        public Cardápio()
        {
            this.Lanches = new List<Lanche>();
        }

        public void AdicionarLanche(Lanche lanche)
        {
            if (lanche == null) throw new Exception("Tentativa de adicionar lanche inválido");
            var lancheExistente = Lanches.FirstOrDefault(l => l.Nome == lanche.Nome);
            if (lancheExistente == null) Lanches.Add(lanche);
            else lancheExistente.DefinirTempoDePreparo(lanche.TempoDePreparo);
        }
    }
}
