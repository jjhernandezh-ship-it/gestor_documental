using GDIIECA.Application.Validation;

namespace GDIIECA.Tests;

public sealed class InstitutionalEmailValidatorTests
{
    [Theory]
    [InlineData("persona@guanajuato.gob.mx")]
    [InlineData(" USUARIO@IECA.EDU.MX ")]
    public void AcceptsInstitutionalDomains(string email) => Assert.True(InstitutionalEmailValidator.IsValid(email));

    [Theory]
    [InlineData("persona@gmail.com")]
    [InlineData("persona@ieca.edu.mx.example.com")]
    [InlineData("ieca.edu.mx@evil.com")]
    [InlineData("")]
    public void RejectsOtherOrMalformedDomains(string email) => Assert.False(InstitutionalEmailValidator.IsValid(email));
}
