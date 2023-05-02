using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alura.Adopet.Console
{    
    internal class Help
    {
        private Dictionary<string, object> comandos;
        private string Documentacao { get; set; } = "$ adopet help [comando] para obter mais informações sobre um comando.";

        public Help()
        {
            comandos = new()
                    {
                        { "import", new Import() },
                        { "show", new Show() },
                        { "list", new List() }                   
                    };

        }

        private string RecuperaDocumentacao(object comando)
        {
            Type tipoComando = comando.GetType();
            var doc = tipoComando.GetCustomAttributes<DocComando>().FirstOrDefault();
            if (doc is not null) return doc.Documentacao;
            return string.Empty;
        }
          
        public void ExibeDocumentacao()
        {
            var retorno = new List<string>();
            System.Console.WriteLine("Lista de comandos.");
            // se não passou mais nenhum argumento mostra help de todos os comandos
            System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                    "comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            System.Console.WriteLine(this.Documentacao);
            foreach (var cmd in comandos)
            {                
               System.Console.WriteLine(this.RecuperaDocumentacao(cmd.Value));
            }

            //return retorno;
        }
        public void HelpDoComando(string comando)
        {
            var retorno = new List<string>();
            var cmd = comandos[comando];
            if (cmd is not null)
                System.Console.WriteLine(this.RecuperaDocumentacao(cmd));

            //return retorno;
        }


    }
}
