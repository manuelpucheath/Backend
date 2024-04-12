namespace Project.Interfaces;

public interface IGetAll<T>
{
    Task<IEnumerable<T>> GetAllAsync();
}