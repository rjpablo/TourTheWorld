using Bad.Core.Repositories;
using TourTheWorld.Models;

namespace TourTheWorld.Repositories
{
    public interface IAccountsRepository:IRepository<AccountModel, long>
    {
    }
}
