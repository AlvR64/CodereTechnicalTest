using CodereTest.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTest.Domain.Entities
{
    public class Country : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)] // Assuming country codes are short, adjust as needed
        public string Code { get; set; } = string.Empty;

        [MaxLength(50)] // Adjust the maximum length as needed
        public string Timezone { get; set; } = string.Empty;
    }
}
