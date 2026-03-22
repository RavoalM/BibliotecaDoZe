namespace Biblioteca;

public class Emprestimo
{
    public Leitor Leitor { get; set; }
    public Livro Livro { get; set; }

    public Emprestimo(Leitor leitor, Livro livro)
    {
        Leitor = leitor;
        Livro = livro;
    }
}