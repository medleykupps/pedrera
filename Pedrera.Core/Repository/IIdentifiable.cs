namespace Pedrera.Core.Repository
{
    public interface IIdentifiable<T>
    {
        T Id { get; set; }
    }
}
