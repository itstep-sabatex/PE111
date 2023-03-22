using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAdoNetDm
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.StudentGroup' table. You can move, or remove it, as needed.
            this.studentGroupTableAdapter.Fill(this.dataSet1.StudentGroup);
            // TODO: This line of code loads data into the 'dataSet1.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.dataSet1.Student);

        }
    }
}
