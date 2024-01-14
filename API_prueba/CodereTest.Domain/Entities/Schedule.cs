using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodereTest.Domain.Entities.Common;

namespace CodereTest.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        [MaxLength(10)] // Assuming time is short, adjust as needed
        public string Time { get; set; }

        [NotMapped]
        public List<string> Days { get; set; }
    }
}
