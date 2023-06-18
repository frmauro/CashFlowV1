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
    public class CashFlowReportController : ControllerBase
    {
        public readonly IMapper _mapper;

        public CashFlowReportController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet(Name = "GetBalancePerDay")]
        public IEnumerable<dynamic> GetBalancePerDay([FromServices] IMediator mediator)
        {
            var query = new GetBalancePerDay();
            var movements = mediator.Send(query).Result;
            return (IEnumerable<dynamic>)movements;
        }
    }
}