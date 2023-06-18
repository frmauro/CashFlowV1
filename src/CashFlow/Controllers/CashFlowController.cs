using AutoMapper;
using CashFlow.Application.Moviment;
using CashFlow.Application.Moviment.Query;
using CashFlow.Application.Moviment.Save;
using CashFlow.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CashFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CashFlowController : ControllerBase
    {
        public readonly IMapper _mapper;

        public CashFlowController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet(Name = "GetCashFlow")]
        public IEnumerable<MovementDto> Get([FromServices] IMediator mediator)
        {
            var query = new GetAllQuery();
            var moviments = mediator.Send(query);
            var movementsDto = _mapper.Map<List<Movement>, List<MovementDto>>(moviments.Result);
            return movementsDto.ToArray();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(
                  [FromServices] IMediator mediator,
                  [FromBody] MovementDto dto
              )
        {
            var command = new SaveMovimentCommand(dto.MovementValue, Convert.ToInt32(dto.MovementType), dto.PersonName, Convert.ToInt32(dto.PersonType));
            var response = mediator.Send(command);
            return Ok(response);
        }
    }
}