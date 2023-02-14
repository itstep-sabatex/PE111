using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONet
{
    internal class StudentGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
    // 
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentGroupId { get; set; }
    }
}
