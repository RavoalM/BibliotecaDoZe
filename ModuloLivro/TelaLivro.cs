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
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Voltar");

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: Cadastrar(); break;
                case 2: Listar(); break;
            }

        } while (opcao != 3);
    }

    private void Cadastrar()
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine() ?? "";

        Console.Write("Autor: ");
        string autor = Console.ReadLine() ?? "";

        Genero genero = Genero.Ficcao; // simplificado

        Console.Write("Editora: ");
        string editora = Console.ReadLine() ?? "";

        repo.Cadastrar(new Livro(titulo, autor, genero, editora));
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