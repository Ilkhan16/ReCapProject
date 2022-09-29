using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption;

public class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string? securitykey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));
    }
}