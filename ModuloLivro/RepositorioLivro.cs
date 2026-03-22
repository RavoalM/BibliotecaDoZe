namespace Biblioteca;

public class RepositorioLivro
{
    private List<Livro> livros = new List<Livro>();

    public void Cadastrar(Livro livro)
    {
        livros.Add(livro);
    }

    public List<Livro> SelecionarTodos()
    {
        return livros;
    }

    public Livro? SelecionarPorId(int id)
    {
        return livros.FirstOrDefault(l => l.Id == id);
    }
}