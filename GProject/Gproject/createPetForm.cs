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
    public partial class createPetForm : Form
    {
        private string createClientCaller = "btnAdd_Click";
        private string updateClientCaller = "btnEdit_Click";
        private clinicDBDataSetTableAdapters.PetsTableAdapter petsTableAdapter;
        private clinicDBDataSet clinicDBDataSet;
        private clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter clientsAutoCompleteTableAdapter;
        private clinicDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private string callerMethodName;
        private string name, species, gender, petBirthDate, clientName, clientSurName, clientAddress;
        private int clientId, editPetClientId;
        private clinicDBDataSetTableAdapters.ClientsTableAdapter petOwnerTableAdapter;
        private clinicDBDataSet.ClientsDataTable petOwnerDataTable;
        private bool textBoxValidate = true;
        private string[] genderArray = new string[2];
        private AutoCompleteStringCollection clientNameAutoCmpltSource, clientSurNameAutoCmpltSource, clientAddressAutoCmpltSource;

        public createPetForm(string[] _editPetArray, DateTime _petBirthDate, int _petClientId, string _petClientName = null, string _petClientSurName = null, string _petClientAddress = null, ArrayList _petNameAutoCmplt = null, ArrayList _petSpeciesAutoCmplt = null, [CallerMemberName]string callerMethodName = null)
        {
            InitializeComponent();

            AutoCompleteStringCollection petNameAutoCmpltSource = new AutoCompleteStringCollection();
            string[] petNameAutoCompleteStringArray = (string[])_petNameAutoCmplt.ToArray(typeof(string));
            petNameAutoCmpltSource.AddRange(petNameAutoCompleteStringArray);

            AutoCompleteStringCollection petSpeciesAutoCmpltSource = new AutoCompleteStringCollection();
            string[] petSpeciesAutoCompleteStringArray = (string[])_petSpeciesAutoCmplt.ToArray(typeof(string));
            petSpeciesAutoCmpltSource.AddRange(petSpeciesAutoCompleteStringArray);

            this.textBox1.AutoCompleteCustomSource = petNameAutoCmpltSource;
            this.textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.textBox2.AutoCompleteCustomSource = petSpeciesAutoCmpltSource;
            this.textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.clientNameAutoCmpltSource = new AutoCompleteStringCollection();
            this.textBox5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.clientSurNameAutoCmpltSource = new AutoCompleteStringCollection();
            this.textBox6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.clientAddressAutoCmpltSource = new AutoCompleteStringCollection();
            this.textBox7.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.callerMethodName = callerMethodName;
            this.label1.Text = Properties.Resources.petName;
            this.label2.Text = Properties.Resources.petSpecies;
            this.label3.Text = Properties.Resources.petGender;
            this.label4.Text = Properties.Resources.petBirthDate;
            this.label5.Text = Properties.Resources.ownerName;
            this.label6.Text = Properties.Resources.ownerSurname;
            this.label7.Text = Properties.Resources.ownerAddress;
            this.button1.Text = Properties.Resources.create;
            this.button2.Text = Properties.Resources.cancel;

            this.genderArray[0] = Properties.Resources.genderMale;
            this.genderArray[1] = Properties.Resources.genderFemale;
            this.comboBox1.Items.AddRange(this.genderArray);


            if (this.callerMethodName == this.createClientCaller)
            {
                this.Text = Properties.Resources.createPet;    
            }

            else if (this.callerMethodName == this.updateClientCaller)
            {
                this.Text = Properties.Resources.updatePet;
                this.textBox1.Text = _editPetArray[0];
                this.textBox2.Text = _editPetArray[1];
                this.comboBox1.Text = _editPetArray[2];                
                this.dateTimePicker1.Text = _petBirthDate.ToShortDateString();
                this.textBox5.Text = _petClientName;
                this.textBox6.Text = _petClientSurName;
                this.textBox7.Text = _petClientAddress;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.name = this.textBox1.Text;
            this.species = this.textBox2.Text;
            this.gender = this.comboBox1.Text;
            this.clientName = this.textBox5.Text;
            this.clientSurName = this.textBox6.Text;
            this.clientAddress = this.textBox7.Text;
            this.petBirthDate = this.dateTimePicker1.Text;
            this.clientId = dataManipulation.getClientIdForPets(this.clientsTableAdapter, this.clinicDBDataSet, this.clientName, this.clientSurName, this.clientAddress);
            this.textBoxValidate = true;

            if (this.clientName == String.Empty)
            {   
                this.textBox5.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.clientSurName == String.Empty)
            {
                this.textBox6.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.clientAddress == String.Empty)
            {
                this.textBox7.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.name == String.Empty)
            {
                this.textBox1.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.species == String.Empty)
            {
                this.textBox2.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.gender == String.Empty)
            {
                this.comboBox1.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }


            if (this.callerMethodName == this.createClientCaller && this.textBoxValidate == true)
            {
                if (this.clientId > 0)
                {
                    dataManipulation.insertPets(this.petsTableAdapter, this.clinicDBDataSet, this.name, this.species, this.gender, Convert.ToDateTime(this.petBirthDate), this.clientId);
                    this.petsTableAdapter.Fill(this.clinicDBDataSet.Pets);
                    this.Close();
                }

                else
                {
                    // throw error
                    // fill in error reporting
                    MessageBox.Show("Insert failed. Client not found");
                }
            }

            if (this.callerMethodName == this.updateClientCaller && this.textBoxValidate == true)
            {
                if (this.clientId > 0)
                {
                    dataManipulation.updatePets(this.petsTableAdapter, this.clinicDBDataSet, this.name, this.species, this.gender, Convert.ToDateTime(this.petBirthDate), this.clientId, this.editPetClientId);
                    this.petsTableAdapter.Fill(this.clinicDBDataSet.Pets);
                    this.Close();
                }

                else
                {
                    // throw error
                    // fill in error reporting
                    MessageBox.Show("Update failed. Client not found");
                }    
            }
        }

        public clinicDBDataSetTableAdapters.ClientsTableAdapter setClientsTableAdapter
        {
            set { this.clientsTableAdapter = value; }
        }

        public clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter setClientsAutoCompleteTableAdapter
        {
            set { this.clientsAutoCompleteTableAdapter = value; }
        }

        public clinicDBDataSetTableAdapters.PetsTableAdapter setPetsTableAdapter
        {
            set { this.petsTableAdapter = value; }
        }

        public clinicDBDataSet setclinicDBDataSet
        {
            set { clinicDBDataSet = value; }
        }

        public int setEditPetClientId
        {
            set { editPetClientId = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            this.textBox5.BackColor = Color.White;

            this.clinicDBDataSet.ClientsAutoComplete.Clear();

            if (this.textBox6.Text == String.Empty && this.textBox7.Text == String.Empty)
            {
                dataManipulation.getClientNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientNameAutoCompleteStringArray = (string[])autoCmpltName.ToArray(typeof(string));
                this.clientNameAutoCmpltSource.Clear();
                autoCmpltName.Clear();
                this.clientNameAutoCmpltSource.AddRange(clientNameAutoCompleteStringArray);
                this.textBox5.AutoCompleteCustomSource = clientNameAutoCmpltSource;
            }

            if (this.textBox6.Text != String.Empty && this.textBox7.Text == String.Empty)
            {
                dataManipulation.getClientNameWhereSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox6.Text);
                ArrayList autoCmpltName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientNameAutoCompleteStringArray = (string[])autoCmpltName.ToArray(typeof(string));
                this.clientNameAutoCmpltSource.Clear();
                autoCmpltName.Clear();
                this.clientNameAutoCmpltSource.AddRange(clientNameAutoCompleteStringArray);
                this.textBox5.AutoCompleteCustomSource = clientNameAutoCmpltSource;
            }

            if (this.textBox6.Text == String.Empty && this.textBox7.Text != String.Empty)
            {
                dataManipulation.getClientNameWhereAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox7.Text);
                ArrayList autoCmpltName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientNameAutoCompleteStringArray = (string[])autoCmpltName.ToArray(typeof(string));
                this.clientNameAutoCmpltSource.Clear();
                autoCmpltName.Clear();
                this.clientNameAutoCmpltSource.AddRange(clientNameAutoCompleteStringArray);
                this.textBox5.AutoCompleteCustomSource = clientNameAutoCmpltSource;
            }

            if (this.textBox6.Text != String.Empty && this.textBox7.Text != String.Empty)
            {
                dataManipulation.getClientNameWhereSurNameAndAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox6.Text, this.textBox7.Text);
                ArrayList autoCmpltName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientNameAutoCompleteStringArray = (string[])autoCmpltName.ToArray(typeof(string));
                this.clientNameAutoCmpltSource.Clear();
                autoCmpltName.Clear();
                this.clientNameAutoCmpltSource.AddRange(clientNameAutoCompleteStringArray);
                this.textBox5.AutoCompleteCustomSource = clientNameAutoCmpltSource;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            this.textBox6.BackColor = Color.White;

            this.clinicDBDataSet.ClientsAutoComplete.Clear();

            if (this.textBox5.Text == String.Empty && this.textBox7.Text == String.Empty)
            {
                // all
                dataManipulation.getClientSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientSurNameAutoCompleteStringArray = (string[])autoCmpltSurName.ToArray(typeof(string));
                this.clientSurNameAutoCmpltSource.Clear();
                autoCmpltSurName.Clear();
                this.clientSurNameAutoCmpltSource.AddRange(clientSurNameAutoCompleteStringArray);
                this.textBox6.AutoCompleteCustomSource = clientSurNameAutoCmpltSource;
            }

            if (this.textBox5.Text != String.Empty && this.textBox7.Text == String.Empty)
            {
                //  where name
                dataManipulation.getClientSurNameWhereNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox5.Text);
                ArrayList autoCmpltSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientSurNameAutoCompleteStringArray = (string[])autoCmpltSurName.ToArray(typeof(string));
                this.clientSurNameAutoCmpltSource.Clear();
                autoCmpltSurName.Clear();
                this.clientSurNameAutoCmpltSource.AddRange(clientSurNameAutoCompleteStringArray);
                this.textBox6.AutoCompleteCustomSource = clientSurNameAutoCmpltSource;
            }

            if (this.textBox5.Text == String.Empty && this.textBox7.Text != String.Empty)
            {
                // where address
                dataManipulation.getClientSurNameWhereAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox7.Text);
                ArrayList autoCmpltSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientSurNameAutoCompleteStringArray = (string[])autoCmpltSurName.ToArray(typeof(string));
                this.clientSurNameAutoCmpltSource.Clear();
                autoCmpltSurName.Clear();
                this.clientSurNameAutoCmpltSource.AddRange(clientSurNameAutoCompleteStringArray);
                this.textBox6.AutoCompleteCustomSource = clientSurNameAutoCmpltSource;
            }

            if (this.textBox5.Text != String.Empty && this.textBox7.Text != String.Empty)
            {
                // where name and address
                dataManipulation.getClientSurNameWhereSurNameAndAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox5.Text, this.textBox7.Text);
                ArrayList autoCmpltSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientSurNameAutoCompleteStringArray = (string[])autoCmpltSurName.ToArray(typeof(string));
                this.clientSurNameAutoCmpltSource.Clear();
                autoCmpltSurName.Clear();
                this.clientSurNameAutoCmpltSource.AddRange(clientSurNameAutoCompleteStringArray);
                this.textBox6.AutoCompleteCustomSource = clientSurNameAutoCmpltSource;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            this.textBox7.BackColor = Color.White;

            this.clinicDBDataSet.ClientsAutoComplete.Clear();

            if (this.textBox5.Text == String.Empty && this.textBox6.Text == String.Empty)
            {
                // all
                dataManipulation.getClientAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientAddressAutoCompleteStringArray = (string[])autoCmpltAddress.ToArray(typeof(string));
                this.clientAddressAutoCmpltSource.Clear();
                autoCmpltAddress.Clear();
                this.clientAddressAutoCmpltSource.AddRange(clientAddressAutoCompleteStringArray);
                this.textBox7.AutoCompleteCustomSource = clientAddressAutoCmpltSource;
            }

            if (this.textBox5.Text != String.Empty && this.textBox6.Text == String.Empty)
            {
                //where name
                dataManipulation.getClientAddressWhereNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox5.Text);
                ArrayList autoCmpltAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientAddressAutoCompleteStringArray = (string[])autoCmpltAddress.ToArray(typeof(string));
                this.clientAddressAutoCmpltSource.Clear();
                autoCmpltAddress.Clear();
                this.clientAddressAutoCmpltSource.AddRange(clientAddressAutoCompleteStringArray);
                this.textBox7.AutoCompleteCustomSource = clientAddressAutoCmpltSource;
            }

            if (this.textBox5.Text == String.Empty && this.textBox6.Text != String.Empty)
            {
                // where surname
                dataManipulation.getClientAddressWhereSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox6.Text);
                ArrayList autoCmpltAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientAddressAutoCompleteStringArray = (string[])autoCmpltAddress.ToArray(typeof(string));
                this.clientAddressAutoCmpltSource.Clear();
                autoCmpltAddress.Clear();
                this.clientAddressAutoCmpltSource.AddRange(clientAddressAutoCompleteStringArray);
                this.textBox7.AutoCompleteCustomSource = clientAddressAutoCmpltSource;
            }

            if (this.textBox5.Text != String.Empty && this.textBox6.Text != String.Empty)
            {
                // where name and surname
                dataManipulation.getClientAddressWhereNameAndSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox5.Text, this.textBox6.Text);
                ArrayList autoCmpltAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientAddressAutoCompleteStringArray = (string[])autoCmpltAddress.ToArray(typeof(string));
                this.clientAddressAutoCmpltSource.Clear();
                autoCmpltAddress.Clear();
                this.clientAddressAutoCmpltSource.AddRange(clientAddressAutoCompleteStringArray);
                this.textBox7.AutoCompleteCustomSource = clientAddressAutoCmpltSource;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.textBox1.BackColor = Color.White;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            this.textBox2.BackColor = Color.White;
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            this.comboBox1.BackColor = Color.White;
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

        private void createPetForm_Load(object sender, EventArgs e)
        {

        }

    }
}
