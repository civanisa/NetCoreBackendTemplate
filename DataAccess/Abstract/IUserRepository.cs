#region Imports
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using System;

#endregion

namespace DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepositoryBase<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
