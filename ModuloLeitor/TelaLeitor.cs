namespace Biblioteca;

public class TelaLeitor
{
    private RepositorioLeitor repo;

    public TelaLeitor(RepositorioLeitor repo)
    {
        this.repo = repo;
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

        if (repo.CpfJaExiste(cpf))
        {
            Console.WriteLine("CPF já cadastrado!");
            Console.ReadLine();
            return;
        }

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine() ?? "";

        var leitor = new Leitor(nome, cpf, telefone);

        string erros = leitor.Validar();

        if (erros != "")
        {
            Console.WriteLine(erros);
            Console.ReadLine();
            return;
        }

        repo.Cadastrar(leitor);
    }

    private void Listar()
    {
        foreach (var l in repo.SelecionarTodos())
        {
            Console.WriteLine($"{l.Nome} - {l.Cpf}");
        }
        Console.ReadLine();
    }

    private void Remover()
    {
        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? "";

        repo.Remover(cpf);
    }
}