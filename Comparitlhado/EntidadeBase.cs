//Alvaro Machado Feltrin e Enzo Rosa Fernandes
namespace Biblioteca;

public abstract class EntidadeBase<T>
{
    private static int contadorId = 0;

    public int Id { get; set; }

    public void GerarId()
    {
        Id = ++contadorId;
    }
}