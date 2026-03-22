namespace Biblioteca;

public class TelaLivro
{
    private RepositorioLivro repo;

    public TelaLivro(RepositorioLivro repo)
    {
        this.repo = repo;
    }

    public void MostrarMenu()
    {
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("=== LIVROS ===");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Listar");
            Console.WriteLine("4 - Voltar");

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: Cadastrar(); break;
                case 2: Editar(); break;
                case 3: Listar(); break;
            }

        } while (opcao != 4);
    }

    private void Cadastrar()
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine() ?? "";

        Console.Write("Autor: ");
        string autor = Console.ReadLine() ?? "";

        Console.Write("Editora: ");
        string editora = Console.ReadLine() ?? "";

        repo.Cadastrar(new Livro(titulo, autor, editora));
    }

        private void Editar()
    {
        Console.Write("ID do livro: ");

        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
            Console.Write("ID inválido: ");

        var livro = repo.SelecionarPorId(id);

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

        repo.Editar(id, titulo, autor, editora);

        Console.WriteLine("Livro atualizado!");
        Console.ReadLine();
    }

    private void Listar()
    {
        foreach (var l in repo.SelecionarTodos())
        {
            Console.WriteLine($"{l.Id} - {l.Titulo} ({l.StatusEmprestimo})");
        }

        Console.ReadLine();
    }
}