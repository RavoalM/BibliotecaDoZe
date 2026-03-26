//Alvaro Machado Feltrin e Enzo Rosa Fernandes
namespace Biblioteca;

public class TelaLivro
{
    private RepositorioLivro repoLivro;

    public TelaLivro(RepositorioLivro repoLivro)
    {
        this.repoLivro = repoLivro;
    }

    public void MostrarMenu()
    {
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("=== LIVROS ===");
            Console.WriteLine("1 - Cadastrar Livro");
            Console.WriteLine("2 - Editar Livro");
            Console.WriteLine("3 - Listar Livros");
            Console.WriteLine("4 - Remover Livro");
            Console.WriteLine("5 - Voltar");

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: CadastrarLivro(); break;
                case 2: EditarLivro(); break;
                case 3: ListarLivro(); break;
                case 4: RemoverLivro(); break;
            }

        } while (opcao != 5);
    }

    private void CadastrarLivro()
    {
        Console.Clear();
        Console.WriteLine("=== CADASTRO DE LIVRO ===\n");
        Console.Write("Título: ");
        string titulo = Console.ReadLine() ?? "";

        Console.Write("Autor: ");
        string autor = Console.ReadLine() ?? "";

        Console.Write("Editora: ");
        string editora = Console.ReadLine() ?? "";

        repoLivro.Cadastrar(new Livro(titulo, autor, editora));
    }

    private void EditarLivro()
    {
        Console.Clear();
        Console.WriteLine("=== EDITAR LIVRO ===\n");
        Console.Write("ID do livro: ");

        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
            Console.Write("ID inválido: ");

        var livro = repoLivro.SelecionarPorId(id);

        if (livro == null)
        {
            Console.WriteLine("Livro não encontrado!");
            Console.ReadLine();
            return;
        }

        Console.Write("Novo título: ");
        string titulo = Console.ReadLine() ?? "";

        Console.Write("Novo autor: ");
        string autor = Console.ReadLine() ?? "";

        Console.Write("Nova editora: ");
        string editora = Console.ReadLine() ?? "";

        repoLivro.Editar(id, titulo, autor, editora);

        Console.WriteLine("Livro atualizado!");
        Console.ReadLine();
    }

    private void ListarLivro()
    {
        Console.Clear();
        Console.WriteLine("=== LISTA DE LIVROS ===\n");

        var lista = repoLivro.SelecionarTodos();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum livro cadastrado.");
        }
        else
        {
            foreach (var l in lista)
            {
                Console.WriteLine($"ID: {l.Id}");
                Console.WriteLine($"Título: {l.Titulo}");
                Console.WriteLine($"Editora: {l.Editora}");
                Console.WriteLine($"Status: {l.StatusEmprestimo}");
                Console.WriteLine("----------------------------");
            }
        }

        Console.WriteLine("\nPressione ENTER...");
        Console.ReadLine();
    }

    private void RemoverLivro()
    {
        Console.Clear();
        Console.WriteLine("=== REMOVER LIVRO ===\n");
        Console.Write("Digite o ID do livro: ");
        int id = int.Parse(Console.ReadLine()!);
        repoLivro.Remover(id);
    }
}