using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public int StudentGroupId { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {Surname}";
        }
    }
}
