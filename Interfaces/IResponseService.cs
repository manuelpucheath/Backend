using Project.ViewModels;

namespace Project.Interfaces;

public interface IResponseService
{
    ResponseModel SetResponse(int status, string message, dynamic? data = null);
}