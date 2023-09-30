using hackyeah.App.Application.Actions;
using hackyeah.App.Application.Actions.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;

namespace hackyeah.App.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UniversityController : BaseApiController
{
    public UniversityController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    [Route("query")]
    public Task<IActionResult> Get(string query, int page) => Endpoint(new GetByQuery.Command(query, page));
    [HttpGet]
    [Route("by-city")]
    public Task<IActionResult> GetByCity(Guid cityId, int page) => Endpoint(new GetByCity.Command(cityId, page));
}

