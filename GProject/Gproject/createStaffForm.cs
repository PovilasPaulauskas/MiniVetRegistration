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
    public partial class createStaffForm : Form
    {
        private string name, surName, qualifications, address, phone1, phone2, email;
        private clinicDBDataSetTableAdapters.StaffTableAdapter staffTableAdapter;
        private clinicDBDataSet clinicDBDataSet;
        private int editStaffId;
        private string createStaffCaller = "btnAdd_Click";
        private string updateStaffCaller = "btnEdit_Click";
        private bool textBoxValidate = true;
        private string callerMethodName;
        private string[] nameAutoCompleteStringArray, surNameAutoCompleteStringArray, addressAutoCompleteStringArray, emailAutoCompleteStringArray, qualificationsAutoCompleteStringArray;

        public createStaffForm(string[] _editStaffArray, ArrayList _nameAutoCmplt = null, ArrayList _surNameAutoCmplt = null, ArrayList _addressAutoCmplt = null, ArrayList _emailAutoCmplt = null, ArrayList _qualificationsAutoCmplt = null, [CallerMemberName]string callerMethodName = null)
        {
            InitializeComponent();

            AutoCompleteStringCollection nameAutoCmpltSource = new AutoCompleteStringCollection();
            this.nameAutoCompleteStringArray = (string[])_nameAutoCmplt.ToArray(typeof(string));
            nameAutoCmpltSource.AddRange(this.nameAutoCompleteStringArray);

            AutoCompleteStringCollection surNameAutoCmpltSource = new AutoCompleteStringCollection();
            this.surNameAutoCompleteStringArray = (string[])_surNameAutoCmplt.ToArray(typeof(string));
            surNameAutoCmpltSource.AddRange(this.surNameAutoCompleteStringArray);

            AutoCompleteStringCollection qualificationAutoCmpltSource = new AutoCompleteStringCollection();
            this.qualificationsAutoCompleteStringArray = (string[])_qualificationsAutoCmplt.ToArray(typeof(string));
            qualificationAutoCmpltSource.AddRange(this.qualificationsAutoCompleteStringArray);

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

            this.textBox3.AutoCompleteCustomSource = qualificationAutoCmpltSource;
            this.textBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.textBox4.AutoCompleteCustomSource = addressAutoCmpltSource;
            this.textBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.textBox7.AutoCompleteCustomSource = emailAutoCmpltSource;
            this.textBox7.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.callerMethodName = callerMethodName;
            this.label1.Text = Properties.Resources.name;
            this.label2.Text = Properties.Resources.surName;
            this.label3.Text = Properties.Resources.qualification;
            this.label4.Text = Properties.Resources.address;
            this.label5.Text = Properties.Resources.phone;
            this.label6.Text = Properties.Resources.phone;
            this.label7.Text = Properties.Resources.email;
            this.button1.Text = Properties.Resources.create;
            this.button2.Text = Properties.Resources.cancel;

            if (this.callerMethodName == this.createStaffCaller)
            {
                this.Text = Properties.Resources.createStaff;
            }

            if (this.callerMethodName == this.updateStaffCaller)
            {
                this.Text = Properties.Resources.updateStaff;
                this.textBox1.Text = _editStaffArray[0];
                this.textBox2.Text = _editStaffArray[1];
                this.textBox3.Text = _editStaffArray[2];
                this.textBox4.Text = _editStaffArray[3];
                this.textBox5.Text = _editStaffArray[4];
                this.textBox6.Text = _editStaffArray[5];
                this.textBox7.Text = _editStaffArray[6];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.name = this.textBox1.Text;
            this.surName = this.textBox2.Text;
            this.qualifications = this.textBox3.Text;
            this.address = this.textBox4.Text;
            this.phone1 = this.textBox5.Text;
            this.phone2 = this.textBox6.Text;
            this.email = this.textBox7.Text;
            this.textBoxValidate = true;

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

            if (this.qualifications == String.Empty)
            {
                this.textBox3.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.address == String.Empty)
            {
                this.textBox4.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.phone1 == String.Empty)
            {
                this.textBox5.BackColor = Color.LightCoral;
                this.textBoxValidate = false;
            }

            if (this.callerMethodName == this.createStaffCaller && this.textBoxValidate == true)
            {
                dataManipulation.insertStaff(this.staffTableAdapter, this.clinicDBDataSet, this.name, this.surName, this.qualifications, this.address, this.phone1, this.phone2, this.email);
                this.staffTableAdapter.Fill(this.clinicDBDataSet.Staff);
                this.Close();
            }

            if (this.callerMethodName == this.updateStaffCaller && this.textBoxValidate == true)
            {
                dataManipulation.updateStaff(this.staffTableAdapter, this.clinicDBDataSet, this.name, this.surName, this.qualifications, this.address, this.phone1, this.phone2, this.email, this.editStaffId);
                this.staffTableAdapter.Fill(this.clinicDBDataSet.Staff);
                this.Close();
            }

        }

        public clinicDBDataSetTableAdapters.StaffTableAdapter setStaffTableAdapter
        {
            set { this.staffTableAdapter = value; }
        }

        public clinicDBDataSet setclinicDBDataSet
        {
            set { this.clinicDBDataSet = value; }
        }

        public int setEditStaffId
        {
            set { this.editStaffId = value; }
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

        private void textBox5_Enter(object sender, EventArgs e)
        {
            this.textBox5.BackColor = Color.White;
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

        private void createStaffForm_Load(object sender, EventArgs e)
        {

        }
    }
}
