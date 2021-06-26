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
using CompetenceMatrix.repository;
using CompetenceMatrix.Forms;

namespace CompetenceMatrix.Forms
{
    public partial class FormAddingPositiom : Form
    {
        List<Competence> competences;
        public FormAddingPositiom(Competence[] competences)
        {
            InitializeComponent();
            this.competences.AddRange(competences);
            AddCompetencesToCompetenceColumn(competences);
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
            Position position = Position.addPosition(TBNameModel.Text);
            for (int i = 0; i < GridCompetenceList.RowCount; i++)
            {
                Requirement.addRequirement(GetCompetenceByName(GridCompetenceList[0, i].Value.ToString()), position);
            }
            MainForm form = (MainForm)Application.OpenForms[0];
            form.Positions.Add(position);
            form.Show();
            Close();
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
    }
}
