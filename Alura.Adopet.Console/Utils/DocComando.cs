namespace Alura.Adopet.Console.Utils
{
    internal class DocComando : Attribute
    {
        public string Instrucao { get; set; } = string.Empty;
        public string Documentacao { get; set; } = string.Empty;
    }
}
