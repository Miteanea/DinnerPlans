using System;
using System.Collections.Generic;
using DinnerPlans.Data.DataObjects;

namespace DinnerPlans.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserDocument> GetUser(Guid userId);
    }
}
