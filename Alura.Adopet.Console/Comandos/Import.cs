using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    internal class Import : IComandos
    {
        public async Task ExecutarAsync(string[] args)
        {
            await this.ImportarPetsAsync(caminhoDoArquivo: args[1]);
        }

        private async Task ImportarPetsAsync(string caminhoDoArquivo)
        {
            LeitorDeArquivos leitor = new LeitorDeArquivos();
            var listaDePet = leitor.RealizaLeitura(caminhoDoArquivo);

            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                try
                {
                    var httpCreatePet = new HttpClientPet();
                    await httpCreatePet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }


    }
}
