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
    internal class Help : IComando
    {
        private readonly Dictionary<string, string> comandos = new();
        public Help()
        {
            Assembly
                // no projeto atual...
                .GetExecutingAssembly()
                // ...pegue todos os tipos...
                .GetTypes()
                // ...que possuem o atributo DocComando...
                .Where(t => t.GetCustomAttributes<Utils.DocComando>().Any())
                // ...e transforme a lista de Type -> DocComando
                .Select(t => t.GetCustomAttribute<Utils.DocComando>())
                // ...execute em memória
                .ToList()
                // ...para cada DocComando..
                .ForEach(doc =>
                {
                    if (doc != null)
                    {
                        // ... adicione no dicionário
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

        public Task ExecuteAsync(string[] args)
        {
            if (args.Length == 2)
            {
                this.HelpDoComando(comando: args[1]);
            }
            else
            {
                this.Documentacao();
            }
            return Task.CompletedTask;
        }
    }
}
