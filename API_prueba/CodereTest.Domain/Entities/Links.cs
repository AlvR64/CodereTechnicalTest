using CodereTest.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTest.Domain.Entities
{
    public class Links : BaseEntity
    {
        [MaxLength(255)]
        public string Self { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Previousepisode { get; set; } = string.Empty;
    }
}
