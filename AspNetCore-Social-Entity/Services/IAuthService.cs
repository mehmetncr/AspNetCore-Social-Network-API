using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Services
{
   public interface IAuthService
    {
        string GenereteToken(string userId);
    }
}
