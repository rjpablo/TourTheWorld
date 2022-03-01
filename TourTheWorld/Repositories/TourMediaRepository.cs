using Bad.Core.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TourTheWorld.Data;
using TourTheWorld.Models;

namespace TourTheWorld.Repositories
{
    public class TourMediaRepository : BaseRepository<TourMediaModel>, ITourMediaRepository
    {
        public TourMediaRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
