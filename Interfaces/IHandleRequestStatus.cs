namespace Project.Interfaces;

public interface IHandleRequestStatus
{
    int    GetStatusCode();
    string GetFunctionMessage();
}