using CodereTest.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodereTest.Domain.Entities
{
    public class ShowItem : BaseEntity
    {
        [MaxLength(255)]
        public string Url { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)] // Assuming Type is short, adjust as needed
        public string Type { get; set; } = string.Empty;

        [MaxLength(50)] // Assuming Language is short, adjust as needed
        public string Language { get; set; } = string.Empty;

        [NotMapped]
        public List<string> Genres { get; set; } = new List<string>();

        [MaxLength(50)] // Assuming Status is short, adjust as needed
        public string Status { get; set; } = string.Empty;

        public int Runtime { get; set; }
        public int AverageRuntime { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Premiered { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Ended { get; set; }

        [MaxLength(255)]
        public string? OfficialSite { get; set; }

        [MaxLength(1000)] // Adjust the maximum length as needed
        public string Summary { get; set; } = string.Empty;

        public int Updated { get; set; }

        public int Weight { get; set; }


        //Relations
        public int LinksId { get; set; }
        public Links? Links { get; set; }

        public int ScheduleId { get; set; }
        public Schedule? Schedule { get; set; }

        public int RatingId { get; set; }
        public Rating? Rating { get; set; }

        public int NetworkId { get; set; }
        public Network? Network { get; set; }

        public int ExternalsId { get; set; }
        public Externals? Externals { get; set; }

        public int ImageId { get; set; }
        public Image? Image { get; set; }
    }
}
