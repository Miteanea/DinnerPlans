using System;
using System.Collections.Generic;
using System.Linq;
using DinnerPlans.Data.DataObjects;
using DinnerPlans.Data.Repositories.Interfaces;

namespace DinnerPlans.Data.Repositories
{
    public class UserDummyRepo : IUserRepository
    {
        public IEnumerable<UserDocument> GetUser(Guid userId)
        {
            return UserDummyRepoStorage.Users.Where(_ => _.Id == userId);
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