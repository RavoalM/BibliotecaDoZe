namespace Biblioteca;

public class Leitor
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }

    public Leitor(string nome, string cpf, string telefone)
    {
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
    }

    public string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 2)
            erros += "Nome inválido.\n";

        if (string.IsNullOrWhiteSpace(Cpf) || Cpf.Length != 11)
            erros += "CPF deve ter 11 dígitos.\n";

        if (string.IsNullOrWhiteSpace(Telefone) || Telefone.Length < 10)
            erros += "Telefone inválido.\n";

        return erros;
    }
}