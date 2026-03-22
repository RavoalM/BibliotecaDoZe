namespace Biblioteca;

public class TelaLeitor
{
    private RepositorioLeitor repoLeitor;

    public TelaLeitor(RepositorioLeitor repoLeitor)
    {
        this.repoLeitor = repoLeitor;
    }

    public void MostrarMenu()
    {
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("=== LEITORES ===");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Remover");
            Console.WriteLine("4 - Voltar");

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: Cadastrar(); break;
                case 2: Listar(); break;
                case 3: Remover(); break;
            }

        } while (opcao != 4);
    }

    private void Cadastrar()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? "";

        if (repoLeitor.CpfJaExiste(cpf))
        {
            Console.WriteLine("CPF já cadastrado!");
            Console.ReadLine();
            return;
        }

        Console.Write("Telefone: ");
        int telefone = int.Parse(Console.ReadLine()!);

        var leitor = new Leitor(nome, cpf, telefone);

        string erros = leitor.Validar();

        if (erros != "")
        {
            Console.WriteLine(erros);
            Console.ReadLine();
            return;
        }

        repoLeitor.Cadastrar(leitor);
    }

public void EditarLeitor()
    {
        Console.Clear();
        Console.WriteLine("=== EDITAR LEITOR ===\n");

        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? "";

        var leitor = repoLeitor.SelecionarPorCpf(cpf);

        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!");
            Console.ReadLine();
            return;
        }

        Console.Write("Novo Nome: ");
        leitor.Nome = Console.ReadLine() ?? "";

        Console.Write("Novo CPF: ");
       leitor.Cpf = Console.ReadLine() ?? "";

        Console.Write("Nova Telefone: ");
        leitor.Telefone = int.Parse(Console.ReadLine()!);

        Console.WriteLine("\nLeitor atualizado!");
    }

    private void Listar()
    {
        foreach (var l in repoLeitor.SelecionarTodos())
        {
            Console.WriteLine($"{l.Nome} - {l.Cpf}");
        }
        Console.ReadLine();
    }

    private void Remover()
    {
        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? "";

        repoLeitor.Remover(cpf);
    }
}