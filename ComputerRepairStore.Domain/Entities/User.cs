using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace ComputerRepairStore.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public UserType UserType { get; set; }
    }
}
