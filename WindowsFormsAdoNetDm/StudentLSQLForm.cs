using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAdoNetDm
{
    public partial class StudentLSQLForm : Form
    {
        public StudentLSQLForm()
        {
            InitializeComponent();
        }

        private void StudentLSQLForm_Load(object sender, EventArgs e)
        {
            DataContext dbContext = new DataContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pv111;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            var students = dbContext.GetTable<Models.Student>().OrderBy(o=>o.Name).ToArray();  
            bindingSource1.DataSource = students;
            dataGridView1.DataSource = bindingSource1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataContext dbContext = new DataContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pv111;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            var studentsTable= dbContext.GetTable<Models.Student>();

            var student = new Models.Student() {Id=4,Name="Wee weew wewew"};
            dbContext.GetTable<Models.Student>().InsertOnSubmit(student);
            dbContext.SubmitChanges();
            
            var students = dbContext.GetTable<Models.Student>().OrderBy(o => o.Name).ToArray();
            bindingSource1.DataSource = students;
            dataGridView1.DataSource = bindingSource1;


        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            DataContext dbContext = new DataContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pv111;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            var student = dbContext.GetTable<Models.Student>().SingleOrDefault(s=>s.Id==4);
            if (student != null )
            {
                dbContext.GetTable<Models.Student>().DeleteOnSubmit(student);
                dbContext.SubmitChanges();
            }
            var students = dbContext.GetTable<Models.Student>().OrderBy(o => o.Name).ToArray();
            bindingSource1.DataSource = students;
            dataGridView1.DataSource = bindingSource1;


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataContext dbContext = new DataContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pv111;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            var student = dbContext.GetTable<Models.Student>().SingleOrDefault(s => s.Id == 3);
            if (student != null)
            {
                student.Name = "Updated name";
                //dbContext.GetTable<Models.Student>(). DeleteOnSubmit(student);
                dbContext.SubmitChanges();
            }
            var students = dbContext.GetTable<Models.Student>().OrderBy(o => o.Name).ToArray();
            bindingSource1.DataSource = students;
            dataGridView1.DataSource = bindingSource1;

        }
    }
}
