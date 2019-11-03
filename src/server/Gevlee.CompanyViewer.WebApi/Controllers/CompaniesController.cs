using System;
using System.Threading.Tasks;
using Gevlee.CompanyViewer.Core.Application.Companies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gevlee.CompanyViewer.WebApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase {
        private readonly IMediator mediator;
        public CompaniesController (IMediator mediator) 
        {
            this.mediator = mediator;

        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string searchPhrase) 
        {
            var result = await mediator.Send<FoundCompany>(new FindCompanyQuery(searchPhrase));
            if(result == null)
                return NotFound();
            
            return Ok(result);
        }
    }
}