using System.Net.Mail;

namespace GDIIECA.Application.Validation;

public static class InstitutionalEmailValidator
{
    private static readonly HashSet<string> AllowedDomains = new(StringComparer.OrdinalIgnoreCase)
    { "guanajuato.gob.mx", "ieca.edu.mx" };

    public static string Normalize(string email) => email.Trim().ToLowerInvariant();

    public static bool IsValid(string? email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;
        try
        {
            var address = new MailAddress(Normalize(email));
            return address.Address == Normalize(email) && AllowedDomains.Contains(address.Host);
        }
        catch (FormatException) { return false; }
    }
}
