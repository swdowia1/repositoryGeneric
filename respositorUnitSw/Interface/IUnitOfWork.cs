using respositorUnitSw.Model;

namespace respositorUnitSw.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepository<Person> PersonRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<Work> WorkRepository { get; }
        void Save();
    }
}
