using hackyeah.App.Application.Actions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;

namespace hackyeah.App.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DataController : BaseApiController
{
    public DataController(IMediator mediator) : base(mediator) { }
    
    [HttpGet]
    public Task<IActionResult> CreateDatabase() => Endpoint(new CreateDatabase.Command());
}

