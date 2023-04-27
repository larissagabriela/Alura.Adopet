using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Comandos;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    var comando = args[0].Trim();
    var comandos = new ComandosDoSistema();
    IComando? cmd = comandos[comando];
    if (cmd == null ) Console.WriteLine("Comando inválido!");
    else await cmd.ExecuteAsync(args);
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