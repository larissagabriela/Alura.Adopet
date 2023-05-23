using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    [DocComando(
        instrucao: "help", 
        documentacao: "adopet help < parametro > ous simplemente adopet help  " +
                    "comando que exibe informações de ajuda dos comandos."
    )]
    internal class Help
    {
        private Dictionary<string, DocComando> docs;

        public Help()
        {
            docs =
                //... de todos os tipos do projeto em execução
                Assembly.GetExecutingAssembly().GetTypes()
                //...recupere somente aqueles que possuem o atributo DocComando
                .Where(t => t.GetCustomAttributes<DocComando>().Any())
                //...mapeie a lista de Type para uma lista de DocComando
                .Select(t => t.GetCustomAttribute<DocComando>()!)
                //...e converta para um dicionário!
                .ToDictionary(d => d.Instrucao);
        }

        public void Documentacao()
        {
            System.Console.WriteLine("Lista de comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            foreach(var cmd in docs.Values)
            {
                System.Console.WriteLine(cmd.Documentacao);
            }
            System.Console.WriteLine("Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n");
        }

        public void HelpDoComando(string comando)
        {
            if (docs.ContainsKey(comando))
            {
                var cmd = docs[comando];
                if (cmd != null)
                {
                    System.Console.WriteLine(cmd.Documentacao);
                }
            }
        }
    }
}
