using Bad.Core.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourTheWorld.Models
{
    public class TourModel : BaseEntityModel<long>
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [DisplayName("Details")]
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(11, 2)")]
        public decimal Price { get; set; }
        [ForeignKey("PrimaryMedia")]
        public long? PrimaryMediaId { get; set; }
        public virtual MultimediaModel PrimaryMedia { get; set; }
        public virtual ICollection<TourMediaModel> MediaList { get; set; }

    }
}
