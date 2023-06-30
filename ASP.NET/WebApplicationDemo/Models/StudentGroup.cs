using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDemo.Models
{
    public class StudentGroup
    {
        public int Id { get; set; }
        [DisplayName("Студентська група")]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Student>? Students { get; set; }
    }
}
