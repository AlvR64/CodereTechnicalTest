using CodereTest.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTest.Domain.Entities
{
    public class Image : BaseEntity
    {
        [MaxLength(255)]
        public string Medium { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Original { get; set; } = string.Empty;
    }
}
