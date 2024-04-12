using Microsoft.EntityFrameworkCore;
using Project.Interfaces;
using Project.Models;
using Project.ViewModels;

namespace Project.Services;

public class PersonService : IPersonService
{
    
    private int              _statusCode      = 500;
    private string           _functionMessage = "";
    private readonly Context _context;

    public PersonService(Context context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(PersonDto personDto)
    {
        try
        {
            Person person = new Person()
            {
                Email                = personDto.Email,
                IdentificationTypeId = personDto.IdentificationType.Id,
                Name                 = personDto.Name,
                IdentificationNumber = personDto.IdentificationNumber,
                LastName             = personDto.LastName
            };
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            _statusCode      = 200;
            _functionMessage = "Success";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<PersonDto> GetByIdAsync(int id)
    {
        PersonDto? personDto = new PersonDto();
        try
        {
            personDto = await _context.Persons
                                      .Include(x => x.IdentificationType)
                                      .Where(x => x.Id == id)
                                      .Select(x => new PersonDto()
                                      {
                                          Id                         = x.Id,
                                          Name                       = x.Name,
                                          IdentificationNumber       = x.IdentificationNumber,
                                          LastName                   = x.LastName,
                                          Email                      = x.Email,
                                          ConcatenatedIdentification = x.ConcatenatedIdentification,
                                          FullName                   = x.FullName,
                                          IdentificationType         = new ListSimpleItem()
                                          {
                                             Id   = x.IdentificationType.Id,
                                             Name = x.IdentificationType.Name
                                          },
                                      })
                                      .FirstOrDefaultAsync();
            _statusCode      = 200;
            _functionMessage = "Success";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return personDto;
    }

    public async Task<IEnumerable<PersonDto>> GetAllAsync()
    {
        IEnumerable<PersonDto> personDtos = new List<PersonDto>();
        try
        {
            personDtos = await _context.Persons
                                       .Select(x => new PersonDto()
                                       {
                                           LastName                   = x.LastName,
                                           Email                      = x.Email,
                                           Id                         = x.Id,
                                           Name                       = x.Name,
                                           IdentificationNumber       = x.IdentificationNumber,
                                           ConcatenatedIdentification = x.ConcatenatedIdentification,
                                           FullName                   = x.FullName,
                                           IdentificationType         = new ListSimpleItem()
                                           {
                                               Name = x.IdentificationType.Name,
                                               Id = x.IdentificationType.Id
                                           }
                                       })
                                       .ToListAsync();
            _statusCode      = 200;
            _functionMessage = "Success";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return personDtos;
    }

    public async Task UpdateAsync(PersonDto personDto)
    {
        try
        {
            var person = await _context.Persons.Where(x => x.Id == personDto.Id).FirstOrDefaultAsync();
            if (person is not null)
            {
                person.Email                = personDto.Email;
                person.Name                 = personDto.Name;
                person.LastName             = personDto.LastName;
                person.IdentificationTypeId = personDto.IdentificationType.Id;
                person.IdentificationNumber = personDto.IdentificationNumber;

                await _context.SaveChangesAsync();
                _statusCode      = 200;
                _functionMessage = "Success";
            }
            else
            {
                _statusCode      = 404;
                _functionMessage = "Not Found";
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var person = await _context.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (person is not null)
            {
                _context.Remove(person);
                await _context.SaveChangesAsync();
                _statusCode      = 200;
                _functionMessage = "Success";
            }
            else
            {
                _statusCode      = 404;
                _functionMessage = "Not Found";
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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