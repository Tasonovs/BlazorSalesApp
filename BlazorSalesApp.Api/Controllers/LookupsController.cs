using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Lookups;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSalesApp.Api.Controllers;

[ApiController]
[Route("/api/lookups")]
public class LookupsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LookupsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("states")]
    public Task<List<LookupViewModel>> GetStates([FromQuery] GetStatesRequest request) =>
        _mediator.Send(request);
    
    [HttpGet("types")]
    public Task<List<LookupViewModel>> GetTypes([FromQuery] GetTypesRequest request) =>
        _mediator.Send(request);
}