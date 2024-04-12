namespace Project.Interfaces;

public interface ICrud<T> : ICreate<T>, IGetById<T>, IGetAll<T>, IUpdate<T>, IDelete
{
}