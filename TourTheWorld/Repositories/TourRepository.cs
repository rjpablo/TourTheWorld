using Bad.Core.Repositories;
using TourTheWorld.Data;
using TourTheWorld.Models;

namespace TourTheWorld.Repositories
{
    public class TourRepository : BaseRepository<TourModel, long>, ITourRepository
    {
        public TourRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
