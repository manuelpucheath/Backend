namespace Project.Interfaces;

public interface ICreate<T>
{
    Task CreateAsync(T data);
}