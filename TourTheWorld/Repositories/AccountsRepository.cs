using Bad.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourTheWorld.Data;
using TourTheWorld.Models;

namespace TourTheWorld.Repositories
{
    public class AccountsRepository: BaseRepository<AccountModel, long>, IAccountsRepository
    {
        public AccountsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
