using Biblioteca;

public class Program
{
    static void Main()
    {
        var repoLivro = new RepositorioLivro();
        var repoLeitor = new RepositorioLeitor();
        var repoEmp = new RepositorioEmprestimo();

        var telaLivro = new TelaLivro(repoLivro);
        var telaLeitor = new TelaLeitor(repoLeitor);
        var TelaEmprestimo = new TelaEmprestimo(repoEmp, repoLeitor, repoLivro);

        int opcao;

        do
        {
            TelaPrincipal.Intruducao();
            TelaPrincipal.MostrarMenu();
            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: telaLivro.MostrarMenu(); break;
                case 2: telaLeitor.MostrarMenu(); break;
                case 3: TelaEmprestimo.MostrarMenu(); break;
            }

        } while (opcao != 4);
    }
}