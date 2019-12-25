using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Contracts.V1.Requests
{
    public class MobileUserLoginRequest
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Distributor { get; set; }
        public DateTimeOffset ExpireAt { get; set; }
    }
}
