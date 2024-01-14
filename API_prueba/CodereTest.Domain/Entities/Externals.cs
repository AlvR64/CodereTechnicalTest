using CodereTest.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTest.Domain.Entities
{
    public class Externals : BaseEntity
    {
        public int Tvrage { get; set; }
        public int Thetvdb { get; set; }

        [MaxLength(20)] // Assuming IMDb codes are short, adjust as needed
        public string Imdb { get; set; } = string.Empty;
    }
}
