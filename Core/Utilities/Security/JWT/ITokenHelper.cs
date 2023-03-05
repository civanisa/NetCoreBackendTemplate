#region Imports
using Core.Entities.Concrete;
using System;
#endregion

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims); 
    }
}
