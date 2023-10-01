using hackyeah.App.Application.Actions;
using hackyeah.App.Application.Actions.Data;
using hackyeah.App.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.BaseModels.ApiControllerModels;

namespace hackyeah.App.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UniversityController : BaseApiController
{
    public UniversityController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    [Route("query")]
    public Task<IActionResult> Get(string query = "", int page = 0, [FromQuery]List<InstitutionType> types = null, int minPrice = 0, int maxPrice = 0, ModeOfStudy mode = ModeOfStudy.All, string city = "")
        => Endpoint(new GetByQuery.Command(query, page, types, minPrice, maxPrice, mode, city));
    
    [HttpGet]
    [Route("localizations")]
    public Task<IActionResult> GetLocalizations() => Endpoint(new GetLocalizations.Command());[HttpGet]
    
    [Route("by-id")]
    public Task<IActionResult> GetById(Guid id) => Endpoint(new GetById.Command(id));

    //[HttpGet]
    //[Route("by-city")]
    //public Task<IActionResult> GetByCity(Guid cityId, int page = 0) => Endpoint(new GetByCity.Command(cityId, page));
}

