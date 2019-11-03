using FluentValidation.TestHelper;
using Gevlee.CompanyViewer.WebApi.Companies.Validators;
using Xunit;

namespace Gevlee.CompanyViewer.Tests.WebApi.Companies.Validators
{
    public class SearchCompanyRequestValidatorTest
    {
        public SearchCompanyRequestValidator Validator { get; set; }

        public SearchCompanyRequestValidatorTest()
        {
            Validator = new SearchCompanyRequestValidator();
        }

        [Theory]
        [InlineData("4174813540")]
        [InlineData("PL4174813540")]
        [InlineData("417-481-35-40")]
        [InlineData("PL417-481-35-40")]
        [InlineData("PL-417-481-35-40")]
        [InlineData("230238628")]
        public async void Validation_ShouldPass_IfObjectIsValid(string phrase)
        {
            Validator.ShouldNotHaveValidationErrorFor(request => request.SearchPhrase, phrase);
        }

        [Theory]
        [InlineData("41748135")]
        [InlineData("PLN4174813540")]
        [InlineData("417-481-354-0")]
        public async void Validation_ShouldFail_IfObjectIsInvalid(string phrase)
        {
            Validator.ShouldHaveValidationErrorFor(request => request.SearchPhrase, phrase);
        }
    }
}
