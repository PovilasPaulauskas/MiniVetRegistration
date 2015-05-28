using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Gproject
{
    public partial class createAppointmentForm : Form
    {
        private string name, surName, address, petName, petGender, petSpecies, staffName, staffSurName, appointmentComment, appointmentDate, appointmentTime;
        private DateTime appointmentDateAndTime;
        private string[] gender = new string[2];
        private string callerMethodName;
        private string createClientCaller = "btnAdd_Click";
        private string updateClientCaller = "btnEdit_Click";
        private clinicDBDataSetTableAdapters.StaffTableAdapter staffTableAdapter;
        private clinicDBDataSetTableAdapters.PetsTableAdapter petsTableAdapter;
        private clinicDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private clinicDBDataSetTableAdapters.AppointmentsTableAdapter appointmentsTableAdapter;
        private clinicDBDataSetTableAdapters.AppointmentsJoinTableAdapter appointmentsJoinTableAdapter;
        private clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter clientsAutoCompleteTableAdapter;
        private clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter petsAutoCompleteTableAdapter;
        private clinicDBDataSet clinicDBDataSet;
        private int clientIdByQuery, petIdByQuery, staffIdByQuery, editAppointmentId;
        private bool checkBoxChecked;
        private bool textBoxValidate = true;
        private AutoCompleteStringCollection clientNameAutoCmpltSource, clientSurNameAutoCmpltSource, clientAddressAutoCmpltSource, petNameAutoCmpltSource, petSpeciesAutoCmpltSource, petGenderAutoCmpltSource;
        private DialogResult createNewClientResult;
        private int petSuggestCounter = 0;

        public createAppointmentForm(string[] _editAppointmentArray, ArrayList _staffNameArrayList = null, [CallerMemberName]string callerMethodName = null)
        {
            InitializeComponent();

            this.clientNameAutoCmpltSource = new AutoCompleteStringCollection();
            this.textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.clientSurNameAutoCmpltSource = new AutoCompleteStringCollection();
            this.textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.clientAddressAutoCmpltSource = new AutoCompleteStringCollection();
            this.textBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.petNameAutoCmpltSource = new AutoCompleteStringCollection();
            this.textBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.petSpeciesAutoCmpltSource = new AutoCompleteStringCollection();
            this.textBox5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.petGenderAutoCmpltSource = new AutoCompleteStringCollection();
            this.comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.callerMethodName = callerMethodName;
            this.label1.Text = Properties.Resources.date;
            this.label2.Text = Properties.Resources.ownerName;
            this.label3.Text = Properties.Resources.ownerSurname;
            this.label4.Text = Properties.Resources.ownerAddress;
            this.label5.Text = Properties.Resources.doctor;
            this.label6.Text = Properties.Resources.petName;
            this.label7.Text = Properties.Resources.petSpecies;
            this.label8.Text = Properties.Resources.petGender;
            this.label9.Text = Properties.Resources.comment;
            this.label10.Text = Properties.Resources.time;
            this.button1.Text = Properties.Resources.create;
            this.button2.Text = Properties.Resources.cancel;

            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(_staffNameArrayList.ToArray());
            this.gender[0] = Properties.Resources.genderMale;
            this.gender[1] = Properties.Resources.genderFemale;
            this.comboBox2.Items.AddRange(this.gender);

            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.CustomFormat = "HH:mm";

            if (this.callerMethodName == this.createClientCaller)
            {
                this.Text = Properties.Resources.createAppointment;
            }

            else if (this.callerMethodName == this.updateClientCaller)
            {
                this.Text = Properties.Resources.updateAppointment;
                //array elements: 0 - appointmentDate, 1 - appointmentComment, 2 - petName, 3 - petSpecies, 4 - petGender, 
                //5 - staffName , 6 - staffSurName, 7 - staffQualifications, 8 - clientName, 9 - clientSurName, 10 - clientAddress;
                this.dateTimePicker1.Text = Convert.ToDateTime(_editAppointmentArray[0]).ToString();
                this.dateTimePicker2.Text = Convert.ToDateTime(_editAppointmentArray[0]).TimeOfDay.ToString();
                this.textBox1.Text = _editAppointmentArray[8];
                this.textBox2.Text = _editAppointmentArray[9];
                this.textBox3.Text = _editAppointmentArray[10];
                this.comboBox1.Text = _editAppointmentArray[5] + ' ' + _editAppointmentArray[6];
                this.textBox4.Text = _editAppointmentArray[2];
                this.textBox5.Text = _editAppointmentArray[3];
                this.comboBox2.Text = _editAppointmentArray[4];
                this.textBox8.Text = _editAppointmentArray[1];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.appointmentDate = this.dateTimePicker1.Text;
            this.appointmentTime = this.dateTimePicker2.Text;
            this.appointmentDateAndTime = Convert.ToDateTime(this.appointmentDate).Add(Convert.ToDateTime(this.appointmentTime).TimeOfDay);
            this.name = this.textBox1.Text;
            this.surName = this.textBox2.Text;
            this.address = this.textBox3.Text;
            this.petName = this.textBox4.Text;
            this.petSpecies = this.textBox5.Text;
            this.petGender = this.comboBox2.Text;
            this.appointmentComment = this.textBox8.Text;
            this.textBoxValidate = true;

            if (this.comboBox1.Text == String.Empty)
            {
                this.staffName = String.Empty;
                this.staffSurName = String.Empty;
            }

            if (this.comboBox1.Text != String.Empty)
            {
                this.staffName = dataManipulation.getStaffNameOrSurname(this.comboBox1.Text, 0);
                this.staffSurName = dataManipulation.getStaffNameOrSurname(this.comboBox1.Text, 1);
            }

            this.staffIdByQuery = dataManipulation.getStaffIdNameSurnameQualifications(this.staffTableAdapter, this.clinicDBDataSet, this.staffName, this.staffSurName);
            this.clientIdByQuery = dataManipulation.getClientIdForPets(this.clientsTableAdapter, this.clinicDBDataSet, this.name, this.surName, this.address);

            if (this.textBox1.Text == String.Empty)
            {
                this.textBox1.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.textBox2.Text == String.Empty)
            {
                this.textBox2.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.textBox3.Text == String.Empty)
            {
                this.textBox3.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.comboBox1.Text == String.Empty)
            {
                this.comboBox1.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.callerMethodName == this.createClientCaller && this.textBoxValidate == true)
            {
                if (this.clientIdByQuery < 0)
                {
                    // fill in error reporting
                    // suggest to create new client.
                    createNewClientResult = MessageBox.Show(Properties.Resources.createClientResultForReal, Properties.Resources.createClientResultCaption, MessageBoxButtons.YesNo);
                }

                else
                {
                    if (this.petName == String.Empty && this.petSpecies == String.Empty && this.petGender == String.Empty)
                    {
                        // fill appointment without pet
                        dataManipulation.insertAppointmentsNoPets(this.appointmentsTableAdapter, this.clinicDBDataSet, this.staffIdByQuery, this.clientIdByQuery, this.appointmentComment, this.appointmentDateAndTime/*Convert.ToDateTime(this.appointmentDate)*/, 1);
                        if (this.checkBoxChecked == false)
                        {
                            this.appointmentsJoinTableAdapter.FillAppointmentFull(this.clinicDBDataSet.AppointmentsJoin);
                        }

                        if (this.checkBoxChecked == true)
                        {
                            this.appointmentsJoinTableAdapter.FillAppointmentJoinToday(this.clinicDBDataSet.AppointmentsJoin, DateTime.Now.Date, DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                        }

                        this.Close();
                    }

                    else
                    {
                        this.petIdByQuery = dataManipulation.getPetIdNameGenderSpeciesClientId(this.petsTableAdapter, this.clinicDBDataSet, this.petName, this.petSpecies, this.petGender, this.clientIdByQuery);

                        if (this.petIdByQuery < 0)
                        {
                            // fill in error reporting & suggest to create new client.
                            MessageBox.Show("Such pet, for this client, does not exist");
                        }

                        else
                        {
                            // fill in appointmentData
                            dataManipulation.insertAppointmentsWithPets(this.appointmentsTableAdapter, this.clinicDBDataSet, this.petIdByQuery, this.staffIdByQuery, this.clientIdByQuery, this.appointmentComment, this.appointmentDateAndTime/*Convert.ToDateTime(this.appointmentDate)*/, 1);
                            if (this.checkBoxChecked == false)
                            {
                                this.appointmentsJoinTableAdapter.FillAppointmentFull(this.clinicDBDataSet.AppointmentsJoin);
                            }

                            if (this.checkBoxChecked == true)
                            {
                                this.appointmentsJoinTableAdapter.FillAppointmentJoinToday(this.clinicDBDataSet.AppointmentsJoin, DateTime.Now.Date, DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                            }

                            this.Close();
                        }
                    }
                }
            }

            if (this.callerMethodName == this.updateClientCaller && this.textBoxValidate == true)
            {
                if (this.clientIdByQuery < 0)
                {
                    // fill in error reporting
                    // suggest to create new client.
                    createNewClientResult = MessageBox.Show(Properties.Resources.createClientResultForReal, Properties.Resources.createClientResultCaption, MessageBoxButtons.YesNo);
                }

                else
                {
                    if (this.petName == String.Empty && this.petSpecies == String.Empty && this.petGender == String.Empty)
                    {
                        // fill appointment without pet
                        dataManipulation.updateAppointmentsNoPets(this.appointmentsTableAdapter, this.clinicDBDataSet, this.staffIdByQuery, this.clientIdByQuery, this.appointmentComment, this.appointmentDateAndTime/*Convert.ToDateTime(this.appointmentDate)*/, 1, this.editAppointmentId);
                        if (this.checkBoxChecked == false)
                        {
                            this.appointmentsJoinTableAdapter.FillAppointmentFull(this.clinicDBDataSet.AppointmentsJoin);
                        }

                        if (this.checkBoxChecked == true)
                        {
                            this.appointmentsJoinTableAdapter.FillAppointmentJoinToday(this.clinicDBDataSet.AppointmentsJoin, DateTime.Now.Date, DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                        }

                        this.Close();
                    }

                    else
                    {
                        this.petIdByQuery = dataManipulation.getPetIdNameGenderSpeciesClientId(this.petsTableAdapter, this.clinicDBDataSet, this.petName, this.petSpecies, this.petGender, this.clientIdByQuery);

                        if (this.petIdByQuery < 0)
                        {
                            // fill in error reporting & suggest to create new client.
                            MessageBox.Show("Such pet, for this client, does not exist");
                        }

                        else
                        {
                            // fill in appointmentData
                            dataManipulation.updateAppointmentsWithPets(this.appointmentsTableAdapter, this.clinicDBDataSet, this.petIdByQuery, this.staffIdByQuery, this.clientIdByQuery, this.appointmentComment, this.appointmentDateAndTime /*Convert.ToDateTime(this.appointmentDate)*/, 1, this.editAppointmentId);
                            if (this.checkBoxChecked == false)
                            {
                                this.appointmentsJoinTableAdapter.FillAppointmentFull(this.clinicDBDataSet.AppointmentsJoin);
                            }

                            if (this.checkBoxChecked == true)
                            {
                                this.appointmentsJoinTableAdapter.FillAppointmentJoinToday(this.clinicDBDataSet.AppointmentsJoin, DateTime.Now.Date, DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                            }
                            this.Close();
                        }
                    }
                }
            }
        }

        public int setEditAppointmentId
        {
            set { editAppointmentId = value; }
        }

        public clinicDBDataSetTableAdapters.StaffTableAdapter setStaffTableAdapter
        {
            set { staffTableAdapter = value; }
        }

        public clinicDBDataSetTableAdapters.ClientsTableAdapter setClientsTableAdapter
        {
            set { clientsTableAdapter = value; }
        }

        public clinicDBDataSetTableAdapters.AppointmentsTableAdapter setAppointmentsTableAdapter
        {
            set { appointmentsTableAdapter = value; }
        }

        public clinicDBDataSetTableAdapters.AppointmentsJoinTableAdapter setAppointmentsJoinTableAdapter
        {
            set { appointmentsJoinTableAdapter = value; }
        }

        public clinicDBDataSetTableAdapters.PetsTableAdapter setPetsTableAdapter
        {
            set { petsTableAdapter = value; }
        }

        public clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter setClientsAutoCompleteTableAdapter
        {
            set { this.clientsAutoCompleteTableAdapter = value; }
        }

        public clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter setPetsAutoCompleteTableAdapter
        {
            set { this.petsAutoCompleteTableAdapter = value; }
        }

        public clinicDBDataSet setclinicDBDataSet
        {
            set { clinicDBDataSet = value; }
        }

        public bool getSetAppointmentDateTodayCheckBoxChecked
        {
            get { return checkBoxChecked; }
            set { checkBoxChecked = value; }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.textBox1.BackColor = Color.White;

            this.clinicDBDataSet.ClientsAutoComplete.Clear();

            if (this.textBox2.Text == String.Empty && this.textBox3.Text == String.Empty)
            {
                dataManipulation.getClientNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltClientName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientNameAutoCompleteStringArray = (string[])autoCmpltClientName.ToArray(typeof(string));
                this.clientNameAutoCmpltSource.Clear();
                autoCmpltClientName.Clear();
                this.clientNameAutoCmpltSource.AddRange(clientNameAutoCompleteStringArray);
                this.textBox1.AutoCompleteCustomSource = clientNameAutoCmpltSource;
            }

            if (this.textBox2.Text != String.Empty && this.textBox3.Text == String.Empty)
            {
                dataManipulation.getClientNameWhereSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox2.Text);
                ArrayList autoCmpltClientName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientNameAutoCompleteStringArray = (string[])autoCmpltClientName.ToArray(typeof(string));
                this.clientNameAutoCmpltSource.Clear();
                autoCmpltClientName.Clear();
                this.clientNameAutoCmpltSource.AddRange(clientNameAutoCompleteStringArray);
                this.textBox1.AutoCompleteCustomSource = clientNameAutoCmpltSource;
            }

            if (this.textBox2.Text == String.Empty && this.textBox3.Text != String.Empty)
            {
                dataManipulation.getClientNameWhereAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox3.Text);
                ArrayList autoCmpltClientName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientNameAutoCompleteStringArray = (string[])autoCmpltClientName.ToArray(typeof(string));
                this.clientNameAutoCmpltSource.Clear();
                autoCmpltClientName.Clear();
                this.clientNameAutoCmpltSource.AddRange(clientNameAutoCompleteStringArray);
                this.textBox1.AutoCompleteCustomSource = clientNameAutoCmpltSource;
            }

            if (this.textBox2.Text != String.Empty && this.textBox3.Text != String.Empty)
            {
                dataManipulation.getClientNameWhereSurNameAndAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox2.Text, this.textBox3.Text);
                ArrayList autoCmpltClientName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientNameAutoCompleteStringArray = (string[])autoCmpltClientName.ToArray(typeof(string));
                this.clientNameAutoCmpltSource.Clear();
                autoCmpltClientName.Clear();
                this.clientNameAutoCmpltSource.AddRange(clientNameAutoCompleteStringArray);
                this.textBox1.AutoCompleteCustomSource = clientNameAutoCmpltSource;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            this.textBox2.BackColor = Color.White;

            this.clinicDBDataSet.ClientsAutoComplete.Clear();

            if (this.textBox1.Text == String.Empty && this.textBox3.Text == String.Empty)
            {
                // all
                dataManipulation.getClientSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltClientSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientSurNameAutoCompleteStringArray = (string[])autoCmpltClientSurName.ToArray(typeof(string));
                this.clientSurNameAutoCmpltSource.Clear();
                autoCmpltClientSurName.Clear();
                this.clientSurNameAutoCmpltSource.AddRange(clientSurNameAutoCompleteStringArray);
                this.textBox2.AutoCompleteCustomSource = clientSurNameAutoCmpltSource;
            }

            if (this.textBox1.Text != String.Empty && this.textBox3.Text == String.Empty)
            {
                //  where name
                dataManipulation.getClientSurNameWhereNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox1.Text);
                ArrayList autoCmpltClientSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientSurNameAutoCompleteStringArray = (string[])autoCmpltClientSurName.ToArray(typeof(string));
                this.clientSurNameAutoCmpltSource.Clear();
                autoCmpltClientSurName.Clear();
                this.clientSurNameAutoCmpltSource.AddRange(clientSurNameAutoCompleteStringArray);
                this.textBox2.AutoCompleteCustomSource = clientSurNameAutoCmpltSource;
            }

            if (this.textBox1.Text == String.Empty && this.textBox3.Text != String.Empty)
            {
                // where address
                dataManipulation.getClientSurNameWhereAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox3.Text);
                ArrayList autoCmpltClientSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientSurNameAutoCompleteStringArray = (string[])autoCmpltClientSurName.ToArray(typeof(string));
                this.clientSurNameAutoCmpltSource.Clear();
                autoCmpltClientSurName.Clear();
                this.clientSurNameAutoCmpltSource.AddRange(clientSurNameAutoCompleteStringArray);
                this.textBox2.AutoCompleteCustomSource = clientSurNameAutoCmpltSource;
            }

            if (this.textBox1.Text != String.Empty && this.textBox3.Text != String.Empty)
            {
                // where name and address
                dataManipulation.getClientSurNameWhereSurNameAndAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox1.Text, this.textBox3.Text);
                ArrayList autoCmpltClientSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientSurNameAutoCompleteStringArray = (string[])autoCmpltClientSurName.ToArray(typeof(string));
                this.clientSurNameAutoCmpltSource.Clear();
                autoCmpltClientSurName.Clear();
                this.clientSurNameAutoCmpltSource.AddRange(clientSurNameAutoCompleteStringArray);
                this.textBox2.AutoCompleteCustomSource = clientSurNameAutoCmpltSource;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            this.textBox3.BackColor = Color.White;

            this.clinicDBDataSet.ClientsAutoComplete.Clear();

            if (this.textBox1.Text == String.Empty && this.textBox2.Text == String.Empty)
            {
                // all
                dataManipulation.getClientAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltClientAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientAddressAutoCompleteStringArray = (string[])autoCmpltClientAddress.ToArray(typeof(string));
                this.clientAddressAutoCmpltSource.Clear();
                autoCmpltClientAddress.Clear();
                this.clientAddressAutoCmpltSource.AddRange(clientAddressAutoCompleteStringArray);
                this.textBox3.AutoCompleteCustomSource = clientAddressAutoCmpltSource;
            }

            if (this.textBox1.Text != String.Empty && this.textBox2.Text == String.Empty)
            {
                //where name
                dataManipulation.getClientAddressWhereNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox1.Text);
                ArrayList autoCmpltClientAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientAddressAutoCompleteStringArray = (string[])autoCmpltClientAddress.ToArray(typeof(string));
                this.clientAddressAutoCmpltSource.Clear();
                autoCmpltClientAddress.Clear();
                this.clientAddressAutoCmpltSource.AddRange(clientAddressAutoCompleteStringArray);
                this.textBox3.AutoCompleteCustomSource = clientAddressAutoCmpltSource;
            }

            if (this.textBox1.Text == String.Empty && this.textBox2.Text != String.Empty)
            {
                // where surname
                dataManipulation.getClientAddressWhereSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox2.Text);
                ArrayList autoCmpltClientAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientAddressAutoCompleteStringArray = (string[])autoCmpltClientAddress.ToArray(typeof(string));
                this.clientAddressAutoCmpltSource.Clear();
                autoCmpltClientAddress.Clear();
                this.clientAddressAutoCmpltSource.AddRange(clientAddressAutoCompleteStringArray);
                this.textBox3.AutoCompleteCustomSource = clientAddressAutoCmpltSource;
            }

            if (this.textBox1.Text != String.Empty && this.textBox2.Text != String.Empty)
            {
                // where name and surname
                dataManipulation.getClientAddressWhereNameAndSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet, this.textBox1.Text, this.textBox2.Text);
                ArrayList autoCmpltClientAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);
                string[] clientAddressAutoCompleteStringArray = (string[])autoCmpltClientAddress.ToArray(typeof(string));
                this.clientAddressAutoCmpltSource.Clear();
                autoCmpltClientAddress.Clear();
                this.clientAddressAutoCmpltSource.AddRange(clientAddressAutoCompleteStringArray);
                this.textBox3.AutoCompleteCustomSource = clientAddressAutoCmpltSource;
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            this.comboBox1.BackColor = Color.White;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (this.textBox1.Text != String.Empty && this.textBox2.Text != String.Empty && this.textBox3.Text != String.Empty)
            {
                this.clientIdByQuery = dataManipulation.getClientIdForPets(this.clientsTableAdapter, this.clinicDBDataSet, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                this.fillInPetInfoAccordingClienId();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (this.textBox1.Text != String.Empty && this.textBox2.Text != String.Empty && this.textBox3.Text != String.Empty)
            {
                this.clientIdByQuery = dataManipulation.getClientIdForPets(this.clientsTableAdapter, this.clinicDBDataSet, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                this.fillInPetInfoAccordingClienId();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (this.textBox1.Text != String.Empty && this.textBox2.Text != String.Empty && this.textBox3.Text != String.Empty)
            {
                this.clientIdByQuery = dataManipulation.getClientIdForPets(this.clientsTableAdapter, this.clinicDBDataSet, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                this.fillInPetInfoAccordingClienId();
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (this.clientIdByQuery > 0)
            {
                if (this.textBox5.Text == String.Empty && this.comboBox2.Text == String.Empty)
                {
                    // all
                    dataManipulation.getPetNameAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery);
                    this.fillPetNameSource();
                }

                if (this.textBox5.Text != String.Empty && this.comboBox2.Text == String.Empty)
                {
                    // where species
                    dataManipulation.getPetsNameWhereSpeciesAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, this.textBox5.Text);
                    this.fillPetNameSource();
                }

                if (this.textBox5.Text == String.Empty && this.comboBox2.Text != String.Empty)
                {
                    // where gender
                    dataManipulation.getPetsNameWhereGenderAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, this.comboBox2.Text);
                    this.fillPetNameSource();
                }

                if (this.textBox5.Text != String.Empty && this.comboBox2.Text != String.Empty)
                {
                    // where species and gender
                    dataManipulation.getPetsNameWhereSpeciesGenderAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, this.comboBox2.Text, this.textBox5.Text);
                    this.fillPetNameSource();
                }
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (this.clientIdByQuery > 0)
            {
                if (this.textBox4.Text == String.Empty && this.comboBox2.Text == String.Empty)
                {
                    // all
                    dataManipulation.getPetSpeciesAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery);
                    this.fillPetSpeciesSource();
                }

                if (this.textBox4.Text != String.Empty && this.comboBox2.Text == String.Empty)
                {
                    // where name
                    dataManipulation.getPetsSpeciesWhereNameAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, this.textBox4.Text);
                    this.fillPetSpeciesSource();
                }

                if (this.textBox4.Text == String.Empty && this.comboBox2.Text != String.Empty)
                {
                    // where gender
                    dataManipulation.getPetsSpeciesWhereGenderAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, this.comboBox2.Text);
                    this.fillPetSpeciesSource();
                }

                if (this.textBox4.Text != String.Empty && this.comboBox2.Text != String.Empty)
                {
                    // where name and gender
                    dataManipulation.getPetsSpeciesWhereNameGenderAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, this.comboBox2.Text, this.textBox4.Text);
                    this.fillPetSpeciesSource();
                }
            }
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            if (this.clientIdByQuery > 0)
            {
                if (this.textBox4.Text == String.Empty && this.textBox5.Text == String.Empty)
                {
                    // all
                    dataManipulation.getPetGenderAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery);
                    this.fillPetGenderSource();
                }

                if (this.textBox4.Text != String.Empty && this.textBox5.Text == String.Empty)
                {
                    // where name
                    dataManipulation.getPetsGenderWhereNameAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, this.textBox4.Text);
                    this.fillPetGenderSource();
                }

                if (this.textBox4.Text == String.Empty && this.textBox5.Text != String.Empty)
                {
                    // where species
                    dataManipulation.getPetsGenderWhereSpeciesAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, this.textBox5.Text);
                    this.fillPetGenderSource();
                }

                if (this.textBox4.Text != String.Empty && this.textBox5.Text != String.Empty)
                {
                    // where name and species
                    dataManipulation.getPetsGenderWhereNameSpeciesAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, this.textBox5.Text, this.textBox4.Text);
                    this.fillPetGenderSource();
                }
            }
        }

        private void fillInPetInfoAccordingClienId()
        {
            if (this.clientIdByQuery > 0 && this.petSuggestCounter == 0)
            {
                dataManipulation.getPetNameAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery);
                ArrayList autoCmpltPetName = dataManipulation.autoCmpltPetNameArray(this.clinicDBDataSet.PetsAutoComplete);

                if (autoCmpltPetName.Count > 0)
                {
                    this.textBox4.Text = autoCmpltPetName[0].ToString();
                    dataManipulation.getPetsSpeciesWhereNameAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, autoCmpltPetName[0].ToString());
                    ArrayList autoCmpltPetSpecies = dataManipulation.autoCmpltPetSpeciesArray(this.clinicDBDataSet.PetsAutoComplete);

                    if (autoCmpltPetSpecies.Count > 0)
                    {
                        this.textBox5.Text = autoCmpltPetSpecies[0].ToString();
                        dataManipulation.getPetsGenderWhereNameSpeciesAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet, this.clientIdByQuery, autoCmpltPetSpecies[0].ToString(), autoCmpltPetName[0].ToString());
                        ArrayList autoCmpltPetGender = dataManipulation.autoCmpltPetGenderArray(this.clinicDBDataSet.PetsAutoComplete);

                        if (autoCmpltPetGender.Count > 0)
                        {
                            this.comboBox2.Text = autoCmpltPetGender[0].ToString(); 
                        }
                    }
                }

                this.petSuggestCounter = 1;
            }
        }

        private void fillPetNameSource()
        {
            ArrayList autoCmpltPetName = dataManipulation.autoCmpltPetNameArray(this.clinicDBDataSet.PetsAutoComplete);
            string[] petNameAutoCompleteStringArray = (string[])autoCmpltPetName.ToArray(typeof(string));
            this.petNameAutoCmpltSource.Clear();
            autoCmpltPetName.Clear();
            this.petNameAutoCmpltSource.AddRange(petNameAutoCompleteStringArray);
            this.textBox4.AutoCompleteCustomSource = petNameAutoCmpltSource;
        }

        private void fillPetSpeciesSource()
        {
            ArrayList autoCmpltPetSpecies = dataManipulation.autoCmpltPetSpeciesArray(this.clinicDBDataSet.PetsAutoComplete);
            string[] petSpeciesAutoCompleteStringArray = (string[])autoCmpltPetSpecies.ToArray(typeof(string));
            this.petSpeciesAutoCmpltSource.Clear();
            autoCmpltPetSpecies.Clear();
            this.petSpeciesAutoCmpltSource.AddRange(petSpeciesAutoCompleteStringArray);
            this.textBox5.AutoCompleteCustomSource = petSpeciesAutoCmpltSource;
        }

        private void fillPetGenderSource()
        {
            ArrayList autoCmpltPetGender = dataManipulation.autoCmpltPetGenderArray(this.clinicDBDataSet.PetsAutoComplete);
            string[] petGenderAutoCompleteStringArray = (string[])autoCmpltPetGender.ToArray(typeof(string));
            this.petGenderAutoCmpltSource.Clear();
            autoCmpltPetGender.Clear();
            this.petGenderAutoCmpltSource.AddRange(petGenderAutoCompleteStringArray);
            this.comboBox2.AutoCompleteCustomSource = petGenderAutoCmpltSource;
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

        private void createAppointmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
