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
            Console.WriteLine("1 - Cadastrar Leitor");
            Console.WriteLine("2 - Editar Leitor");
            Console.WriteLine("3 - Listar Leitores");
            Console.WriteLine("4 - Remover Leitor");
            Console.WriteLine("5 - Voltar");

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: CadastrarLeitor(); break;
                case 2: EditarLeitor(); break;
                case 3: ListarLeitor(); break;
                case 4: RemoverLeitor(); break;
            }

        } while (opcao != 5);
    }

    private void CadastrarLeitor()
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

private void ListarLeitor()
{
    Console.Clear();
    Console.WriteLine("=== LISTA DE LEITORES ===\n");

    var lista = repoLeitor.SelecionarTodos();

    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhum leitor cadastrado.");
    }
    else
    {
        foreach (var l in lista)
        {
            Console.WriteLine($"CPF: {l.Cpf}");
            Console.WriteLine($"Nome: {l.Nome}");
            Console.WriteLine($"Telefone: {l.Telefone}");
            Console.WriteLine("----------------------------");
        }
    }

    Console.WriteLine("\nPressione ENTER...");
    Console.ReadLine();
}

    private void RemoverLeitor()
    {
        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? "";

        repoLeitor.Remover(cpf);
    }
}