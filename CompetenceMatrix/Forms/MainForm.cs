using CompetenceMatrix.entity;
using CompetenceMatrix.ImplementationLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CompetenceMatrix.Forms;
using CompetenceMatrix.repository;

namespace CompetenceMatrix
{
    public partial class MainForm : Form
    {
        bool? EmployeesSeleted = null;
        public MatrixCompetence MatrixCompetence{ get; set; }
        public List<Employee> Employees { get; set; }
        public List<Position> Positions { get; set; }
        public List<Competence> competences { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnShowWorker_Click(object sender, EventArgs e)
        {
            GridModelList.Rows.Clear();
            foreach (var item in Employees)
            {
                GridModelList.Rows.Add(item.FullName);
            }
            EmployeesSeleted = true;
        }

        private void BtnPositionShow_Click(object sender, EventArgs e)
        {
            GridModelList.Rows.Clear();
            foreach (var item in Positions)
            {
                GridModelList.Rows.Add(item.Name);
            }
            EmployeesSeleted = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form form;
            if (EmployeesSeleted is null || GridModelList.SelectedCells is null)
            {
                MessageBox.Show("Выберите тип модели компетенций прежде прежде чем добавить её",
                    "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (EmployeesSeleted == true)
            {
                form = new FormAddingEmployee(competences.ToArray());
            }
            else
            {
                form = new FormAddingPosition(competences.ToArray());
            }
            form.Show();
            Hide();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void GridModelList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EmployeesSeleted is null || GridModelList.SelectedCells is null)
            {
                MessageBox.Show("Выберите должность или сотрудника прежде чем просмотреть его компетенции",
                    "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (EmployeesSeleted == true)
            {
                UpdateGridModelList();
            }
            else
            {
                UpdateGridModelList();
            }
        }

        private void SetModelToGridMatrixView(Employee employee)
        {
            foreach (var item in employee.knowledges)
            {
                DataTable table = ConstructDataTableByModel();
                table.Rows.Add(item.Competence.Name, item.Level.ToString());
            }
        }
        private void SetModelToGridMatrixView(Position position)
        {
            foreach (var item in position.Requirements)
            {
                DataTable table = ConstructDataTableByModel();
                table.Rows.Add(item.Competence.Name, item.Level.ToString());
            }
        }
        private DataTable ConstructDataTableByModel()
        {
            DataTable table = new DataTable("ModelCompetence");
            table.Columns.Add("Компетенция");
            table.Columns.Add("Уровень владения");
            return table;
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                UpdateGridModelList();
            }
        }

        private void UpdateGridModelList()
        {
            if (EmployeesSeleted == true)
            {
                SetModelToGridMatrixView(Employees[GridModelList.SelectedCells[0].RowIndex]);
            }
            else
            {
                SetModelToGridMatrixView(Positions[GridModelList.SelectedCells[0].RowIndex]);
            }
        }
    }
}
