using Bad.Core.Models;
using Bad.Core.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TourTheWorld.Data;
using TourTheWorld.Models;

namespace TourTheWorld.Repositories
{
    public interface IMultimediaRepository : IRepository<MultimediaModel, long>
    {
    }
}
