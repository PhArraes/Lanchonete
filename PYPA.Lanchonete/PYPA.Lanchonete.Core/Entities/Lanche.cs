using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Lanchonete.Core
{
    public class Lanche : ILanche
    {
        public String Nome { get; private set; }
        public Int32 TempoDePreparo { get; private set; }

        public Lanche(string nome, int tempoDePreparo)
        {
            DefinirNome(nome);
            DefinirTempoDePreparo(tempoDePreparo);
        }

        public void DefinirNome(string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Nome inválido ");
            this.Nome = nome;
        }

        public void DefinirTempoDePreparo(Int32 tempo)
        {
            if (tempo < 0) throw new Exception("Tempo de preparo inválido");
            this.TempoDePreparo = tempo;
        }
    }
}
