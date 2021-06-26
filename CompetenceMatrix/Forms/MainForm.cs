﻿using CompetenceMatrix.entity;
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

        Position SelecetedPosition
        {
            get
            {
                if (GridModelList.Columns.Count == 0 || GridModelList.SelectedCells.Count == 0)
                {
                    return null;
                }
                if (GridModelList.SelectedCells[0].RowIndex > 0 && GridModelList.SelectedCells[0].RowIndex < Positions.Count)
                {
                    return Positions[GridModelList.SelectedCells[0].RowIndex];
                }
                return null;
            }
        }

        Employee SelecetedEmployee
        {
            get
            {
                if (GridModelList.Columns.Count == 0 || GridModelList.SelectedCells.Count == 0)
                {
                    return null;
                }
                if (GridModelList.SelectedCells[0].RowIndex > 0 && GridModelList.SelectedCells[0].RowIndex < Employees.Count)
                {
                    return Employees[GridModelList.SelectedCells[0].RowIndex];
                }
                return null;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Employees = new List<Employee>();
            Positions = new List<Position>();
            competences = new List<Competence>();
        }

        private void BtnShowWorker_Click(object sender, EventArgs e)
        {
            EmployeesSeleted = true;
            if (Employees.Count == 0)
            {
                return;
            }
            GridModelList.Rows.Clear();
            foreach (var item in Employees)
            {
                GridModelList.Rows.Add(item.FullName);
            }
        }

        private void BtnPositionShow_Click(object sender, EventArgs e)
        {
            EmployeesSeleted = false;
            if (Positions.Count == 0)
            {
                return;
            }
            GridModelList.Rows.Clear();
            foreach (var item in Positions)
            {
                GridModelList.Rows.Add(item.Name);
            }
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
                form = new FormEmployeeConstructor(competences.ToArray());
            }
            else
            {
                form = new FormPositionConstructor(competences.ToArray());
            }
            form.Show();
            Hide();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Employees.Count == 0 && Positions.Count == 0)
            {
                return;
            }
            if (EmployeesSeleted is null || GridModelList.SelectedCells is null)
            {
                MessageBox.Show("Выберите должность или сотрудника прежде чем удлить её",
                    "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (EmployeesSeleted == true)
            {
                Employee.DeleteEmployee(SelecetedEmployee.Id);
            }
            else
            {
                Employee.DeleteEmployee(SelecetedPosition.Id);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (Employees.Count == 0 && Positions.Count == 0)
            {
                return;
            }
            Form form;
            if (EmployeesSeleted is null || GridModelList.SelectedCells is null)
            {
                MessageBox.Show("Выберите должность или сотрудника прежде чем изменить её",
                    "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (EmployeesSeleted == true)
            {
                form = new FormEmployeeConstructor(competences.ToArray(),SelecetedEmployee);
            }
            else
            {
                form = new FormPositionConstructor(competences.ToArray(),SelecetedPosition);
            }
            form.Show();
            Hide();
        }

        private void GridModelList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Employees.Count == 0 && Positions.Count == 0)
            {
                return;
            }
            if (EmployeesSeleted is null || GridModelList.SelectedCells is null)
            {
                MessageBox.Show("Выберите должность или сотрудника прежде чем просмотреть его компетенции",
                    "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdateGridModelList();
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
            if (Visible && GridModelList.Rows.Count == 0)
            {
                UpdateGridModelList();
            }
        }

        private void UpdateGridModelList()
        {
            if (EmployeesSeleted == true)
            {
                SetModelToGridMatrixView(SelecetedEmployee);
            }
            else
            {
                SetModelToGridMatrixView(SelecetedPosition);
            }
        }

        private void BtnMatixConstruct_Click(object sender, EventArgs e)
        {
            if (Employees.Count == 0 && Positions.Count == 0)
            {
                return;
            }
            Form form = new FormConfigurationMatrix(Positions.ToArray(),Employees.ToArray());            
            form.Show();
            Hide();
        }
    }
}
