using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVCDemo.Models
{
    public class Student
    {
        public int Id { get; set; }
        [DisplayName("Ім'я")]
        
        public string Name { get; set; }
        [DisplayName("Прізвище")]
        public string Surname { get; set; }
     }
}
