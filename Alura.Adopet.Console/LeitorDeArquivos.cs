using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    internal class LeitorDeArquivos
    {
        public List<Pet> RealizaLeitura(string caminhoDoArquivo)
        {
            List<Pet> listaDePet = new List<Pet>();

            using (StreamReader sr = new StreamReader(caminhoDoArquivo))
            {
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[] propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                      propriedades[1],
                      TipoPet.Cachorro
                     );
                    listaDePet.Add(pet);
                }

            }
            return listaDePet;
        }
    }
}
