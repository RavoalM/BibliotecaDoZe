//Alvaro Machado Feltrin e Enzo Rosa Fernandes
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
    Console.Clear();
    Console.WriteLine("=== CADASTRO DE LEITOR ===\n");

    var leitor = new Leitor();

    while (true)
    {
        try
        {
            Console.Write("Nome: ");
            leitor.Nome = Console.ReadLine() ?? "";
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    while (true)
    {
        try
        {
            Console.Write("\nCPF: ");
            string input = Console.ReadLine() ?? "";

            leitor.Cpf = input; 

            if (repoLeitor.CpfJaExiste(leitor.Cpf))
                throw new Exception("\nCPF já cadastrado!");

            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro: {ex.Message}");
        }
    }

    while (true)
    {
        try
        {
            Console.Write("\nIdade: ");

            if (!int.TryParse(Console.ReadLine(), out int idade))
                throw new Exception("Digite um número válido.");

            leitor.Idade = idade;
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    repoLeitor.Cadastrar(leitor);

    Console.WriteLine("\nLeitor cadastrado com sucesso!");
    Console.ReadLine();
}

public void EditarLeitor()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR LEITOR ===\n");

    Console.Write("CPF atual: ");
    string cpf = Console.ReadLine() ?? "";

    var leitor = repoLeitor.SelecionarPorCpf(cpf);

    if (leitor == null)
    {
        Console.WriteLine("Leitor não encontrado!");
        Console.ReadLine();
        return;
    }

    Console.WriteLine("\nDeixe vazio para manter o valor atual.\n");

    var leitorAtualizado = new Leitor();


    while (true)
    {
        try
        {
            Console.Write($"\nNovo Nome ({leitor.Nome}): ");
            string input = Console.ReadLine() ?? "";

            leitorAtualizado.Nome = string.IsNullOrWhiteSpace(input) 
                ? leitor.Nome 
                : input;

            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro: {ex.Message}");
        }
    }

    while (true)
    {
        try
        {
            Console.Write($"\nNovo CPF ({leitor.Cpf}): ");
            string input = Console.ReadLine() ?? "";

            leitor.Cpf = input; 

            if (repoLeitor.CpfJaExiste(leitor.Cpf))
                throw new Exception("\nCPF já cadastrado!");

            leitorAtualizado.Cpf = string.IsNullOrWhiteSpace(input) 
                ? leitor.Cpf 
                : input;

            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro: {ex.Message}");
        }
    }

    while (true)
    {
        try
        {
            Console.Write($"\nNova Idade ({leitor.Idade}): ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                leitorAtualizado.Idade = leitor.Idade;
            }
            else
            {
                if (!int.TryParse(input, out int idade))
                    throw new Exception("\nErro: Digite um número válido.");

                leitorAtualizado.Idade = idade;
            }

            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro: {ex.Message}");
        }
    }

    repoLeitor.EditarLeitor(cpf, leitorAtualizado);

    Console.WriteLine("\nLeitor atualizado com sucesso!");
    Console.ReadLine();
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
                Console.WriteLine($"Idade: {l.Idade}");
                Console.WriteLine("----------------------------");
            }
        }

        Console.WriteLine("\nPressione ENTER...");
        Console.ReadLine();
    }

    private void RemoverLeitor()
    {
        Console.Clear();
        Console.WriteLine("=== REMOVER LEITOR ===\n");

        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? "";

        repoLeitor.Remover(cpf);

        Console.WriteLine("\nOperação concluída!");
        Console.ReadLine();
    }
}