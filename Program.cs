using Biblioteca;

class Program
{
    static void Main()
    {
        var repoLivro = new RepositorioLivro();
        var repoLeitor = new RepositorioLeitor();

        var telaLivro = new TelaLivro(repoLivro);
        var telaLeitor = new TelaLeitor(repoLeitor);

        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("1 - Livros");
            Console.WriteLine("2 - Leitores");
            Console.WriteLine("3 - Sair");

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: telaLivro.MostrarMenu(); break;
                case 2: telaLeitor.MostrarMenu(); break;
            }

        } while (opcao != 3);
    }
}