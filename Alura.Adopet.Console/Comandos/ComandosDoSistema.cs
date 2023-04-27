using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    internal class ComandosDoSistema
    {
        private readonly Dictionary<string, IComando> comandos = new()
        {
            { "import", new Import() },
            { "show", new Show() },
            { "list", new List() },
            { "help", new Help() },
        };

        public IComando? this[string comando] => comandos.ContainsKey(comando) ? comandos[comando] : null;
        
    }
}
