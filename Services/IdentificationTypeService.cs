using Microsoft.EntityFrameworkCore;
using Project.Interfaces;
using Project.ViewModels;

namespace Project.Services;

public class IdentificationTypeService : IIdentificationTypeService
{

    private int              _statusCode      = 500;
    private string           _functionMessage = "";
    private readonly Context _context;

    public IdentificationTypeService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ListSimpleItem>> GetAllAsync()
    {
        IEnumerable<ListSimpleItem> identificationTypes = new List<ListSimpleItem>();
        try
        {
            identificationTypes = await _context.IdentificationTypes
                                                .Select(x => new ListSimpleItem()
                                                {
                                                    Id   = x.Id,
                                                    Name = x.Name
                                                }).ToListAsync();
            _statusCode      = 200;
            _functionMessage = "Success";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return identificationTypes;
    }

    public int GetStatusCode()
    {
        return _statusCode;
    }

    public string GetFunctionMessage()
    {
        return _functionMessage;
    }
}