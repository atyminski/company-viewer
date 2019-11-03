using FluentValidation;
using Gevlee.CompanyViewer.WebApi.Companies.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gevlee.CompanyViewer.WebApi.Companies.Validators
{
    public class SearchCompanyRequestValidator : AbstractValidator<SearchCompanyRequest>
    {
        private readonly Regex NipRegex = new Regex(@"^[A-Z]{0,2}(-{0,1}\d{3}){2}(-{0,1}\d{2}){2}$", RegexOptions.Compiled);

        public SearchCompanyRequestValidator()
        {
            RuleFor(x => x.SearchPhrase)
                .NotEmpty()
                .Custom((value, context) => 
                { 
                    if(value.All(x => char.IsDigit(x)))
                    {
                        if (value.Length != 9 && value.Length != 10)
                        {
                            context.AddFailure($"`{nameof(SearchCompanyRequest.SearchPhrase)}` should has 6 or 7 numbers");
                        }
                    }
                    else if (!NipRegex.IsMatch(value))
                    {
                        context.AddFailure($"`{nameof(SearchCompanyRequest.SearchPhrase)}` has invalid format");
                    }
                });
        }
    }
}
