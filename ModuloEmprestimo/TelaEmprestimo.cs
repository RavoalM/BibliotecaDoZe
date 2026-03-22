namespace Biblioteca;

public class TelaEmprestimo
{
    private RepositorioEmprestimo repoEmp;
    private RepositorioLeitor repoLeitor;
    private RepositorioLivro repoLivro;

    public TelaEmprestimo(RepositorioEmprestimo e, RepositorioLeitor l, RepositorioLivro li)
    {
        repoEmp = e;
        repoLeitor = l;
        repoLivro = li;
    }

      public void MostrarMenu()
    {
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("=== EMPRESTIMOS ===\n");
            Console.WriteLine("1 - Realizar Emprestimo");
            Console.WriteLine("2 - Realizar Devolução");
            Console.WriteLine("3 - Verificar Leitores com livros");
            Console.WriteLine("4 - Buscar livro emprestado");

            Console.WriteLine("5 - Voltar\n");

            while (!int.TryParse(Console.ReadLine(), out opcao))
                Console.Write("Inválido: ");

            switch (opcao)
            {
                case 1: Emprestar(); break;
                case 2: Devolver(); break;
                case 3: ListarComLivros(); break;
                case 4: BuscarLivroEmprestado(); break;
            }

        } while (opcao != 3);
    }
    private void Emprestar()
    {
        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? "";

        Console.Write("ID Livro: ");
        int id = int.Parse(Console.ReadLine()!);

        var leitor = repoLeitor.SelecionarPorCpf(cpf);
        var livro = repoLivro.SelecionarPorId(id);

        if (leitor != null && livro != null)
        {
            repoEmp.Emprestar(leitor, livro);
        }
    }

    private void Devolver()
    {
        Console.Write("ID Livro: ");
        int id = int.Parse(Console.ReadLine()!);

        var livro = repoLivro.SelecionarPorId(id);

        if (livro != null)
            repoEmp.Devolver(livro);
    }

    private void ListarComLivros()
    {
        foreach (var l in repoLeitor.SelecionarTodos())
        {
            Console.WriteLine($"\n{l.Nome}");

            foreach (var e in repoEmp.SelecionarTodos())
            {
                if (e.Leitor == l)
                    Console.WriteLine($"- {e.Livro.Titulo}");
            }
        }

        Console.ReadLine();
    }

    private void BuscarLivroEmprestado()
    {
        Console.Write("ID Livro: ");
        int id = int.Parse(Console.ReadLine()!);

        var emp = repoEmp.BuscarPorLivro(id);

        if (emp != null)
            Console.WriteLine($"Está com: {emp.Leitor.Nome}");
        else
            Console.WriteLine("Livro não encontrado.");

        Console.ReadLine();
    }
}