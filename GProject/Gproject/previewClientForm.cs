using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Collections;

namespace Gproject
{
    public partial class previewClientForm : Form
    {
        private int editClientId;

        public previewClientForm(string[] _editClientArray, ArrayList _petsForSelectedClientId)
        {
            InitializeComponent();
            dataManipulation.changeColumnHeaderTxt(0, this.appointmentsJoinClientPreviewDataGridView);
            this.label1.Text = Properties.Resources.name;
            this.label2.Text = Properties.Resources.surName;
            this.label3.Text = Properties.Resources.address;
            this.label4.Text = Properties.Resources.phone;
            this.label5.Text = Properties.Resources.phone;
            this.label6.Text = Properties.Resources.email;
            this.label7.Text = Properties.Resources.pets;
            this.label8.Text = Properties.Resources.appointmentsForSelectedClient;
            this.button2.Text = Properties.Resources.cancel;
            this.Text = Properties.Resources.previewClient;    
            this.textBox1.Text = _editClientArray[0];
            this.textBox2.Text = _editClientArray[1];
            this.textBox3.Text = _editClientArray[2];
            this.textBox4.Text = _editClientArray[3];
            this.textBox5.Text = _editClientArray[4];
            this.textBox6.Text = _editClientArray[5];
            this.listBox1.DataSource = _petsForSelectedClientId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int setEditClientId
        {
            set { this.editClientId = value; }
        }

        private void previewClientForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'clinicDBDataSet.AppointmentsJoin' table. You can move, or remove it, as needed.
            this.appointmentsJoinTableAdapter.FillAppointmentsByClientId(this.clinicDBDataSet.AppointmentsJoin, this.editClientId);
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
