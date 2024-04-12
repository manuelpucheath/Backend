using Microsoft.AspNetCore.Mvc;
using Project.Interfaces;
using Project.Services;
using Project.ViewModels;

namespace Project.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentificationTypeController : ControllerBase
{

    private IResponseService           _responseService;
    private IIdentificationTypeService _identificationTypeService;

    public IdentificationTypeController(IIdentificationTypeService identificationTypeService, IResponseService responseService)
    {
        _identificationTypeService = identificationTypeService;
        _responseService           = responseService;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult> GetAll()
    {
        var data = await _identificationTypeService.GetAllAsync();
        return StatusCode(
            _identificationTypeService.GetStatusCode(), 
            _responseService.SetResponse(_identificationTypeService.GetStatusCode(), _identificationTypeService.GetFunctionMessage(), data));
    }
}