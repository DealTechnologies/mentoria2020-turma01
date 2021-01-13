using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex10
{
    class Cliente : Pessoa
    {

        public override void qtdPessoas()
        {
            Console.WriteLine("Contando clientes..");
            base.qtdPessoas();
        }

    }
}
