using Microsoft.AspNetCore.Mvc;
using Project.Interfaces;
using Project.ViewModels;

namespace Project.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService   _personService;
    private readonly IResponseService _responseService;

    public PersonController(IPersonService personService, IResponseService responseService)
    {
        _personService   = personService;
        _responseService = responseService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Create([FromBody] PersonDto personDto)
    {
        await _personService.CreateAsync(personDto);
        return StatusCode(
            _personService.GetStatusCode(), 
            _responseService.SetResponse(_personService.GetStatusCode(), _personService.GetFunctionMessage()));
    }
    
    [HttpGet]
    [Route("GetById/{personId}")]
    public async Task<ActionResult> GetById([FromRoute] int personId)
    {
        PersonDto personDto = await _personService.GetByIdAsync(personId);
        return StatusCode(
            _personService.GetStatusCode(), 
            _responseService.SetResponse(_personService.GetStatusCode(), _personService.GetFunctionMessage(), personDto));
    }
    
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult> GetAll()
    {
        IEnumerable<PersonDto> personDtos = await _personService.GetAllAsync();
        return StatusCode(
            _personService.GetStatusCode(), 
            _responseService.SetResponse(_personService.GetStatusCode(), _personService.GetFunctionMessage(), personDtos));
    }
    
    [HttpPatch]
    [Route("Update")]
    public async Task<ActionResult> Update([FromBody] PersonDto personDto)
    {
        await _personService.UpdateAsync(personDto);
        return StatusCode(
            _personService.GetStatusCode(), 
            _responseService.SetResponse(_personService.GetStatusCode(), _personService.GetFunctionMessage()));
    }
    
    [HttpDelete]
    [Route("Delete/{personId}")]
    public async Task<ActionResult> Delete([FromRoute] int personId)
    {
        await _personService.DeleteAsync(personId);
        return StatusCode(
            _personService.GetStatusCode(), 
            _responseService.SetResponse(_personService.GetStatusCode(), _personService.GetFunctionMessage()));
    }
}