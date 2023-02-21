using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Models
{
    /// <summary>
    /// 
    /// </summary>
    //[Table("stude")]
    //[Comment("Super student table")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[NotMapped]
        //[Column("Прізвище")]
        //[Column(TypeName = "varchar(250)")]
        [MaxLength(250)]
        public string Surname { get; set; }

        //[Precision(3,2)]
        //public double Everage { get; set; }
        //public int StudentGroupId { get; set; }

        public StudentGroup? StudentGroup { get; set; }
        public int? StudentGroupId { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {Surname}";
        }
    }
}
