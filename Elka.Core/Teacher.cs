using System.ComponentModel.DataAnnotations;

namespace Elka.Core
{
    public class Teacher
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
    }
}