using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.API.JWT
{
    public interface IJWTAuthenticationService
    {
        public string Authenticate(string userId);
    }
}
