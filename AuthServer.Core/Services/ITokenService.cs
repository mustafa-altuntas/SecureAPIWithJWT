using AuthServer.Core.Configurations;
using AuthServer.Core.Dtos;
using AuthServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreteToken(UserApp userApp);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
