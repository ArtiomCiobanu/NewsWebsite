﻿using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Entities;
using NewsWebsiteAPI.DataAccess.Repositories.Generic;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Task<Account> GetWithEmailAsync(string email);
        public Task<bool> ExistsWithEmailAsync(string email);
    }
}