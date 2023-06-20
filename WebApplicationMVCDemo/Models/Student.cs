using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVCDemo.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("Ім'я")]
        //[Remote(action: "VerifyStudentName" ,controller:"Students",ErrorMessage ="Довжина імені повинна бути не меньше 15 символів!")]
        public string Name { get; set; } = string.Empty;// перша буква велика, не меньше 3 символи, не быльше 15)
        [DisplayName("Прізвище")]
        public string Surname { get; set; } = string.Empty;
        [DisplayName("Електронна пошта")]
        [EmailAddress(ErrorMessage = "Ви ввели не правильну вы")]

        public string? Email { get; set; }
        [DisplayName("День народження")]
        public DateTime Birthday { get; set; }

        public StudentGroup? StudentGroup { get; set; }
        public int StudentGroupId { get; set; }

    }
}
