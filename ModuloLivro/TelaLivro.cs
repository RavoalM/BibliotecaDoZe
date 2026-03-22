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
            Console.WriteLine("1 - Cadastrar Livro");
            Console.WriteLine("2 - Editar Livro");
            Console.WriteLine("3 - Listar Livros");
            Console.WriteLine("4 - Voltar");

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: CadastrarLivro(); break;
                case 2: EditarLivro(); break;
                case 3: ListarLivro(); break;
            }

        } while (opcao != 4);
    }

    private void CadastrarLivro()
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine() ?? "";

        Console.Write("Autor: ");
        string autor = Console.ReadLine() ?? "";

        Console.Write("Editora: ");
        string editora = Console.ReadLine() ?? "";

        repo.Cadastrar(new Livro(titulo, autor, editora));
    }

        private void EditarLivro()
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

 private void ListarLivro()
{
    Console.Clear();
    Console.WriteLine("=== LISTA DE LIVROS ===\n");

    var lista = repo.SelecionarTodos();

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
            Console.WriteLine($"Status: {l.StatusEmprestimo}");
            Console.WriteLine("----------------------------");
        }
    }

    Console.WriteLine("\nPressione ENTER...");
    Console.ReadLine();
}
}