using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Collections;

namespace Gproject
{
    public partial class previewPetForm : Form
    {
        private int editPetClientId;

        public previewPetForm(string[] _editPetArray, DateTime _petBirthDate, int _petClientId, string _petClientName = null, string _petClientSurName = null, string _petClientAddress = null, ArrayList _petNameAutoCmplt = null, ArrayList _petSpeciesAutoCmplt = null, [CallerMemberName]string callerMethodName = null)
        {
            InitializeComponent();

            dataManipulation.changeColumnHeaderTxt(0, this.appointmentsJoinPetPreviewDataGridView);

            this.Text = Properties.Resources.previewPet;   
            this.label1.Text = Properties.Resources.petName;
            this.label2.Text = Properties.Resources.petSpecies;
            this.label3.Text = Properties.Resources.petGender;
            this.label4.Text = Properties.Resources.petBirthDate;
            this.label5.Text = Properties.Resources.ownerName;
            this.label6.Text = Properties.Resources.ownerSurname;
            this.label7.Text = Properties.Resources.ownerAddress;
            this.label8.Text = Properties.Resources.appointmentsForSelectedClient;
            this.button2.Text = Properties.Resources.cancel;

            this.textBox1.Text = _editPetArray[0];
            this.textBox2.Text = _editPetArray[1];
            this.textBox3.Text = _editPetArray[2];                
            this.dateTimePicker1.Text = _petBirthDate.ToShortDateString();
            this.textBox5.Text = _petClientName;
            this.textBox6.Text = _petClientSurName;
            this.textBox7.Text = _petClientAddress;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void previewPetForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'clinicDBDataSet.AppointmentsJoin' table. You can move, or remove it, as needed.
            this.appointmentsJoinTableAdapter.FillAppointmentByPetId(this.clinicDBDataSet.AppointmentsJoin, this.editPetClientId);
        }

        public int setEditPetClientId
        {
            set { editPetClientId = value; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
