using Project.Interfaces;
using Project.ViewModels;

namespace Project.Services;

public class ResponseService : IResponseService
{
    public ResponseModel SetResponse(int status, string message, dynamic? data = null)
    {
        return new ResponseModel
        {
            status  = status,
            message = message,
            data    = data
        };
    }
}