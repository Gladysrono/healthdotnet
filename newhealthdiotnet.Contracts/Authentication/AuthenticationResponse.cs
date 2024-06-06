using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newhealthdiotnet.Contracts.Authentication
{
    public class AuthenticationResponse
    {
        public required string Token { get; set; }
    }
}
