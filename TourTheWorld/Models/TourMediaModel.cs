using Bad.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourTheWorld.Models
{
    // This entity has a composite key of (tourId, mediaId) set via Fluent Api.
    // See ApplicationDbContext.OnModelCreating method
    public class TourMediaModel : BaseEntityModel
    {
        public TourMediaModel(long tourId, long mediaId)
        {
            MediaId = mediaId;
            TourId = tourId;
        }

        [ForeignKey(nameof(Media))]
        public long MediaId { get; set; }
        public virtual MultimediaModel Media { get; set; }

        [ForeignKey(nameof(Tour))]
        public long TourId { get; set; }
        public virtual TourModel Tour { get; set; }
    }
}
