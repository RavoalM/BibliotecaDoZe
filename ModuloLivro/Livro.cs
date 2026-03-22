namespace Biblioteca;

public class Livro : EntidadeBase<Livro>
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public Genero Genero { get; set; }
    public string Editora { get; set; } = string.Empty;

    public string StatusEmprestimo { get; set; }

    public const string Disponivel = "Disponivel";
    public const string Emprestado = "Emprestado";

    public Livro(string titulo, string autor, Genero genero, string editora)
    {
        GerarId();

        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Editora = editora;

        StatusEmprestimo = Disponivel;
    }

    public void Emprestar()
    {
        StatusEmprestimo = Emprestado;
    }

    public void Devolver()
    {
        StatusEmprestimo = Disponivel;
    }
}