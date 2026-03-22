namespace Biblioteca;

public class RepositorioEmprestimo
{
    private List<Emprestimo> emprestimos = new();

    public void Emprestar(Leitor leitor, Livro livro)
    {
        emprestimos.Add(new Emprestimo(leitor, livro));
    }

    public void Devolver(Livro livro)
    {
        var emp = emprestimos.Find(e => e.Livro == livro);
        if (emp != null) emprestimos.Remove(emp);
    }

    public Emprestimo? BuscarPorLivro(string titulo)
    {
        return emprestimos.Find(e => e.Livro.Titulo == titulo);
    }

    public List<Emprestimo> SelecionarTodos()
    {
        return emprestimos;
    }
}