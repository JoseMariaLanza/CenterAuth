using CenterAuth.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterAuth.Services
{
    public interface IJwtService
    {
        public string GenerateJwtToken(UserGetDto user);
    }
}
