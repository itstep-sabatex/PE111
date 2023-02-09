using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAdoNetDm.Models
{
    [Table(Name ="Student")]
    public class Student
    {

        [Column(Name="Id",IsPrimaryKey =true)]
        public int Id { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
        [Column(Name= "StudentGroupId")]
        public int? StudentGroupId { get; set; }
        public override string ToString()
        {
            return $"({Id}) {Name}";
        }

    }
}
