using Bad.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourTheWorld.Models;

namespace TourTheWorld.ViewModels.Tours
{
    public class TourMediaListViewModel
    {
        public TourModel Tour { get; set; }
        public IEnumerable<MultimediaModel> MediaList { get; set; }
    }
}
