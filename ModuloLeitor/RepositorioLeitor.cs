//Alvaro Machado Feltrin e Enzo Rosa Fernandes
namespace Biblioteca;

public class RepositorioLeitor
{
    private List<Leitor> leitores = new List<Leitor>();

    public bool CpfJaExiste(string cpf)
    {
        return leitores.Exists(l => l.Cpf == cpf);
    }

    public void Cadastrar(Leitor leitor)
    {
        if (CpfJaExiste(leitor.Cpf))
        {
            Console.WriteLine("CPF já cadastrado!");
            return;
        }

        leitores.Add(leitor);
    }

    public void EditarLeitor(string cpfOriginal, Leitor leitorAtualizado)
    {
        Leitor? leitor = SelecionarPorCpf(cpfOriginal);

        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!");
            return;
        }

        if (cpfOriginal != leitorAtualizado.Cpf && CpfJaExiste(leitorAtualizado.Cpf))
        {
            Console.WriteLine("Novo CPF já está em uso!");
            return;
        }

        if (!string.IsNullOrWhiteSpace(leitorAtualizado.Nome))
            leitor.Nome = leitorAtualizado.Nome;

        if (!string.IsNullOrWhiteSpace(leitorAtualizado.Cpf))
            leitor.Cpf = leitorAtualizado.Cpf;

        if (leitorAtualizado.Idade > 0)
            leitor.Idade = leitorAtualizado.Idade;
    }

    public List<Leitor> SelecionarTodos()
    {
        return leitores;
    }

    public Leitor? SelecionarPorCpf(string cpf)
    {
        return leitores.FirstOrDefault(l => l.Cpf == cpf);
    }

    public void Remover(string cpf)
    {
        var leitor = SelecionarPorCpf(cpf);

        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!");
            return;
        }

        leitores.Remove(leitor);
    }
}