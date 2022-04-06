using System;
using System.Collections.Generic;
using System.Linq;
using DinnerPlans.Data.DataObjects;
using DinnerPlans.Data.Repositories.Interfaces;

namespace DinnerPlans.Data.Repositories
{
    public class UserRepo : IRepository<UserDocument>
    {
        public UserDocument Get(Guid id)
        {
            return UserDummyRepoStorage.Users.FirstOrDefault(_ => _.Equals(id));
        }

        public IEnumerable<UserDocument> Get(List<Guid> ids)
        {
            return UserDummyRepoStorage.Users.Where(_ => ids.Contains(_.Id));
        }
    }

    public static class UserDummyRepoStorage
    {
        public static List<UserDocument> Users { get; set; }

        private static List<UserDocument> _users = new List<UserDocument>()
        {
            new UserDocument()
            {
                Id = new Guid("")
            }
        };
    }
}   