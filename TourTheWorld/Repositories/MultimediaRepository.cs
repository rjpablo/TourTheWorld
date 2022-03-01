using Bad.Core.Models;
using Bad.Core.Repositories;
using TourTheWorld.Data;

namespace TourTheWorld.Repositories
{
    public class MultimediaRepository : BaseRepository<MultimediaModel, long>, IMultimediaRepository
    {
        public MultimediaRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
