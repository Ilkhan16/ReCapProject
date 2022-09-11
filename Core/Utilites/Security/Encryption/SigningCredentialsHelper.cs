using Microsoft.IdentityModel.Tokens;

namespace Core.Utilites.Security.Encryption;

public class SigningCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
    }
}