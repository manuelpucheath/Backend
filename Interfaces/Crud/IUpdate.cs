namespace Project.Interfaces;

public interface IUpdate<T>
{
    Task UpdateAsync(T data);
}