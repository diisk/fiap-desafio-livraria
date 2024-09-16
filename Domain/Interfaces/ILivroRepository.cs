using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        ICollection<Livro> FindAllAvailables();
    }
}
