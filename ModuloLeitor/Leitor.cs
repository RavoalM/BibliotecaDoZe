//Alvaro Machado Feltrin e Enzo Rosa Fernandes
namespace Biblioteca;

public class Leitor
{
    private string nome = string.Empty;
    private string cpf = string.Empty;
    private int idade;

    public string Nome
    {
        get => nome;
        set => nome = ValidarNome(value);
    }

    public string Cpf
    {
        get => cpf;
        set => cpf = ValidarCpf(value);
    }

    public int Idade
    {
        get => idade;
        set => idade = ValidarIdade(value);
    }

    public Leitor() { }

    public Leitor(string nome, string cpf, int idade)
    {
        Nome = nome;
        Cpf = cpf;
        Idade = idade;
    }

    private string ValidarNome(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new Exception("O campo \"Nome\" é obrigatório.");

        string nomeTratado = valor.Trim();

        if (nomeTratado.Length < 2)
            throw new Exception("O nome deve ter pelo menos 3 caracteres.");

        return nomeTratado;
    }

    private string ValidarCpf(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new Exception("O campo \"CPF\" é obrigatório.");

        string cpfTratado = valor.Trim();

        if (cpfTratado.Length != 11)
            throw new Exception("CPF deve ter 11 dígitos.");

        return cpfTratado;
    }

    private int ValidarIdade(int valor)
    {
        if (valor <= 0)
            throw new Exception("Idade inválida.");

        return valor;
    }
}