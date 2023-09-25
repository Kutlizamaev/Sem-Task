using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.BLL.Responces
{
    public class AuthResponse
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
