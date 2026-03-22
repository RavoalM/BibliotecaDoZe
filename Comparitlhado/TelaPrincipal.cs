namespace Biblioteca;

public class TelaPrincipal
{
    public static void Intruducao()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("   ____   ___  _  __ ___     ____   ___  _  __ ___ ");
        Console.WriteLine("  |  _ \\ / _ \\| |/ /|_ _|   |  _ \\ / _ \\| |/ /|_ _|");
        Console.WriteLine("  | | | | | | | ' /  | |    | | | | | | | ' /  | | ");
        Console.WriteLine("  | |_| | |_| | . \\  | |    | |_| | |_| | . \\  | | ");
        Console.WriteLine("  |____/ \\___/|_|\\_\\|___|   |____/ \\___/|_|\\_\\|___|");


        Console.WriteLine("    --------------------     -------------------   ");
        Console.WriteLine("  /                       \\/                     \\ ");
        Console.WriteLine(" |                        ||                      |");
        Console.WriteLine(" |                        ||                      |");
        Console.WriteLine(" |                        ||                      |");
        Console.WriteLine(" |      SEJA BEM VINDO AO BIBLIOTECA DO LIVRO!!   |");
        Console.WriteLine(" |                        ||                      |");
        Console.WriteLine(" |                        ||                      |");
        Console.WriteLine(" |                        ||                      |");
        Console.WriteLine("  \\                       /\\                     / ");
        Console.WriteLine("    --------------------     -------------------   ");

        Thread.Sleep(7000);
        Console.ResetColor();
    }

    public char ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|         Bibilotecas Doki Doki        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Leitores");
        Console.WriteLine("2 - Controle de Livros");
        Console.WriteLine("3 - Controle de Emprestimos");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");

        string entrada = Console.ReadLine() ?? "";
        char opcaoEscolhida = entrada.Length > 0 ? entrada[0] : '0';

        return opcaoEscolhida;
    }
}
