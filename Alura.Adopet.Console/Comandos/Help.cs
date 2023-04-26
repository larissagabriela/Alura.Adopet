using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    [Utils.DocComando(Instrucao = "help", Documentacao = "adopet help [comando] para obter mais informações sobre um comando.")]
    internal class Help
    {
        private readonly Dictionary<string, string> comandos = new();
        public Help()
        {
            Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetCustomAttributes<Utils.DocComando>().Any())
                .Select(t => t.GetCustomAttribute<Utils.DocComando>())
                .ToList()
                .ForEach(doc =>
                {
                    if (doc != null)
                    {
                        comandos.Add(doc.Instrucao, doc.Documentacao);
                    }
                });
        }

        public void Documentacao()
        {
            System.Console.WriteLine("Lista de comandos.");
            System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                    "comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            foreach(var cmd in comandos)
            {
                System.Console.WriteLine("\t" + cmd.Value);
            }

        }

        public void HelpDoComando(string comando)
        {
            System.Console.WriteLine("\t" + comandos[comando]);
        }
    }
}
