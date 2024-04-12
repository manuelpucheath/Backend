namespace Project.Interfaces;

public interface IGetById<T>
{
    Task<T> GetByIdAsync(int id);
}