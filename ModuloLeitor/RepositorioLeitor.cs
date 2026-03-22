using System.Linq;

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
        leitores.Add(leitor);
    }

     public void EditarLeitor(string cpf, Leitor leitorAtualizado)
    {
        Leitor? leitor = SelecionarPorCpf(cpf);

        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!");
            return;
        }

        leitor.Nome = leitorAtualizado.Nome;
        leitor.Cpf = leitorAtualizado.Cpf;
        leitor.Telefone = leitorAtualizado.Telefone;
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
        if (leitor != null)
            leitores.Remove(leitor);
    }
}