﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompetenceMatrix.entity;
using CompetenceMatrix.repository;
using CompetenceMatrix.Forms;

namespace CompetenceMatrix.Forms
{
    public partial class FormEmployeeConstructor : Form
    {
        Employee employee;
        List<Competence> competences;
        public FormEmployeeConstructor(Competence[] competences)
        {
            InitializeComponent();
            this.competences.AddRange(competences);
            AddCompetencesToCompetenceColumn(competences);
        }
        public FormEmployeeConstructor(Competence[] competences, Employee employee):this(competences)
        {
            this.employee = employee;
            SetEmployeToGridCompetenceList(employee);
        }
        void SetEmployeToGridCompetenceList(Employee employee)
        {
            TBNameCpmpetence.Text = employee.FullName;
            foreach (var item in employee.knowledges)
            {
                GridCompetenceList.Rows.Clear();
                GridCompetenceList.Rows.Add(item.Competence.Name, item.Level);
            }
        }
        private void NUDCountCompetence_ValueChanged(object sender, EventArgs e)
        {
            GridCompetenceList.RowCount = Convert.ToInt32(NUDCountCompetence.Value);
        }

        private void AddCompetence_Click(object sender, EventArgs e)
        {
            if (TBNameCpmpetence.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле \"Наименование компетенции\"", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Competence competence = Competence.addCompetence(TBNameCpmpetence.Text);
            competences.Add(competence);
            CompetenceColumn.Items.Add(competence.Name);
        }
        private void AddCompetencesToCompetenceColumn(Competence[] competences) =>
            CompetenceColumn.Items.AddRange(GetCompetencesName(competences));

        private string[] GetCompetencesName(Competence[] competences)
        {
            List<string> result = new List<string>();
            foreach (var item in competences)
            {
                result.Add(item.Name);
            }
            return result.ToArray();
        }

        private void BtnAddModel_Click(object sender, EventArgs e)
        {
            if (!AllCellsLevelColumnIsNumber())
            {
                return;
            }
            Employee employee = this.employee is null ? AddEmployee() : UpdateEmployee();
            MainForm form = (MainForm)Application.OpenForms[0];
            form.Employees.Add(employee);
            form.Show();
            Close();
        }
        private Employee AddEmployee()
        {
            Employee employee = Employee.addEmployee(TBNameModel.Text);
            for (int i = 0; i < GridCompetenceList.RowCount; i++)
            {
                Knowledge.addKnowledge(GetCompetenceByName(GridCompetenceList[0, i].Value.ToString()), employee);
            }
            return employee;
        }
        private Employee UpdateEmployee()
        {
            throw new NotImplementedException();
        }
        private Competence GetCompetenceByName(string name)
        {
            foreach (var item in competences)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            throw new Exception();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms[0];
            form.Show();
            Close();
        }
        private void GridCompetenceList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsNumber(GridCompetenceList[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                MessageBox.Show("Уровень владения компетенцией задаётся положительным числом!", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GridCompetenceList[e.ColumnIndex, e.RowIndex].Value = "";
            }
        }
        private bool IsNumber(string str)
        {
            foreach (var item in str)
            {
                if (!Char.IsDigit(item))
                {
                    return false;
                }
            }
            return true;
        }

        private bool AllCellsLevelColumnIsNumber()
        {
            MessageBox.Show("Уровень владения компетенцией задаётся положительным числом!" +
                " Внесите изменения в поле уровень владения, а затем ещё раз нажмите на кнопку сохранить",
                "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            for (int i = 0; i < GridCompetenceList.RowCount; i++)
            {
                if (!IsNumber(GridCompetenceList[1, i].Value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
