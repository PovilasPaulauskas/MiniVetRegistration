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
using System.Windows.Forms;

namespace Gproject
{
    public partial class formMain : Form 
    {
        string statusArrive = Properties.Resources.arrived;
        string statusNotArrive = Properties.Resources.notArrived;
        string statusWaiting = Properties.Resources.waiting;
        string statusCanceled = Properties.Resources.canceled;
        enum status { statusArrive, statusNotArrive, statusWaiting, statusCanceled };
        private string[] editClientArray = new String[6]; // name, surName, address, phone1, phone2, email;
        private string[] editStaffArray = new String[7]; // name, surName, qualifications, address, phone1, phone2, email;
        private string[] editPetArray = new String[3]; //
        private string[] editAppointmentArray = new String[11];
        private int editClientId, editStaffId, editPetId, editAppointmentId;
        private DialogResult deleteButtonResult;
        private DateTime petBirthDate;
        private int petClientId;
        private string petClientName, petClientSurName, petClientAddress;
        private bool checkBoxChecked = false;
        private int visibleAppointmentJoinGridColumnCounter, visiblePetGridColumnCounter, visibleClientGridColumnCounter, visibleStaffGridColumnCounter;
        private TextBox[] appointmentJoinGridFilterTextBoxes, petGridFilterTextBoxes, clientGridFilterTextBoxes, staffGridFilterTextBoxes;
        private int appointmentJoinGridFilterTextBoxesLocationX, petGridFilterTextBoxesLocationX, clientGridFilterTextBoxesLocationX, staffGridFilterTextBoxesLocationX;
        private ArrayList appointmentJoinDGVColumnIndexArrayList, petDGVColumnIndexArrayList, clientDGVColumnIndexArrayList, staffDGVColumnIndexArrayList;
        private string appJoinFilterFullClause, petFilterFullClause, clientFilterFullClause, staffFilterFullClause;

        public formMain()
        {
            InitializeComponent();
            dataManipulation.changeColumnHeaderTxt(this.tabMainDisplay.SelectedIndex, this.appointmentDataGridView);
            this.checkBox1.Text = Properties.Resources.todayEntries;
            this.btnView.Enabled = false;

            this.btnAdd.Text = Properties.Resources.add;
            this.btnDelete.Text = Properties.Resources.delete;
            this.btnView.Text = Properties.Resources.viewBtn;
            this.btnEdit.Text = Properties.Resources.editBtn;
            this.tabPage1.Text = Properties.Resources.appointments;
            this.tabPage2.Text = Properties.Resources.clients;
            this.tabPage3.Text = Properties.Resources.pets;
            this.tabPage4.Text = Properties.Resources.staff;
            this.appointmentJoinDGVColumnIndexArrayList = new ArrayList();
            this.petDGVColumnIndexArrayList = new ArrayList();
            this.clientDGVColumnIndexArrayList = new ArrayList();
            this.staffDGVColumnIndexArrayList = new ArrayList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tabMainDisplay.SelectedIndex == 0)
            {
                this.staffDropDownTableAdapter.Connection.Open();
                this.staffDropDownTableAdapter.FillByNameSurname(this.clinicDBDataSet.StaffDropDown);
                this.staffDropDownTableAdapter.Connection.Close();
                
                ArrayList staffNameArrayList = new ArrayList();

                staffNameArrayList = this.fillStaffNameArray(staffNameArrayList);
                createAppointmentForm createAppointmentForm = new createAppointmentForm(editAppointmentArray, staffNameArrayList);
                createAppointmentForm.setClientsTableAdapter = this.clientsTableAdapter;
                createAppointmentForm.setStaffTableAdapter = this.staffTableAdapter;
                createAppointmentForm.setPetsTableAdapter = this.petsTableAdapter;
                createAppointmentForm.setAppointmentsTableAdapter = this.appointmentsTableAdapter;
                createAppointmentForm.setAppointmentsJoinTableAdapter = this.AppointmentsJoinTableAdapter;
                createAppointmentForm.setClientsAutoCompleteTableAdapter = this.clientsAutoCompleteTableAdapter;
                createAppointmentForm.setPetsAutoCompleteTableAdapter = this.petsAutoCompleteTableAdapter;
                createAppointmentForm.setclinicDBDataSet = this.clinicDBDataSet;
                
                createAppointmentForm.Show();
            }

            if (tabMainDisplay.SelectedIndex == 1)
            {
                // get data for auto complete textbox sources
                this.clinicDBDataSet.ClientsAutoComplete.Clear();
                dataManipulation.getClientNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);

                this.clinicDBDataSet.ClientsAutoComplete.Clear();
                dataManipulation.getClientSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);

