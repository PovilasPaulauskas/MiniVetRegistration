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
    public partial class createClientForm : Form
    {
        string name, surName, address, email, phone1, phone2;
        private string createClientCaller = "btnAdd_Click"; 
        private string updateClientCaller = "btnEdit_Click";
        private clinicDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private clinicDBDataSet clinicDBDataSet;
        bool textBoxValidate = true;                //2014-07-25 SM
        private string callerMethodName;
        private int editClientId;
        private string[] nameAutoCompleteStringArray, surNameAutoCompleteStringArray, addressAutoCompleteStringArray, emailAutoCompleteStringArray;

        public createClientForm(string[] _editClientArray, ArrayList _nameAutoCmplt = null, ArrayList _surNameAutoCmplt = null, ArrayList _addressAutoCmplt = null, ArrayList _emailAutoCmplt = null, [CallerMemberName]string callerMethodName = null)
        {
            InitializeComponent();

            AutoCompleteStringCollection nameAutoCmpltSource = new AutoCompleteStringCollection();
            this.nameAutoCompleteStringArray = (string[])_nameAutoCmplt.ToArray(typeof(string));
            nameAutoCmpltSource.AddRange(this.nameAutoCompleteStringArray);

            AutoCompleteStringCollection surNameAutoCmpltSource = new AutoCompleteStringCollection();
            this.surNameAutoCompleteStringArray = (string[])_surNameAutoCmplt.ToArray(typeof(string));
            surNameAutoCmpltSource.AddRange(this.surNameAutoCompleteStringArray);

            AutoCompleteStringCollection addressAutoCmpltSource = new AutoCompleteStringCollection();
            this.addressAutoCompleteStringArray = (string[])_addressAutoCmplt.ToArray(typeof(string));
            addressAutoCmpltSource.AddRange(this.addressAutoCompleteStringArray);

            AutoCompleteStringCollection emailAutoCmpltSource = new AutoCompleteStringCollection();
            this.emailAutoCompleteStringArray = (string[])_emailAutoCmplt.ToArray(typeof(string));
            emailAutoCmpltSource.AddRange(this.emailAutoCompleteStringArray);

            this.textBox1.AutoCompleteCustomSource = nameAutoCmpltSource;
            this.textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.textBox2.AutoCompleteCustomSource = surNameAutoCmpltSource;
            this.textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.textBox3.AutoCompleteCustomSource = addressAutoCmpltSource;
            this.textBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.textBox6.AutoCompleteCustomSource = emailAutoCmpltSource;
            this.textBox6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.callerMethodName = callerMethodName;
            this.label1.Text = Properties.Resources.name;
            this.label2.Text = Properties.Resources.surName;
            this.label3.Text = Properties.Resources.address;
            this.label4.Text = Properties.Resources.phone;
            this.label5.Text = Properties.Resources.phone;
            this.label6.Text = Properties.Resources.email;
            this.button1.Text = Properties.Resources.create;
            this.button2.Text = Properties.Resources.cancel;

            if (this.callerMethodName == this.createClientCaller)
            {
                this.Text = Properties.Resources.createClient;    
            }
                
            else if(this.callerMethodName == this.updateClientCaller)
            {
                this.Text = Properties.Resources.updateClient;
                this.textBox1.Text = _editClientArray[0];
                this.textBox2.Text = _editClientArray[1];
                this.textBox3.Text = _editClientArray[2];
                this.textBox4.Text = _editClientArray[3];
                this.textBox5.Text = _editClientArray[4];
                this.textBox6.Text = _editClientArray[5];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            this.name = textBox1.Text;
            this.surName = textBox2.Text;
            this.address = textBox3.Text;
            this.phone1 = textBox4.Text;
            this.phone2 = textBox5.Text;
            this.email = textBox6.Text;
            this.textBoxValidate = true;

            //2014-07-25 SM START
            if (this.name == String.Empty)
            {
                this.textBox1.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.surName == String.Empty)
            {
                this.textBox2.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.address == String.Empty)
            {
                this.textBox3.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.phone1 == String.Empty) 
            {
                this.textBox4.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.callerMethodName == this.createClientCaller && this.textBoxValidate == true)
            {
                dataManipulation.insertClients(this.clientsTableAdapter, this.clinicDBDataSet, this.name, this.surName, this.address, this.phone1, this.phone2, this.email);
                this.clientsTableAdapter.Fill(this.clinicDBDataSet.Clients);
                this.Close();
            }

            if (this.callerMethodName == this.updateClientCaller && this.textBoxValidate == true)
            {
                dataManipulation.updateClients(this.clientsTableAdapter, this.clinicDBDataSet, this.name, this.surName, this.address, this.phone1, this.phone2, this.email, this.editClientId);
                this.clientsTableAdapter.Fill(this.clinicDBDataSet.Clients);
                this.Close();    
            }
            //2014-07-25 SM END
        }

        public clinicDBDataSetTableAdapters.ClientsTableAdapter setClientsTableAdapter
        {
            set { this.clientsTableAdapter = value; }
        }

        public clinicDBDataSet setclinicDBDataSet
        {
            set { this.clinicDBDataSet = value; }
        }

        public int setEditClientId
        {
            set { this.editClientId = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.textBox1.BackColor = Color.White;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            this.textBox2.BackColor = Color.White;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            this.textBox3.BackColor = Color.White;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            this.textBox4.BackColor = Color.White;
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

        private void createClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
