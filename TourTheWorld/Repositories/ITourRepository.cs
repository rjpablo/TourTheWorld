using Bad.Core.Repositories;
using TourTheWorld.Models;

namespace TourTheWorld.Repositories
{
    public interface ITourRepository : IRepository<TourModel, long>
    {
    }
}
