using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompetenceMatrix.ImplementationLogic;
using CompetenceMatrix.entity;

namespace CompetenceMatrix
{
    public partial class MainForm : Form
    {

        public MatrixCompetence MatrixCompetence{ get; set; }
        public List<Employee> Employees { get; set; }
        public List<Position> Positions { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnShowWorker_Click(object sender, EventArgs e)
        {

        }

        private void BtnPositionShow_Click(object sender, EventArgs e)
        {

        }

        private void BntOpen_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
