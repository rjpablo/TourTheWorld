using Bad.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourTheWorld.Models
{
    public class TourModel : BaseEntityModel<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(11, 2)")]
        public decimal Price { get; set; }
        [ForeignKey("PrimaryMedia")]
        public long PrimaryMediaId { get; set; }
        public virtual MultimediaModel PrimaryMedia { get; set; }

    }
}
