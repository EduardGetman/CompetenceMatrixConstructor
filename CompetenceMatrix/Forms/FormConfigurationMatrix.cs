using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompetenceMatrix.entity;

namespace CompetenceMatrix.Forms
{
    public partial class FormConfigurationMatrix : Form
    {
        Position[] positions;
        Employee[] employees;
        Position SelectedPosition { get => positions[CBPositionName.SelectedIndex]; }
        Employee[] SuitableEmployees { 
            get
            {
                List<Employee> employees = new List<Employee>();
                foreach (var item in employees)
                {

                }
            }
        }
        public FormConfigurationMatrix(Position[] positions, Employee[] employees)
        {
            InitializeComponent();
            this.employees = employees;
            this.positions = positions;
            CBPositionName.Items.AddRange(GetPositionName());
            RBAllEmployee.Checked = true;
        }

        private void TBFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadioButtonsCheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChBSuitableEmployees_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CBPositionName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string[] GetPositionName()
        {
            List<string> result = new List<string>();
            foreach (var item in positions)
            {
                result.Add(item.Name);
            }
            return result.ToArray();
        }
    }
}
