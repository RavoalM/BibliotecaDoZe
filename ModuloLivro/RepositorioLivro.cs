namespace Biblioteca;

public class RepositorioLivro
{
    private List<Livro> livros = new List<Livro>();

    public void Cadastrar(Livro livro)
    {
        livros.Add(livro);
    }

    public void Editar(int id, string novoTitulo, string novoAutor, string novaEditora)
{
    var livro = SelecionarPorId(id);

    if (livro != null)
    {
        livro.Titulo = novoTitulo;
        livro.Autor = novoAutor;
        livro.Editora = novaEditora;
    }
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