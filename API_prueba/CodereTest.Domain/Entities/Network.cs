using CodereTest.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodereTest.Domain.Entities
{
    public class Network : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }

        [Required]
        public Country? Country { get; set; }

        [MaxLength(255)]
        public string OfficialSite { get; set; } = string.Empty;
    }
}
