using hackyeah.App.Application.Actions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;

namespace hackyeah.App.API.Controllers;

[ApiController]
[Route("/api")]
public class DatabaseManagmentController : BaseApiController
{
    public DatabaseManagmentController(IMediator mediator) : base(mediator) { }
    
    [HttpGet]
    public Task<IActionResult> CreateDatabase() => Endpoint(new CreateDatabase.Command());
    [HttpGet("maps")]
    public Task<IActionResult> CreateXY() => Endpoint(new GetMapLocalization.Command());
}