                this.clinicDBDataSet.ClientsAutoComplete.Clear();
                dataManipulation.getClientAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);

                this.clinicDBDataSet.ClientsAutoComplete.Clear();
                dataManipulation.getClientEmailAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltEmail = dataManipulation.autoCmpltClientEmailArray(this.clinicDBDataSet.ClientsAutoComplete);

                createClientForm createClientForm = new createClientForm(this.editClientArray, autoCmpltName, autoCmpltSurName, autoCmpltAddress, autoCmpltEmail);
                createClientForm.setClientsTableAdapter = this.clientsTableAdapter;
                createClientForm.setclinicDBDataSet = this.clinicDBDataSet;
                createClientForm.Show();
            }

            if (tabMainDisplay.SelectedIndex == 2)
            {
                this.clinicDBDataSet.PetsAutoComplete.Clear();
                dataManipulation.getPetNameAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltPetName = dataManipulation.autoCmpltPetNameArray(this.clinicDBDataSet.PetsAutoComplete);

                this.clinicDBDataSet.PetsAutoComplete.Clear();
                dataManipulation.getPetSpeciesAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltPetSpecies = dataManipulation.autoCmpltPetSpeciesArray(this.clinicDBDataSet.PetsAutoComplete);

                createPetForm createPetForm = new createPetForm(this.editPetArray, this.petBirthDate, this.petClientId,null, null, null, autoCmpltPetName, autoCmpltPetSpecies);
                createPetForm.setPetsTableAdapter = this.petsTableAdapter;
                createPetForm.setClientsTableAdapter = this.clientsTableAdapter;
                createPetForm.setclinicDBDataSet = this.clinicDBDataSet;
                createPetForm.setClientsAutoCompleteTableAdapter = this.clientsAutoCompleteTableAdapter;
                createPetForm.Show();   
            }

            if (tabMainDisplay.SelectedIndex == 3)
            {
                // get data for auto complete textbox sources
                this.clinicDBDataSet.ClientsAutoComplete.Clear();
                dataManipulation.getClientNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);

                this.clinicDBDataSet.ClientsAutoComplete.Clear();
                dataManipulation.getClientSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);

                this.clinicDBDataSet.StaffDropDown.Clear();
                dataManipulation.getStaffQualificationAutoCmplt(this.staffDropDownTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltQualifications = dataManipulation.autoCmpltStaffQualificationsArray(this.clinicDBDataSet.StaffDropDown);

                this.clinicDBDataSet.ClientsAutoComplete.Clear();
                dataManipulation.getClientAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);

                this.clinicDBDataSet.ClientsAutoComplete.Clear();
                dataManipulation.getClientEmailAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                ArrayList autoCmpltEmail = dataManipulation.autoCmpltClientEmailArray(this.clinicDBDataSet.ClientsAutoComplete);

                createStaffForm createStaffForm = new createStaffForm(this.editStaffArray, autoCmpltName, autoCmpltSurName, autoCmpltAddress, autoCmpltEmail, autoCmpltQualifications);
                createStaffForm.setStaffTableAdapter = this.staffTableAdapter;
                createStaffForm.setclinicDBDataSet = this.clinicDBDataSet;
                createStaffForm.Show();
            }
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
            if (tabMainDisplay.SelectedIndex == 0)
            {
                if (this.appointmentDataGridView.CurrentCell != null && this.appointmentDataGridView.CurrentCell.RowIndex >= 0)
                {
                    try
                    {
                        this.staffDropDownTableAdapter.Connection.Open();
                        this.staffDropDownTableAdapter.FillByNameSurname(this.clinicDBDataSet.StaffDropDown);
                        this.staffDropDownTableAdapter.Connection.Close();

                        ArrayList staffNameArrayList = new ArrayList();

                        staffNameArrayList = this.fillStaffNameArray(staffNameArrayList);
                        createAppointmentForm updateAppointmentForm = new createAppointmentForm(editAppointmentArray, staffNameArrayList);
                        updateAppointmentForm.setClientsTableAdapter = this.clientsTableAdapter;
                        updateAppointmentForm.setStaffTableAdapter = this.staffTableAdapter;
                        updateAppointmentForm.setPetsTableAdapter = this.petsTableAdapter;
                        updateAppointmentForm.setAppointmentsTableAdapter = this.appointmentsTableAdapter;
                        updateAppointmentForm.setAppointmentsJoinTableAdapter = this.AppointmentsJoinTableAdapter;
                        updateAppointmentForm.setClientsAutoCompleteTableAdapter = this.clientsAutoCompleteTableAdapter;
                        updateAppointmentForm.setPetsAutoCompleteTableAdapter = this.petsAutoCompleteTableAdapter;
                        updateAppointmentForm.setclinicDBDataSet = this.clinicDBDataSet;
                        updateAppointmentForm.setEditAppointmentId = this.editAppointmentId;
                        updateAppointmentForm.getSetAppointmentDateTodayCheckBoxChecked = this.checkBoxChecked;
                        updateAppointmentForm.Show();
                    }
                    catch (Exception)
                    {
                        // do nothing
                        MessageBox.Show(Properties.Resources.errorMsgAppointmentData);
                    }    
                }
            }

            if (tabMainDisplay.SelectedIndex == 1)
            {

                if (this.clientsDataGridView.CurrentCell != null && this.clientsDataGridView.CurrentCell.RowIndex >= 0)
                {
                    try
                    {
                        // get data for auto complete textbox sources
                        this.clinicDBDataSet.ClientsAutoComplete.Clear();
                        dataManipulation.getClientNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);

                        this.clinicDBDataSet.ClientsAutoComplete.Clear();
                        dataManipulation.getClientSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);

                        this.clinicDBDataSet.ClientsAutoComplete.Clear();
                        dataManipulation.getClientAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);

                        this.clinicDBDataSet.ClientsAutoComplete.Clear();
                        dataManipulation.getClientEmailAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltEmail = dataManipulation.autoCmpltClientEmailArray(this.clinicDBDataSet.ClientsAutoComplete);

                        // this.clientsDataGridView.FirstDisplayedScrollingColumnIndex property to retain possition
                        createClientForm updateClientForm = new createClientForm(this.editClientArray, autoCmpltName, autoCmpltSurName, autoCmpltAddress, autoCmpltEmail);
                        updateClientForm.setClientsTableAdapter = this.clientsTableAdapter;
                        updateClientForm.setclinicDBDataSet = this.clinicDBDataSet;
                        updateClientForm.setEditClientId = this.editClientId;
                        updateClientForm.Show();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(Properties.Resources.errorMsgGettingClientID);
                    }
                }
            }

            if (tabMainDisplay.SelectedIndex == 2)
            {
                if (this.petsDataGridView.CurrentCell != null && this.petsDataGridView.CurrentCell.RowIndex >= 0)
                {
                    try
                    {
                        // -> NEEDS CHANGING
                        this.clinicDBDataSet.EnforceConstraints = false;
                        this.clientsTableAdapter.FillByID(this.clinicDBDataSet.Clients, this.petClientId);
                        this.petClientName = this.clinicDBDataSet.Clients.Rows[0]["ClientName"].ToString();
                        this.petClientSurName = this.clinicDBDataSet.Clients.Rows[0]["ClientSurname"].ToString();
                        this.petClientAddress = this.clinicDBDataSet.Clients.Rows[0]["ClientAddress"].ToString();
                        this.clientsTableAdapter.Fill(this.clinicDBDataSet.Clients);
                        this.clinicDBDataSet.EnforceConstraints = true;
                        // <- NEEDS CHANGING

                        this.clinicDBDataSet.PetsAutoComplete.Clear();
                        dataManipulation.getPetNameAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltPetName = dataManipulation.autoCmpltPetNameArray(this.clinicDBDataSet.PetsAutoComplete);

                        this.clinicDBDataSet.PetsAutoComplete.Clear();
                        dataManipulation.getPetSpeciesAutoCmplt(this.petsAutoCompleteTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltPetSpecies = dataManipulation.autoCmpltPetSpeciesArray(this.clinicDBDataSet.PetsAutoComplete);

                        createPetForm updatePetForm = new createPetForm(this.editPetArray, this.petBirthDate, this.petClientId, this.petClientName, this.petClientSurName, this.petClientAddress, autoCmpltPetName, autoCmpltPetSpecies);
                        updatePetForm.setPetsTableAdapter = this.petsTableAdapter;
                        updatePetForm.setClientsTableAdapter = this.clientsTableAdapter;
                        updatePetForm.setclinicDBDataSet = this.clinicDBDataSet;
                        updatePetForm.setEditPetClientId = this.editPetId;
                        updatePetForm.Show();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(Properties.Resources.errorMsgPetData);
                    }
                }
            }

            if (tabMainDisplay.SelectedIndex == 3)
            {
                if (this.staffDataGridView.CurrentCell != null && this.staffDataGridView.CurrentCell.RowIndex >= 0)
                {
                    try
                    {
                        // get data for auto complete textbox sources
                        this.clinicDBDataSet.ClientsAutoComplete.Clear();
                        dataManipulation.getClientNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltName = dataManipulation.autoCmpltClientNameArray(this.clinicDBDataSet.ClientsAutoComplete);

                        this.clinicDBDataSet.ClientsAutoComplete.Clear();
                        dataManipulation.getClientSurNameAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltSurName = dataManipulation.autoCmpltClientSurNameArray(this.clinicDBDataSet.ClientsAutoComplete);

                        this.clinicDBDataSet.StaffDropDown.Clear();
                        dataManipulation.getStaffQualificationAutoCmplt(this.staffDropDownTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltQualifications = dataManipulation.autoCmpltStaffQualificationsArray(this.clinicDBDataSet.StaffDropDown);

                        this.clinicDBDataSet.ClientsAutoComplete.Clear();
                        dataManipulation.getClientAddressAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltAddress = dataManipulation.autoCmpltClientAddressArray(this.clinicDBDataSet.ClientsAutoComplete);

                        this.clinicDBDataSet.ClientsAutoComplete.Clear();
                        dataManipulation.getClientEmailAutoCmplt(this.clientsAutoCompleteTableAdapter, this.clinicDBDataSet);
                        ArrayList autoCmpltEmail = dataManipulation.autoCmpltClientEmailArray(this.clinicDBDataSet.ClientsAutoComplete);

                        // this.clientsDataGridView.FirstDisplayedScrollingColumnIndex property to retain possition
                        createStaffForm updateStaffForm = new createStaffForm(this.editStaffArray, autoCmpltName, autoCmpltSurName, autoCmpltAddress, autoCmpltEmail, autoCmpltQualifications);
                        updateStaffForm.setStaffTableAdapter = this.staffTableAdapter;
                        updateStaffForm.setclinicDBDataSet = this.clinicDBDataSet;
                        updateStaffForm.setEditStaffId = this.editStaffId;
                        updateStaffForm.Show();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(Properties.Resources.errorMsgGettingStaffID);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tabMainDisplay.SelectedIndex == 0)
            {
                if (this.appointmentDataGridView.CurrentCell != null && this.appointmentDataGridView.CurrentCell.RowIndex >= 0)
                {
                    deleteButtonResult = MessageBox.Show(Properties.Resources.deleteEntryForReal, Properties.Resources.deleteEntryCaption, MessageBoxButtons.YesNo);
                    if (deleteButtonResult == DialogResult.Yes)
                    {
                        dataManipulation.deleteAppointments(this.appointmentsTableAdapter, this.clinicDBDataSet, this.editAppointmentArray[1], Convert.ToDateTime(this.editAppointmentArray[0]), this.editAppointmentId);
                        this.checkBox1_CheckedChanged(this, e);
                        this.appointmentJoinDataGridViewColor();
                    }    
                }
            }

            if (tabMainDisplay.SelectedIndex == 1) // clients
            {
                if (this.clientsDataGridView.CurrentCell != null && this.clientsDataGridView.CurrentCell.RowIndex >= 0)
                {
                    deleteButtonResult = MessageBox.Show(Properties.Resources.deleteEntryForReal, Properties.Resources.deleteEntryCaption, MessageBoxButtons.YesNo);
                    if (deleteButtonResult == DialogResult.Yes)
                    {
                        dataManipulation.deleteClients(this.clientsTableAdapter, this.petsTableAdapter, this.clinicDBDataSet, this.editClientArray[0], this.editClientArray[1], this.editClientArray[2], this.editClientArray[3], this.editClientArray[4], this.editClientArray[5], this.editClientId);

                        this.clinicDBDataSet.EnforceConstraints = false;
                        this.clientsTableAdapter.Fill(this.clinicDBDataSet.Clients);
                        this.petsTableAdapter.Fill(this.clinicDBDataSet.Pets);
                        this.AppointmentsJoinTableAdapter.FillAppointmentFull(this.clinicDBDataSet.AppointmentsJoin);
                        this.clinicDBDataSet.EnforceConstraints = true;
                    } 
                }
            }

            if (tabMainDisplay.SelectedIndex == 2)  // pets
            {
                if (this.petsDataGridView.CurrentCell != null && this.petsDataGridView.CurrentCell.RowIndex >= 0)
                {
                    deleteButtonResult = MessageBox.Show(Properties.Resources.deleteEntryForReal, Properties.Resources.deleteEntryCaption, MessageBoxButtons.YesNo);
                    if (deleteButtonResult == DialogResult.Yes)
                    {
                        dataManipulation.deletePets(this.petsTableAdapter, this.clinicDBDataSet, this.editPetArray[0], this.editPetArray[1], this.editPetArray[2], this.petBirthDate, this.petClientId, this.editPetId);

                        this.clinicDBDataSet.EnforceConstraints = false;
                        this.AppointmentsJoinTableAdapter.FillAppointmentFull(this.clinicDBDataSet.AppointmentsJoin);
                        this.petsTableAdapter.Fill(this.clinicDBDataSet.Pets);
                        this.clinicDBDataSet.EnforceConstraints = true;
                    }
                }
            }

            if (tabMainDisplay.SelectedIndex == 3)  // staff
            {
                if (this.staffDataGridView.CurrentCell != null && this.staffDataGridView.CurrentCell.RowIndex >= 0)
                {
                    deleteButtonResult = MessageBox.Show(Properties.Resources.deleteEntryForReal, Properties.Resources.deleteEntryCaption, MessageBoxButtons.YesNo);
                    if (deleteButtonResult == DialogResult.Yes)
                    {
                        dataManipulation.deleteStaff(this.staffTableAdapter, this.clinicDBDataSet, this.editStaffArray[0], this.editStaffArray[1], this.editStaffArray[2], this.editStaffArray[3], this.editStaffArray[4], this.editStaffArray[5], this.editStaffArray[6], this.editStaffId);

                        this.clinicDBDataSet.EnforceConstraints = false;
                        this.AppointmentsJoinTableAdapter.FillAppointmentFull(this.clinicDBDataSet.AppointmentsJoin);
                        this.staffTableAdapter.Fill(this.clinicDBDataSet.Staff);
                        this.clinicDBDataSet.EnforceConstraints = true;
                    }
                }
            }
        }

        private void tabMainDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {  
            if (this.tabMainDisplay.SelectedIndex == 0)         // appointments
            {
                dataManipulation.changeColumnHeaderTxt(this.tabMainDisplay.SelectedIndex, this.appointmentDataGridView);
                this.appointmentJoinDataGridViewColor();
                this.btnView.Enabled = false;
                this.checkBox1.Visible = true;
            }
            
            if (this.tabMainDisplay.SelectedIndex == 1)         // clients
            {
                dataManipulation.changeColumnHeaderTxt(this.tabMainDisplay.SelectedIndex, this.clientsDataGridView);
                this.btnView.Enabled = true;
                this.checkBox1.Visible = false;
            }

            if (this.tabMainDisplay.SelectedIndex == 2)         // pets
            {
                dataManipulation.changeColumnHeaderTxt(this.tabMainDisplay.SelectedIndex, this.petsDataGridView);
                this.btnView.Enabled = true;
                this.checkBox1.Visible = false;
            }

            if (this.tabMainDisplay.SelectedIndex == 3)         // staff
            {
                dataManipulation.changeColumnHeaderTxt(this.tabMainDisplay.SelectedIndex, this.staffDataGridView);
                this.btnView.Enabled = false;
                this.checkBox1.Visible = false;
            }
            
        }

        private void formMain_Load_1(object sender, EventArgs e)
        {
            this.petsAutoCompleteTableAdapter.FillByName(this.clinicDBDataSet.PetsAutoComplete);
            this.staffDropDownTableAdapter.FillByNameSurname(this.clinicDBDataSet.StaffDropDown);
            this.petsTableAdapter.Fill(this.clinicDBDataSet.Pets);
            this.clientsTableAdapter.Fill(this.clinicDBDataSet.Clients);
            this.AppointmentsJoinTableAdapter.FillAppointmentFull(this.clinicDBDataSet.AppointmentsJoin);
            this.appointmentJoinDataGridViewColor(); 
            this.staffTableAdapter.Fill(this.clinicDBDataSet.Staff);

            this.appointmentDataGridView.Columns[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldPetGender].Visible = false;
            this.appointmentDataGridView.Columns[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldStaffName].Visible = false;
            this.appointmentDataGridView.Columns[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldStaffQualification].Visible = false;
            this.appointmentDataGridView.Columns[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldClientPhone2].Visible = false;
            this.clientsDataGridView.Columns[Properties.Resources.clientDGV + Properties.Resources.dataBaseFieldID].Visible = false;
            this.petsDataGridView.Columns[Properties.Resources.petDGV + Properties.Resources.dataBaseFieldID].Visible = false;
            this.petsDataGridView.Columns[Properties.Resources.petDGV + Properties.Resources.dataBaseFieldClientID].Visible = false;
            this.staffDataGridView.Columns[Properties.Resources.staffDGV + Properties.Resources.dataBaseFieldID].Visible = false;

            // appointment grid filter boxes
            foreach (DataGridViewColumn column in this.appointmentDataGridView.Columns)
            {
                if (column.Visible == true)
                {
                    this.appointmentJoinDGVColumnIndexArrayList.Add(column.Index);
                }
            }

            this.appointmentJoinGridFilterTextBoxes = new TextBox[this.appointmentJoinDGVColumnIndexArrayList.Count];

            for (int i = 0; i < this.appointmentJoinDGVColumnIndexArrayList.Count; i++)
			{
			    this.visibleAppointmentJoinGridColumnCounter++;
                var textBox = new TextBox();
                this.appointmentJoinGridFilterTextBoxes[visibleAppointmentJoinGridColumnCounter - 1] = textBox;            // from local to public
                textBox.Name = Properties.Resources.filterTxtBox + this.appointmentDataGridView.Columns[(int)this.appointmentJoinDGVColumnIndexArrayList[i]].Name;
                textBox.Location = new Point(this.appointmentJoinGridFilterTextBoxesLocationX,0);
                textBox.Size = new Size(this.visibleAppointmentJoinGridColumnCounter == 1 ? this.appointmentDataGridView.Columns[(int)this.appointmentJoinDGVColumnIndexArrayList[i]].Width + 2 : this.appointmentDataGridView.Columns[(int)this.appointmentJoinDGVColumnIndexArrayList[i]].Width, 20);
                textBox.Visible = true;
                textBox.TabIndex = this.visibleAppointmentJoinGridColumnCounter;
                textBox.Leave += new EventHandler(appGridFilterTxtBoxLeaveEvent);
                textBox.KeyDown += new KeyEventHandler(appGridFilterTxtBoxKeyDownEvent);
                this.appointmentJoinGridFilterTextBoxesLocationX += textBox.Size.Width;
                
                this.tabPage1.Controls.Add(textBox);
			}

            // staff grid filter boxes
            foreach (DataGridViewColumn column in this.staffDataGridView.Columns)
            {
                if (column.Visible == true)
                {
                    this.staffDGVColumnIndexArrayList.Add(column.Index);
                }
            }

            this.staffGridFilterTextBoxes = new TextBox[this.staffDGVColumnIndexArrayList.Count];

            for (int i = 0; i < this.staffDGVColumnIndexArrayList.Count; i++)
            {
                this.visibleStaffGridColumnCounter++;
                var textBox = new TextBox();
                this.staffGridFilterTextBoxes[visibleStaffGridColumnCounter - 1] = textBox;            // from local to public
                textBox.Name = Properties.Resources.filterTxtBox + this.staffDataGridView.Columns[(int)this.staffDGVColumnIndexArrayList[i]].Name;
                textBox.Location = new Point(this.staffGridFilterTextBoxesLocationX, 0);
                textBox.Size = new Size(this.visibleStaffGridColumnCounter == 1 ? this.staffDataGridView.Columns[(int)this.staffDGVColumnIndexArrayList[i]].Width + 2 : this.staffDataGridView.Columns[(int)this.staffDGVColumnIndexArrayList[i]].Width, 20);
                textBox.Visible = true;
                textBox.Leave += new EventHandler(staffGridFilterTxtBoxLeaveEvent);
                textBox.KeyDown += new KeyEventHandler(staffGridFilterTxtBoxKeyDownEvent);
                textBox.TabIndex = this.visibleStaffGridColumnCounter;                
                this.staffGridFilterTextBoxesLocationX += textBox.Size.Width;

                this.tabPage4.Controls.Add(textBox);
            }

            // client grid filter boxes
            foreach (DataGridViewColumn column in this.clientsDataGridView.Columns)
            {
                if (column.Visible == true)
                {
                    this.clientDGVColumnIndexArrayList.Add(column.Index);
                }
            }

            this.clientGridFilterTextBoxes = new TextBox[this.clientDGVColumnIndexArrayList.Count];

            for (int i = 0; i < this.clientDGVColumnIndexArrayList.Count; i++)
            {
                this.visibleClientGridColumnCounter++;
                var textBox = new TextBox();
                this.clientGridFilterTextBoxes[visibleClientGridColumnCounter - 1] = textBox;            // from local to public
                textBox.Name = Properties.Resources.filterTxtBox + this.clientsDataGridView.Columns[(int)this.clientDGVColumnIndexArrayList[i]].Name;
                textBox.Location = new Point(this.clientGridFilterTextBoxesLocationX, 0);
                textBox.Size = new Size(this.visibleClientGridColumnCounter == 1 ? this.clientsDataGridView.Columns[(int)this.clientDGVColumnIndexArrayList[i]].Width + 2 : this.clientsDataGridView.Columns[(int)this.clientDGVColumnIndexArrayList[i]].Width, 20);
                textBox.Visible = true;
                textBox.Leave += new EventHandler(clientGridFilterTxtBoxLeaveEvent);
                textBox.KeyDown += new KeyEventHandler(clientGridFilterTxtBoxKeyDownEvent);
                textBox.TabIndex = this.visibleClientGridColumnCounter;                
                this.clientGridFilterTextBoxesLocationX += textBox.Size.Width;

                this.tabPage2.Controls.Add(textBox);
            }

            // pet grid filter boxes
            foreach (DataGridViewColumn column in this.petsDataGridView.Columns)
            {
                if (column.Visible == true)
                {                   
                    this.petDGVColumnIndexArrayList.Add(column.Index);
                }
            }

            this.petGridFilterTextBoxes = new TextBox[this.petDGVColumnIndexArrayList.Count];

            for (int i = 0; i < this.petDGVColumnIndexArrayList.Count; i++)
            {
                this.visiblePetGridColumnCounter++;
                var textBox = new TextBox();
                this.petGridFilterTextBoxes[visiblePetGridColumnCounter - 1] = textBox;            // from local to public
                textBox.Name = Properties.Resources.filterTxtBox + this.petsDataGridView.Columns[(int)this.petDGVColumnIndexArrayList[i]].Name;
                textBox.Location = new Point(this.petGridFilterTextBoxesLocationX, 0);
                textBox.Size = new Size(this.visiblePetGridColumnCounter == 1 ? this.petsDataGridView.Columns[(int)this.petDGVColumnIndexArrayList[i]].Width + 2 : this.petsDataGridView.Columns[(int)this.petDGVColumnIndexArrayList[i]].Width, 20);
                textBox.Visible = true;
                textBox.Leave += new EventHandler(petGridFilterTxtBoxLeaveEvent);
                textBox.KeyDown += new KeyEventHandler(petGridFilterTxtBoxKeyDownEvent);
                textBox.TabIndex = this.visiblePetGridColumnCounter;                
                this.petGridFilterTextBoxesLocationX += textBox.Size.Width;

                this.tabPage3.Controls.Add(textBox);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBox1.Checked)
            {
                this.AppointmentsJoinTableAdapter.FillAppointmentFull(this.clinicDBDataSet.AppointmentsJoin);
                this.checkBoxChecked = false;
            }

            else if (this.checkBox1.Checked)
            {
     //           MessageBox.Show(String.Format("{0}", DateTime.Now.Date));
     //           MessageBox.Show(String.Format("{0}", DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59)));
                this.AppointmentsJoinTableAdapter.FillAppointmentJoinToday(this.clinicDBDataSet.AppointmentsJoin, DateTime.Now.Date, DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                this.checkBoxChecked = true;
            }
        }

        private void appointmentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //array elements: 0 - appointmentDate, 1 - appointmentComment, 2 - petName, 3 - petSpecies, 4 - petGender, 
                //5 - staffName , 6 - staffSurName, 7 - staffQualifications, 8 - clientName, 9 - clientSurName, 10 - clientAddress;
                this.editAppointmentId = int.Parse(this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldID].Value.ToString());
                this.editAppointmentArray[0] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldAppointmentDate].Value.ToString();
                this.editAppointmentArray[1] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldComments].Value.ToString();
                this.editAppointmentArray[2] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldPetName].Value.ToString();
                this.editAppointmentArray[3] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldPetSpecies].Value.ToString();
                this.editAppointmentArray[4] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldPetGender].Value.ToString();
                this.editAppointmentArray[5] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldStaffName].Value.ToString();
                this.editAppointmentArray[6] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldStaffSurname].Value.ToString();
                this.editAppointmentArray[7] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldStaffQualification].Value.ToString();
                this.editAppointmentArray[8] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldClientName].Value.ToString();
                this.editAppointmentArray[9] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldClientSurname].Value.ToString();
                this.editAppointmentArray[10] = this.appointmentDataGridView.Rows[this.appointmentDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.appointmentJoinDGV + Properties.Resources.dataBaseFieldClientAddress].Value.ToString();
            }

            catch (Exception)
            {
                // do nothing
            }
        }

        private void clientsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.editClientId = int.Parse(this.clientsDataGridView.Rows[this.clientsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.clientDGV + Properties.Resources.dataBaseFieldID].Value.ToString());
                this.editClientArray[0] = this.clientsDataGridView.Rows[this.clientsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.clientDGV + Properties.Resources.dataBaseFieldClientName].Value.ToString();
                this.editClientArray[1] = this.clientsDataGridView.Rows[this.clientsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.clientDGV + Properties.Resources.dataBaseFieldClientSurname].Value.ToString();
                this.editClientArray[2] = this.clientsDataGridView.Rows[this.clientsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.clientDGV + Properties.Resources.dataBaseFieldClientAddress].Value.ToString();
                this.editClientArray[3] = this.clientsDataGridView.Rows[this.clientsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.clientDGV + Properties.Resources.dataBaseFieldClientPhone1].Value.ToString();
                this.editClientArray[4] = this.clientsDataGridView.Rows[this.clientsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.clientDGV + Properties.Resources.dataBaseFieldClientPhone2].Value.ToString();
                this.editClientArray[5] = this.clientsDataGridView.Rows[this.clientsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.clientDGV + Properties.Resources.dataBaseFieldClientEmail].Value.ToString();
            }

            catch (Exception)
            {
                // do nothing
            }
        }

        private void staffDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.editStaffId = int.Parse(this.staffDataGridView.Rows[this.staffDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.staffDGV + Properties.Resources.dataBaseFieldID].Value.ToString());
                this.editStaffArray[0] = this.staffDataGridView.Rows[this.staffDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.staffDGV + Properties.Resources.dataBaseFieldStaffName].Value.ToString();
                this.editStaffArray[1] = this.staffDataGridView.Rows[this.staffDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.staffDGV + Properties.Resources.dataBaseFieldStaffSurname].Value.ToString();
                this.editStaffArray[2] = this.staffDataGridView.Rows[this.staffDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.staffDGV + Properties.Resources.dataBaseFieldStaffQualification].Value.ToString();
                this.editStaffArray[3] = this.staffDataGridView.Rows[this.staffDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.staffDGV + Properties.Resources.dataBaseFieldStaffAddress].Value.ToString();
                this.editStaffArray[4] = this.staffDataGridView.Rows[this.staffDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.staffDGV + Properties.Resources.dataBaseFieldStaffPhone1].Value.ToString();
                this.editStaffArray[5] = this.staffDataGridView.Rows[this.staffDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.staffDGV + Properties.Resources.dataBaseFieldStaffPhone2].Value.ToString();
                this.editStaffArray[6] = this.staffDataGridView.Rows[this.staffDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.staffDGV + Properties.Resources.dataBaseFieldStaffEmail].Value.ToString();
            }

            catch (Exception)
            {
                // do nothing
            }
        }

        private void petsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //0 id 1 name 2 species 3 lytis 4 data 5 clientId
            try
            {
                this.editPetId = int.Parse(this.petsDataGridView.Rows[this.petsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.petDGV + Properties.Resources.dataBaseFieldID].Value.ToString());
                this.editPetArray[0] = this.petsDataGridView.Rows[this.petsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.petDGV + Properties.Resources.dataBaseFieldPetName].Value.ToString();
                this.editPetArray[1] = this.petsDataGridView.Rows[this.petsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.petDGV + Properties.Resources.dataBaseFieldPetSpecies].Value.ToString();
                this.editPetArray[2] = this.petsDataGridView.Rows[this.petsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.petDGV + Properties.Resources.dataBaseFieldPetGender].Value.ToString();
                this.petBirthDate = DateTime.Parse(this.petsDataGridView.Rows[this.petsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.petDGV + Properties.Resources.dataBaseFieldPetBirthDate].Value.ToString());
                this.petClientId = int.Parse(this.petsDataGridView.Rows[this.petsDataGridView.CurrentCell.RowIndex].Cells[Properties.Resources.petDGV + Properties.Resources.dataBaseFieldClientID].Value.ToString());
            }

            catch (Exception)
            {
                // do nothing
            }
        }

        private void appointmentJoinDataGridViewColor()
        {
            foreach (DataGridViewRow row in this.appointmentDataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[dataManipulation.getColumnIdByPropertyName(this.appointmentDataGridView, Properties.Resources.dataBaseFieldStaffName)].Value.ToString() == String.Empty &&
                        row.Cells[dataManipulation.getColumnIdByPropertyName(this.appointmentDataGridView, Properties.Resources.dataBaseFieldStaffSurname)].Value.ToString() == String.Empty &&
                        row.Cells[dataManipulation.getColumnIdByPropertyName(this.appointmentDataGridView, Properties.Resources.dataBaseFieldStaffQualification)].Value.ToString() == String.Empty)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                }
            }
        }

        private ArrayList fillStaffNameArray(ArrayList _staffNameArrayList)
        {
            var counter = 0;
            foreach (DataRow row in this.clinicDBDataSet.StaffDropDown.Rows)
            {
                if (row != null)
                {
                    _staffNameArrayList.Add(this.clinicDBDataSet.StaffDropDown.Rows[counter][Properties.Resources.dataBaseFieldStaffName].ToString() + " " + this.clinicDBDataSet.StaffDropDown.Rows[counter][Properties.Resources.dataBaseFieldStaffSurname].ToString());
                }
                counter++;
            }

            return _staffNameArrayList;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (tabMainDisplay.SelectedIndex == 0)
            {

            }

            if (tabMainDisplay.SelectedIndex == 1)      // clients
            {
                if (this.clientsDataGridView.CurrentCell != null && this.clientsDataGridView.CurrentCell.RowIndex >= 0)
                {
                    try
                    {
                        clinicDBDataSet.PetsDataTable petsDataTableByClientId;
                        petsDataTableByClientId = this.petsTableAdapter.PetsSelectGetDataByClientId(this.editClientId);
                        previewClientForm previewClientForm = new previewClientForm(this.editClientArray, dataManipulation.getFullPetInfoList(petsDataTableByClientId));
                        previewClientForm.setEditClientId = this.editClientId;
                        previewClientForm.Show();
                    }
                    catch (Exception)
                    {
                        // do nothing
                        MessageBox.Show(Properties.Resources.errorMsgGettingClientID);
                    }
                }
            }                        

            if (tabMainDisplay.SelectedIndex == 2)      // pets
            {
                if (this.petsDataGridView.CurrentCell != null && this.petsDataGridView.CurrentCell.RowIndex >= 0)
                {
                    try
                    {
                        // -> NEEDS CHANGING
                        this.clinicDBDataSet.EnforceConstraints = false;
                        this.clientsTableAdapter.FillByID(this.clinicDBDataSet.Clients, this.petClientId);
                        this.petClientName = this.clinicDBDataSet.Clients.Rows[0][Properties.Resources.dataBaseFieldClientName].ToString();
                        this.petClientSurName = this.clinicDBDataSet.Clients.Rows[0][Properties.Resources.dataBaseFieldClientSurname].ToString();
                        this.petClientAddress = this.clinicDBDataSet.Clients.Rows[0][Properties.Resources.dataBaseFieldClientAddress].ToString();
                        this.clientsTableAdapter.Fill(this.clinicDBDataSet.Clients);
                        this.clinicDBDataSet.EnforceConstraints = true;
                        // <- NEEDS CHANGING

                        previewPetForm previewPetForm = new previewPetForm(this.editPetArray, this.petBirthDate, this.petClientId, this.petClientName, this.petClientSurName, this.petClientAddress);
                        previewPetForm.setEditPetClientId = this.editPetId;
                        previewPetForm.Show();
                    }
                    catch (Exception)
                    {
                        // do nothing
                        MessageBox.Show(Properties.Resources.errorMsgPetData);
                    }
                }
            }

            if (tabMainDisplay.SelectedIndex == 3)
            {

            }
        }

        private void appointmentDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (this.appointmentJoinGridFilterTextBoxes != null)
            {
                for (int i = 0; i < this.appointmentJoinDGVColumnIndexArrayList.Count; i++)
                {
                    this.appointmentJoinGridFilterTextBoxes[i].Location = new Point(i == 0 ? 0 : this.appointmentJoinGridFilterTextBoxes[i - 1].Location.X + this.appointmentJoinGridFilterTextBoxes[i - 1].Width, 0);
                    this.appointmentJoinGridFilterTextBoxes[i].Width = (i == 0 ? this.appointmentDataGridView.Columns[(int)this.appointmentJoinDGVColumnIndexArrayList[i]].Width + 2 : this.appointmentDataGridView.Columns[(int)this.appointmentJoinDGVColumnIndexArrayList[i]].Width);
                }
            } 
        }
 
        private void clientsDataGridView_ColumnWidthChanged(object sender, System.Windows.Forms.DataGridViewColumnEventArgs e)
        {
            if (this.clientGridFilterTextBoxes != null)
            {
                for (int i = 0; i < this.clientDGVColumnIndexArrayList.Count; i++)
                {
                    this.clientGridFilterTextBoxes[i].Location = new Point(i == 0 ? 0 : this.clientGridFilterTextBoxes[i - 1].Location.X + this.clientGridFilterTextBoxes[i - 1].Width, 0);
                    this.clientGridFilterTextBoxes[i].Width = (i == 0 ? this.clientsDataGridView.Columns[(int)this.clientDGVColumnIndexArrayList[i]].Width + 2 : this.clientsDataGridView.Columns[(int)this.clientDGVColumnIndexArrayList[i]].Width);
                }
            } 
        }

        private void petsDataGridView_ColumnWidthChanged(object sender, System.Windows.Forms.DataGridViewColumnEventArgs e)
        {
            if (this.petGridFilterTextBoxes != null)
            {
                for (int i = 0; i < this.petDGVColumnIndexArrayList.Count; i++)
                {
                    this.petGridFilterTextBoxes[i].Location = new Point(i == 0 ? 0 : this.petGridFilterTextBoxes[i - 1].Location.X + this.petGridFilterTextBoxes[i - 1].Width, 0);
                    this.petGridFilterTextBoxes[i].Width = (i == 0 ? this.petsDataGridView.Columns[(int)this.petDGVColumnIndexArrayList[i]].Width + 2 : this.petsDataGridView.Columns[(int)this.petDGVColumnIndexArrayList[i]].Width);
                }
            } 
        }

        private void staffDataGridView_ColumnWidthChanged(object sender, System.Windows.Forms.DataGridViewColumnEventArgs e)
        {
            if (this.staffGridFilterTextBoxes != null)
            {
                for (int i = 0; i < this.staffDGVColumnIndexArrayList.Count; i++)
                {
                    this.staffGridFilterTextBoxes[i].Location = new Point(i == 0 ? 0 : this.staffGridFilterTextBoxes[i - 1].Location.X + this.staffGridFilterTextBoxes[i - 1].Width, 0);
                    this.staffGridFilterTextBoxes[i].Width = (i == 0 ? this.staffDataGridView.Columns[(int)this.staffDGVColumnIndexArrayList[i]].Width + 2 : this.staffDataGridView.Columns[(int)this.staffDGVColumnIndexArrayList[i]].Width);
                }
            } 
        }

        private void appGridFilterTxtBoxLeaveEvent(object sender, EventArgs e)
        {
            this.appJoinFilterFullClause = String.Empty;
            this.appJoinFilterFullClause = dataManipulation.createGridFilterClause(this.appointmentJoinGridFilterTextBoxes, Properties.Resources.filterTxtBox + Properties.Resources.appointmentJoinDGV);

            if (this.appJoinFilterFullClause == String.Empty)
            {
                this.AppointmentsJoinBindingSource.RemoveFilter();    
            }
            else
            {
                dataManipulation.filterBindingSource(this.AppointmentsJoinBindingSource, this.appJoinFilterFullClause);
            }
        }

        private void appGridFilterTxtBoxKeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.appJoinFilterFullClause = String.Empty;
                this.appJoinFilterFullClause = dataManipulation.createGridFilterClause(this.appointmentJoinGridFilterTextBoxes, Properties.Resources.filterTxtBox + Properties.Resources.appointmentJoinDGV);

                if (this.appJoinFilterFullClause == String.Empty)
                {
                    this.AppointmentsJoinBindingSource.RemoveFilter();
                }
                else
                {
                    dataManipulation.filterBindingSource(this.AppointmentsJoinBindingSource, this.appJoinFilterFullClause);
                }
            }

            else if (e.KeyCode == Keys.Escape)
            {
                this.AppointmentsJoinBindingSource.RemoveFilter();
                for (int i = 0; i < this.appointmentJoinGridFilterTextBoxes.Count(); i++)
                {
                    this.appointmentJoinGridFilterTextBoxes[i].Text = String.Empty;
                }
            }
        }

        private void staffGridFilterTxtBoxLeaveEvent(object sender, EventArgs e)
        {
            this.staffFilterFullClause = String.Empty;
            this.staffFilterFullClause = dataManipulation.createGridFilterClause(this.staffGridFilterTextBoxes, Properties.Resources.filterTxtBox + Properties.Resources.staffDGV);

            if (this.staffFilterFullClause == String.Empty)
            {
                this.staffBindingSource.RemoveFilter();
            }
            else
            {
                dataManipulation.filterBindingSource(this.staffBindingSource, this.staffFilterFullClause);
            }
        }

        private void staffGridFilterTxtBoxKeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.staffFilterFullClause = String.Empty;
                this.staffFilterFullClause = dataManipulation.createGridFilterClause(this.staffGridFilterTextBoxes, Properties.Resources.filterTxtBox + Properties.Resources.staffDGV);

                if (this.staffFilterFullClause == String.Empty)
                {
                    this.staffBindingSource.RemoveFilter();
                }
                else
                {
                    dataManipulation.filterBindingSource(this.staffBindingSource, this.staffFilterFullClause);
                }
            }

            else if (e.KeyCode == Keys.Escape)
            {
                this.staffBindingSource.RemoveFilter();
                for (int i = 0; i < this.staffGridFilterTextBoxes.Count(); i++)
                {
                    this.staffGridFilterTextBoxes[i].Text = String.Empty;
                }
            }
        }

        private void clientGridFilterTxtBoxLeaveEvent(object sender, EventArgs e)
        {
            this.clientFilterFullClause = String.Empty;
            this.clientFilterFullClause = dataManipulation.createGridFilterClause(this.clientGridFilterTextBoxes, Properties.Resources.filterTxtBox + Properties.Resources.clientDGV);

            if (this.clientFilterFullClause == String.Empty)
            {
                this.clientsBindingSource.RemoveFilter();
            }
            else
            {
                dataManipulation.filterBindingSource(this.clientsBindingSource, this.clientFilterFullClause);
            }
        }

        private void clientGridFilterTxtBoxKeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.clientFilterFullClause = String.Empty;
                this.clientFilterFullClause = dataManipulation.createGridFilterClause(this.clientGridFilterTextBoxes, Properties.Resources.filterTxtBox + Properties.Resources.clientDGV);

                if (this.clientFilterFullClause == String.Empty)
                {
                    this.clientsBindingSource.RemoveFilter();
                }
                else
                {
                    dataManipulation.filterBindingSource(this.clientsBindingSource, this.clientFilterFullClause);
                }
            }

            else if (e.KeyCode == Keys.Escape)
            {
                this.clientsBindingSource.RemoveFilter();
                for (int i = 0; i < this.clientGridFilterTextBoxes.Count(); i++)
                {
                    this.clientGridFilterTextBoxes[i].Text = String.Empty;
                }
            }
        }

        private void petGridFilterTxtBoxLeaveEvent(object sender, EventArgs e)
        {
            this.petFilterFullClause = String.Empty;
            this.petFilterFullClause = dataManipulation.createGridFilterClause(this.petGridFilterTextBoxes, Properties.Resources.filterTxtBox + Properties.Resources.petDGV);

            if (this.petFilterFullClause == String.Empty)
            {
                this.petsBindingSource.RemoveFilter();
            }
            else
            {
                dataManipulation.filterBindingSource(this.petsBindingSource, this.petFilterFullClause);
            }
        }

        

        private void petGridFilterTxtBoxKeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.petFilterFullClause = String.Empty;
                this.petFilterFullClause = dataManipulation.createGridFilterClause(this.petGridFilterTextBoxes, Properties.Resources.filterTxtBox + Properties.Resources.petDGV);

                if (this.petFilterFullClause == String.Empty)
                {
                    this.petsBindingSource.RemoveFilter();                                         
                }
                else
                {
                    dataManipulation.filterBindingSource(this.petsBindingSource, this.petFilterFullClause);
                }
            }

            else if (e.KeyCode == Keys.Escape)
            {
                this.petsBindingSource.RemoveFilter();
                for (int i = 0; i < this.petGridFilterTextBoxes.Count(); i++)
                {
                    this.petGridFilterTextBoxes[i].Text = String.Empty;
                }  
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.E:
                    this.btnEdit.PerformClick();
                    break;
                case Keys.Control | Keys.D:
                    this.btnDelete.PerformClick();
                    break;
                case Keys.Control | Keys.N:
                    this.btnAdd.PerformClick();
                    break;
                case Keys.Control | Keys.P:
                    this.btnView.PerformClick();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }   
    }
}
