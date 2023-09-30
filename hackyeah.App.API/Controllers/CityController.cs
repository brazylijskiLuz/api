using hackyeah.App.Application.Actions;
using hackyeah.App.Application.Actions.City;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;

namespace hackyeah.App.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CityController : BaseApiController
{
    public CityController(IMediator mediator) : base(mediator) { }
    
    [HttpGet]
    public Task<IActionResult> Get(string query, int page) => Endpoint(new GetCities.Command(query, page));
}