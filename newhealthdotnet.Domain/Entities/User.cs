using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newhealthdotnet.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}

