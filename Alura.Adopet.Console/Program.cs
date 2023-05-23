using Alura.Adopet.Console.Comandos;

Dictionary<string, IComando> comandosDoSistema = new()
{
    {"help", new Help() },
    {"list", new List() },
    {"import", new Import() },
    {"show", new Show() }
};

Console.ForegroundColor = ConsoleColor.Green;
try
{
    // args[0] é o comando a ser executado pelo programa
    IComando? comando = comandosDoSistema[args[0]];
    if (comando != null) await comando.ExecutarAsync(args);
    else Console.WriteLine("Comando inválido");

}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}