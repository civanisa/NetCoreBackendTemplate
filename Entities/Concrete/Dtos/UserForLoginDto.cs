#region Imports
using Core.Entities;
using System;

#endregion

namespace Entities.Concrete.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
