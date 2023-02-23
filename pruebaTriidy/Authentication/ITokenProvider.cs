using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaTriidy.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(DateTime expiry);
        TokenValidationParameters GetTokenValidation();
    }
}
