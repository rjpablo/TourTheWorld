using Bad.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TourTheWorld.Models.Identity;

namespace TourTheWorld.Models
{
    public class AccountModel:BaseEntityModel<long>
    {
        [MaxLength(30)]
        public string Name { get; set; }

        #region Identity
        [ForeignKey(nameof(IdentityUser))]
        public string IdentityUserId { get; set; }
        public ApplicationUser IdentityUser { get; set; }
        #endregion
    }
}
