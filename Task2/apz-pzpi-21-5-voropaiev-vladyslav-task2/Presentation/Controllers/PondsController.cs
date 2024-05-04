using Application.Features.Ponds.Commands.CreatePondCommand;
using Application.Features.Ponds.Queries.GetPondDataQuery;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PondsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PondsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreatePondCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetData(GetPondDataQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}