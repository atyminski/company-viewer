using System.Threading.Tasks;
using Gevlee.CompanyViewer.Core.Application.Companies.Queries;
using Gevlee.CompanyViewer.WebApi.Common.Filters;
using Gevlee.CompanyViewer.WebApi.Companies.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gevlee.CompanyViewer.WebApi.Companies
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CompaniesController (IMediator mediator)
        {
            this.mediator = mediator;

        }

        [HttpGet("find")]
        public async Task<IActionResult> Find([FromQuery]SearchCompanyRequest model)
        {
            var result = await mediator.Send(new FindCompanyQuery(model.SearchPhrase));
            if(result == null)
                return NotFound();
            
            return Ok(result);
        }
    }
}