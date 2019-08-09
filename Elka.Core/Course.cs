using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Elka.Core
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Moniker { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "{0} must be between 0 and 100")]
        public byte HowEasy { get; set; }
        [Required]
        [Range(0, 100)]
        public byte InterestingLevel { get; set; }
        public string Descriptions { get; set; }
        [Required]
        [Range(0, 5)]
        public byte ECTS { get; set; }
        [Required]
        public Teacher Teacher { get; set; }
    }
}
