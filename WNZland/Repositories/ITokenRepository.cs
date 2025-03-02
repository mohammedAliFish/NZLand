
using Microsoft.AspNetCore.Identity;

namespace WNZland.Repositories;

public interface ITokenRepository
{

string CreateJWTToken(IdentityUser user ,List<string> roles);
}
