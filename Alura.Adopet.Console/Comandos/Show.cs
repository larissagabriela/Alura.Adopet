using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Comandos
{
    [Utils.DocComando(Instrucao = "show", Documentacao = "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show : IComando
    {
        public Task ExecuteAsync(string[] args)
        {
            this.MostrarArquivo(caminhoDoArquivo: args[1]);
            return Task.CompletedTask;
        }

        public void MostrarArquivo(string caminhoDoArquivo)
        {
            LeitorDeArquivos leitor = new LeitorDeArquivos();
            var listaDePets = leitor.RealizaLeitura(caminhoDoArquivo);

            foreach (Pet pet in listaDePets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
