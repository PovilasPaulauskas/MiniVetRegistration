namespace Gproject
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.tabMainDisplay = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.appointmentDataGridView = new System.Windows.Forms.DataGridView();
            this.AppJoinDGVID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVAppointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVStaffSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVClientSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVPetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVPetSpecies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVClientPhone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVClientAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVPetGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVStaffQualification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVClientPhone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVClientEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVPetBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVStaffAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVStaffPhone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVStaffPhone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppJoinDGVStaffEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentsJoinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clinicDBDataSet = new Gproject.clinicDBDataSet();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clientsDataGridView = new System.Windows.Forms.DataGridView();
            this.ClientDGVID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientDGVClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientDGVClientSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientDGVClientAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientDGVClientPhone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientDGVClientPhone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientDGVClientEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientDGVClientRegDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.petsDataGridView = new System.Windows.Forms.DataGridView();
            this.PetDGVPetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetDGVPetSpecies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetDGVPetGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetDGVPetBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetDGVClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetDGVClientSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetDGVClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetDGVID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.petsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.staffDataGridView = new System.Windows.Forms.DataGridView();
            this.StaffDGVID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffDGVStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffDGVStaffSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffDGVStaffQualification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffDGVStaffAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffDGVStaffPhone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffDGVStaffPhone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffDGVStaffEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.clientsTableAdapter = new Gproject.clinicDBDataSetTableAdapters.ClientsTableAdapter();
            this.AppointmentsJoinTableAdapter = new Gproject.clinicDBDataSetTableAdapters.AppointmentsJoinTableAdapter();
            this.tableAdapterManager = new Gproject.clinicDBDataSetTableAdapters.TableAdapterManager();
            this.staffTableAdapter = new Gproject.clinicDBDataSetTableAdapters.StaffTableAdapter();
            this.petsTableAdapter = new Gproject.clinicDBDataSetTableAdapters.PetsTableAdapter();
            this.staffDropDownBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.staffDropDownTableAdapter = new Gproject.clinicDBDataSetTableAdapters.StaffDropDownTableAdapter();
            this.appointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentsTableAdapter = new Gproject.clinicDBDataSetTableAdapters.AppointmentsTableAdapter();
            this.clientsAutoCompleteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientsAutoCompleteTableAdapter = new Gproject.clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter();
            this.petsAutoCompleteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.petsAutoCompleteTableAdapter = new Gproject.clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter();
            this.btnToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabMainDisplay.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentsJoinBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicDBDataSet)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.petsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petsBindingSource)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffDropDownBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsAutoCompleteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petsAutoCompleteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMainDisplay
            // 
            this.tabMainDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMainDisplay.Controls.Add(this.tabPage1);
            this.tabMainDisplay.Controls.Add(this.tabPage2);
            this.tabMainDisplay.Controls.Add(this.tabPage3);
            this.tabMainDisplay.Controls.Add(this.tabPage4);
            this.tabMainDisplay.Location = new System.Drawing.Point(12, 39);
            this.tabMainDisplay.Name = "tabMainDisplay";
            this.tabMainDisplay.SelectedIndex = 0;
            this.tabMainDisplay.Size = new System.Drawing.Size(960, 269);
            this.tabMainDisplay.TabIndex = 8;
            this.tabMainDisplay.SelectedIndexChanged += new System.EventHandler(this.tabMainDisplay_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.appointmentDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(952, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.AllowUserToAddRows = false;
            this.appointmentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appointmentDataGridView.AutoGenerateColumns = false;
            this.appointmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.appointmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AppJoinDGVID,
            this.AppJoinDGVAppointmentDate,
            this.AppJoinDGVStaffSurname,
            this.AppJoinDGVClientName,
            this.AppJoinDGVClientSurname,
            this.AppJoinDGVPetName,
            this.AppJoinDGVPetSpecies,
            this.AppJoinDGVComments,
            this.AppJoinDGVClientPhone1,
            this.AppJoinDGVClientAddress,
            this.AppJoinDGVPetGender,
            this.AppJoinDGVStaffName,
            this.AppJoinDGVStaffQualification,
            this.AppJoinDGVClientPhone2,
            this.AppJoinDGVClientEmail,
            this.AppJoinDGVStatus,
            this.AppJoinDGVPetBirthDate,
            this.AppJoinDGVStaffAddress,
            this.AppJoinDGVStaffPhone1,
            this.AppJoinDGVStaffPhone2,
            this.AppJoinDGVStaffEmail});
            this.appointmentDataGridView.DataSource = this.AppointmentsJoinBindingSource;
            this.appointmentDataGridView.Location = new System.Drawing.Point(0, 20);
            this.appointmentDataGridView.Margin = new System.Windows.Forms.Padding(3, 500, 3, 3);
            this.appointmentDataGridView.MultiSelect = false;
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            this.appointmentDataGridView.ReadOnly = true;
            this.appointmentDataGridView.RowHeadersVisible = false;
            this.appointmentDataGridView.Size = new System.Drawing.Size(952, 223);
            this.appointmentDataGridView.TabIndex = 0;
            this.appointmentDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.appointmentDataGridView_ColumnWidthChanged);
            this.appointmentDataGridView.SelectionChanged += new System.EventHandler(this.appointmentDataGridView_SelectionChanged);
            // 
            // AppJoinDGVID
            // 
            this.AppJoinDGVID.DataPropertyName = "ID";
            this.AppJoinDGVID.HeaderText = "ID";
            this.AppJoinDGVID.Name = "AppJoinDGVID";
            this.AppJoinDGVID.ReadOnly = true;
            this.AppJoinDGVID.Visible = false;
            // 
            // AppJoinDGVAppointmentDate
            // 
            this.AppJoinDGVAppointmentDate.DataPropertyName = "AppointmentDate";
            this.AppJoinDGVAppointmentDate.FillWeight = 30F;
            this.AppJoinDGVAppointmentDate.HeaderText = "AppointmentDate";
            this.AppJoinDGVAppointmentDate.Name = "AppJoinDGVAppointmentDate";
            this.AppJoinDGVAppointmentDate.ReadOnly = true;
            // 
            // AppJoinDGVStaffSurname
            // 
            this.AppJoinDGVStaffSurname.DataPropertyName = "StaffSurname";
            this.AppJoinDGVStaffSurname.FillWeight = 17.22392F;
            this.AppJoinDGVStaffSurname.HeaderText = "StaffSurname";
            this.AppJoinDGVStaffSurname.Name = "AppJoinDGVStaffSurname";
            this.AppJoinDGVStaffSurname.ReadOnly = true;
            // 
            // AppJoinDGVClientName
            // 
            this.AppJoinDGVClientName.DataPropertyName = "ClientName";
            this.AppJoinDGVClientName.FillWeight = 17.22392F;
            this.AppJoinDGVClientName.HeaderText = "ClientName";
            this.AppJoinDGVClientName.Name = "AppJoinDGVClientName";
            this.AppJoinDGVClientName.ReadOnly = true;
            // 
            // AppJoinDGVClientSurname
            // 
            this.AppJoinDGVClientSurname.DataPropertyName = "ClientSurname";
            this.AppJoinDGVClientSurname.FillWeight = 17.22392F;
            this.AppJoinDGVClientSurname.HeaderText = "ClientSurname";
            this.AppJoinDGVClientSurname.Name = "AppJoinDGVClientSurname";
            this.AppJoinDGVClientSurname.ReadOnly = true;
            // 
            // AppJoinDGVPetName
            // 
            this.AppJoinDGVPetName.DataPropertyName = "PetName";
            this.AppJoinDGVPetName.FillWeight = 17.22392F;
            this.AppJoinDGVPetName.HeaderText = "PetName";
            this.AppJoinDGVPetName.Name = "AppJoinDGVPetName";
            this.AppJoinDGVPetName.ReadOnly = true;
            // 
            // AppJoinDGVPetSpecies
            // 
            this.AppJoinDGVPetSpecies.DataPropertyName = "PetSpecies";
            this.AppJoinDGVPetSpecies.FillWeight = 17.22392F;
            this.AppJoinDGVPetSpecies.HeaderText = "PetSpecies";
            this.AppJoinDGVPetSpecies.Name = "AppJoinDGVPetSpecies";
            this.AppJoinDGVPetSpecies.ReadOnly = true;
            // 
            // AppJoinDGVComments
            // 
            this.AppJoinDGVComments.DataPropertyName = "Comments";
            this.AppJoinDGVComments.HeaderText = "Comments";
            this.AppJoinDGVComments.Name = "AppJoinDGVComments";
            this.AppJoinDGVComments.ReadOnly = true;
            // 
            // AppJoinDGVClientPhone1
            // 
            this.AppJoinDGVClientPhone1.DataPropertyName = "ClientPhone1";
            this.AppJoinDGVClientPhone1.FillWeight = 17.22392F;
            this.AppJoinDGVClientPhone1.HeaderText = "ClientPhone1";
            this.AppJoinDGVClientPhone1.Name = "AppJoinDGVClientPhone1";
            this.AppJoinDGVClientPhone1.ReadOnly = true;
            // 
            // AppJoinDGVClientAddress
            // 
            this.AppJoinDGVClientAddress.DataPropertyName = "ClientAddress";
            this.AppJoinDGVClientAddress.FillWeight = 17.22392F;
            this.AppJoinDGVClientAddress.HeaderText = "ClientAddress";
            this.AppJoinDGVClientAddress.Name = "AppJoinDGVClientAddress";
            this.AppJoinDGVClientAddress.ReadOnly = true;
            // 
            // AppJoinDGVPetGender
            // 
            this.AppJoinDGVPetGender.DataPropertyName = "PetGender";
            this.AppJoinDGVPetGender.FillWeight = 17.22392F;
            this.AppJoinDGVPetGender.HeaderText = "PetGender";
            this.AppJoinDGVPetGender.Name = "AppJoinDGVPetGender";
            this.AppJoinDGVPetGender.ReadOnly = true;
            this.AppJoinDGVPetGender.Visible = false;
            // 
            // AppJoinDGVStaffName
            // 
            this.AppJoinDGVStaffName.DataPropertyName = "StaffName";
            this.AppJoinDGVStaffName.FillWeight = 17.22392F;
            this.AppJoinDGVStaffName.HeaderText = "StaffName";
            this.AppJoinDGVStaffName.Name = "AppJoinDGVStaffName";
            this.AppJoinDGVStaffName.ReadOnly = true;
            this.AppJoinDGVStaffName.Visible = false;
            // 
            // AppJoinDGVStaffQualification
            // 
            this.AppJoinDGVStaffQualification.DataPropertyName = "StaffQualification";
            this.AppJoinDGVStaffQualification.FillWeight = 17.22392F;
            this.AppJoinDGVStaffQualification.HeaderText = "StaffQualification";
            this.AppJoinDGVStaffQualification.Name = "AppJoinDGVStaffQualification";
            this.AppJoinDGVStaffQualification.ReadOnly = true;
            this.AppJoinDGVStaffQualification.Visible = false;
            // 
            // AppJoinDGVClientPhone2
            // 
            this.AppJoinDGVClientPhone2.DataPropertyName = "ClientPhone2";
            this.AppJoinDGVClientPhone2.FillWeight = 17.22392F;
            this.AppJoinDGVClientPhone2.HeaderText = "ClientPhone2";
            this.AppJoinDGVClientPhone2.Name = "AppJoinDGVClientPhone2";
            this.AppJoinDGVClientPhone2.ReadOnly = true;
            this.AppJoinDGVClientPhone2.Visible = false;
            // 
            // AppJoinDGVClientEmail
            // 
            this.AppJoinDGVClientEmail.DataPropertyName = "ClientEmail";
            this.AppJoinDGVClientEmail.HeaderText = "ClientEmail";
            this.AppJoinDGVClientEmail.Name = "AppJoinDGVClientEmail";
            this.AppJoinDGVClientEmail.ReadOnly = true;
            this.AppJoinDGVClientEmail.Visible = false;
            // 
            // AppJoinDGVStatus
            // 
            this.AppJoinDGVStatus.DataPropertyName = "Status";
            this.AppJoinDGVStatus.HeaderText = "Status";
            this.AppJoinDGVStatus.Name = "AppJoinDGVStatus";
            this.AppJoinDGVStatus.ReadOnly = true;
            this.AppJoinDGVStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AppJoinDGVStatus.Visible = false;
            // 
            // AppJoinDGVPetBirthDate
            // 
            this.AppJoinDGVPetBirthDate.DataPropertyName = "PetBirthDate";
            this.AppJoinDGVPetBirthDate.HeaderText = "PetBirthDate";
            this.AppJoinDGVPetBirthDate.Name = "AppJoinDGVPetBirthDate";
            this.AppJoinDGVPetBirthDate.ReadOnly = true;
            this.AppJoinDGVPetBirthDate.Visible = false;
            // 
            // AppJoinDGVStaffAddress
            // 
            this.AppJoinDGVStaffAddress.DataPropertyName = "StaffAddress";
            this.AppJoinDGVStaffAddress.HeaderText = "StaffAddress";
            this.AppJoinDGVStaffAddress.Name = "AppJoinDGVStaffAddress";
            this.AppJoinDGVStaffAddress.ReadOnly = true;
            this.AppJoinDGVStaffAddress.Visible = false;
            // 
            // AppJoinDGVStaffPhone1
            // 
            this.AppJoinDGVStaffPhone1.DataPropertyName = "StaffPhone1";
            this.AppJoinDGVStaffPhone1.HeaderText = "StaffPhone1";
            this.AppJoinDGVStaffPhone1.Name = "AppJoinDGVStaffPhone1";
            this.AppJoinDGVStaffPhone1.ReadOnly = true;
            this.AppJoinDGVStaffPhone1.Visible = false;
            // 
            // AppJoinDGVStaffPhone2
            // 
            this.AppJoinDGVStaffPhone2.DataPropertyName = "StaffPhone2";
            this.AppJoinDGVStaffPhone2.HeaderText = "StaffPhone2";
            this.AppJoinDGVStaffPhone2.Name = "AppJoinDGVStaffPhone2";
            this.AppJoinDGVStaffPhone2.ReadOnly = true;
            this.AppJoinDGVStaffPhone2.Visible = false;
            // 
            // AppJoinDGVStaffEmail
            // 
            this.AppJoinDGVStaffEmail.DataPropertyName = "StaffEmail";
            this.AppJoinDGVStaffEmail.HeaderText = "StaffEmail";
            this.AppJoinDGVStaffEmail.Name = "AppJoinDGVStaffEmail";
            this.AppJoinDGVStaffEmail.ReadOnly = true;
            this.AppJoinDGVStaffEmail.Visible = false;
            // 
            // AppointmentsJoinBindingSource
            // 
            this.AppointmentsJoinBindingSource.DataMember = "AppointmentsJoin";
            this.AppointmentsJoinBindingSource.DataSource = this.clinicDBDataSet;
            // 
            // clinicDBDataSet
            // 
            this.clinicDBDataSet.DataSetName = "clinicDBDataSet";
            this.clinicDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.clientsDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(952, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // clientsDataGridView
            // 
            this.clientsDataGridView.AllowUserToAddRows = false;
            this.clientsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientsDataGridView.AutoGenerateColumns = false;
            this.clientsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.clientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientDGVID,
            this.ClientDGVClientName,
            this.ClientDGVClientSurname,
            this.ClientDGVClientAddress,
            this.ClientDGVClientPhone1,
            this.ClientDGVClientPhone2,
            this.ClientDGVClientEmail,
            this.ClientDGVClientRegDate});
            this.clientsDataGridView.DataSource = this.clientsBindingSource;
            this.clientsDataGridView.Location = new System.Drawing.Point(0, 20);
            this.clientsDataGridView.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.clientsDataGridView.MultiSelect = false;
            this.clientsDataGridView.Name = "clientsDataGridView";
            this.clientsDataGridView.ReadOnly = true;
            this.clientsDataGridView.RowHeadersVisible = false;
            this.clientsDataGridView.Size = new System.Drawing.Size(952, 223);
            this.clientsDataGridView.TabIndex = 1;
            this.clientsDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.clientsDataGridView_ColumnWidthChanged);
            this.clientsDataGridView.SelectionChanged += new System.EventHandler(this.clientsDataGridView_SelectionChanged);
            // 
            // ClientDGVID
            // 
            this.ClientDGVID.DataPropertyName = "ID";
            this.ClientDGVID.HeaderText = "ID";
            this.ClientDGVID.Name = "ClientDGVID";
            this.ClientDGVID.ReadOnly = true;
            this.ClientDGVID.Visible = false;
            // 
            // ClientDGVClientName
            // 
            this.ClientDGVClientName.DataPropertyName = "ClientName";
            this.ClientDGVClientName.HeaderText = "ClientName";
            this.ClientDGVClientName.Name = "ClientDGVClientName";
            this.ClientDGVClientName.ReadOnly = true;
            // 
            // ClientDGVClientSurname
            // 
            this.ClientDGVClientSurname.DataPropertyName = "ClientSurname";
            this.ClientDGVClientSurname.HeaderText = "ClientSurname";
            this.ClientDGVClientSurname.Name = "ClientDGVClientSurname";
            this.ClientDGVClientSurname.ReadOnly = true;
            // 
            // ClientDGVClientAddress
            // 
            this.ClientDGVClientAddress.DataPropertyName = "ClientAddress";
            this.ClientDGVClientAddress.HeaderText = "ClientAddress";
            this.ClientDGVClientAddress.Name = "ClientDGVClientAddress";
            this.ClientDGVClientAddress.ReadOnly = true;
            // 
            // ClientDGVClientPhone1
            // 
            this.ClientDGVClientPhone1.DataPropertyName = "ClientPhone1";
            this.ClientDGVClientPhone1.HeaderText = "ClientPhone1";
            this.ClientDGVClientPhone1.Name = "ClientDGVClientPhone1";
            this.ClientDGVClientPhone1.ReadOnly = true;
            // 
            // ClientDGVClientPhone2
            // 
            this.ClientDGVClientPhone2.DataPropertyName = "ClientPhone2";
            this.ClientDGVClientPhone2.HeaderText = "ClientPhone2";
            this.ClientDGVClientPhone2.Name = "ClientDGVClientPhone2";
            this.ClientDGVClientPhone2.ReadOnly = true;
            // 
            // ClientDGVClientEmail
            // 
            this.ClientDGVClientEmail.DataPropertyName = "ClientEmail";
            this.ClientDGVClientEmail.HeaderText = "ClientEmail";
            this.ClientDGVClientEmail.Name = "ClientDGVClientEmail";
            this.ClientDGVClientEmail.ReadOnly = true;
            // 
            // ClientDGVClientRegDate
            // 
            this.ClientDGVClientRegDate.DataPropertyName = "ClientRegDate";
            this.ClientDGVClientRegDate.HeaderText = "ClientRegDate";
            this.ClientDGVClientRegDate.Name = "ClientDGVClientRegDate";
            this.ClientDGVClientRegDate.ReadOnly = true;
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.clinicDBDataSet;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.petsDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(952, 243);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // petsDataGridView
            // 
            this.petsDataGridView.AllowUserToAddRows = false;
            this.petsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.petsDataGridView.AutoGenerateColumns = false;
            this.petsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.petsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.petsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.petsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PetDGVPetName,
            this.PetDGVPetSpecies,
            this.PetDGVPetGender,
            this.PetDGVPetBirthDate,
            this.PetDGVClientName,
            this.PetDGVClientSurname,
            this.PetDGVClientID,
            this.PetDGVID});
            this.petsDataGridView.DataSource = this.petsBindingSource;
            this.petsDataGridView.Location = new System.Drawing.Point(0, 20);
            this.petsDataGridView.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.petsDataGridView.MultiSelect = false;
            this.petsDataGridView.Name = "petsDataGridView";
            this.petsDataGridView.ReadOnly = true;
            this.petsDataGridView.RowHeadersVisible = false;
            this.petsDataGridView.Size = new System.Drawing.Size(952, 223);
            this.petsDataGridView.TabIndex = 0;
            this.petsDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.petsDataGridView_ColumnWidthChanged);
            this.petsDataGridView.SelectionChanged += new System.EventHandler(this.petsDataGridView_SelectionChanged);
            // 
            // PetDGVPetName
            // 
            this.PetDGVPetName.DataPropertyName = "PetName";
            this.PetDGVPetName.HeaderText = "PetName";
            this.PetDGVPetName.Name = "PetDGVPetName";
            this.PetDGVPetName.ReadOnly = true;
            // 
            // PetDGVPetSpecies
            // 
            this.PetDGVPetSpecies.DataPropertyName = "PetSpecies";
            this.PetDGVPetSpecies.HeaderText = "PetSpecies";
            this.PetDGVPetSpecies.Name = "PetDGVPetSpecies";
            this.PetDGVPetSpecies.ReadOnly = true;
            // 
            // PetDGVPetGender
            // 
            this.PetDGVPetGender.DataPropertyName = "PetGender";
            this.PetDGVPetGender.HeaderText = "PetGender";
            this.PetDGVPetGender.Name = "PetDGVPetGender";
            this.PetDGVPetGender.ReadOnly = true;
            // 
            // PetDGVPetBirthDate
            // 
            this.PetDGVPetBirthDate.DataPropertyName = "PetBirthDate";
            this.PetDGVPetBirthDate.HeaderText = "PetBirthDate";
            this.PetDGVPetBirthDate.Name = "PetDGVPetBirthDate";
            this.PetDGVPetBirthDate.ReadOnly = true;
            // 
            // PetDGVClientName
            // 
            this.PetDGVClientName.DataPropertyName = "ClientName";
            this.PetDGVClientName.HeaderText = "ClientName";
            this.PetDGVClientName.Name = "PetDGVClientName";
            this.PetDGVClientName.ReadOnly = true;
            // 
            // PetDGVClientSurname
            // 
            this.PetDGVClientSurname.DataPropertyName = "ClientSurname";
            this.PetDGVClientSurname.HeaderText = "ClientSurname";
            this.PetDGVClientSurname.Name = "PetDGVClientSurname";
            this.PetDGVClientSurname.ReadOnly = true;
            // 
            // PetDGVClientID
            // 
            this.PetDGVClientID.DataPropertyName = "ClientID";
            this.PetDGVClientID.HeaderText = "ClientID";
            this.PetDGVClientID.Name = "PetDGVClientID";
            this.PetDGVClientID.ReadOnly = true;
            this.PetDGVClientID.Visible = false;
            // 
            // PetDGVID
            // 
            this.PetDGVID.DataPropertyName = "ID";
            this.PetDGVID.HeaderText = "ID";
            this.PetDGVID.Name = "PetDGVID";
            this.PetDGVID.ReadOnly = true;
            this.PetDGVID.Visible = false;
            // 
            // petsBindingSource
            // 
            this.petsBindingSource.DataMember = "Pets";
            this.petsBindingSource.DataSource = this.clinicDBDataSet;
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.staffDataGridView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(952, 243);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // staffDataGridView
            // 
            this.staffDataGridView.AllowUserToAddRows = false;
            this.staffDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.staffDataGridView.AutoGenerateColumns = false;
            this.staffDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.staffDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.staffDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.staffDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StaffDGVID,
            this.StaffDGVStaffName,
            this.StaffDGVStaffSurname,
            this.StaffDGVStaffQualification,
            this.StaffDGVStaffAddress,
            this.StaffDGVStaffPhone1,
            this.StaffDGVStaffPhone2,
            this.StaffDGVStaffEmail});
            this.staffDataGridView.DataSource = this.staffBindingSource;
            this.staffDataGridView.Location = new System.Drawing.Point(0, 20);
            this.staffDataGridView.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.staffDataGridView.MultiSelect = false;
            this.staffDataGridView.Name = "staffDataGridView";
            this.staffDataGridView.ReadOnly = true;
            this.staffDataGridView.RowHeadersVisible = false;
            this.staffDataGridView.Size = new System.Drawing.Size(952, 223);
            this.staffDataGridView.TabIndex = 0;
            this.staffDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.staffDataGridView_ColumnWidthChanged);
            this.staffDataGridView.SelectionChanged += new System.EventHandler(this.staffDataGridView_SelectionChanged);
            // 
            // StaffDGVID
            // 
            this.StaffDGVID.DataPropertyName = "ID";
            this.StaffDGVID.HeaderText = "ID";
            this.StaffDGVID.Name = "StaffDGVID";
            this.StaffDGVID.ReadOnly = true;
            this.StaffDGVID.Visible = false;
            // 
            // StaffDGVStaffName
            // 
            this.StaffDGVStaffName.DataPropertyName = "StaffName";
            this.StaffDGVStaffName.HeaderText = "StaffName";
            this.StaffDGVStaffName.Name = "StaffDGVStaffName";
            this.StaffDGVStaffName.ReadOnly = true;
            // 
            // StaffDGVStaffSurname
            // 
            this.StaffDGVStaffSurname.DataPropertyName = "StaffSurname";
            this.StaffDGVStaffSurname.HeaderText = "StaffSurname";
            this.StaffDGVStaffSurname.Name = "StaffDGVStaffSurname";
            this.StaffDGVStaffSurname.ReadOnly = true;
            // 
            // StaffDGVStaffQualification
            // 
            this.StaffDGVStaffQualification.DataPropertyName = "StaffQualification";
            this.StaffDGVStaffQualification.HeaderText = "StaffQualification";
            this.StaffDGVStaffQualification.Name = "StaffDGVStaffQualification";
            this.StaffDGVStaffQualification.ReadOnly = true;
            // 
            // StaffDGVStaffAddress
            // 
            this.StaffDGVStaffAddress.DataPropertyName = "StaffAddress";
            this.StaffDGVStaffAddress.HeaderText = "StaffAddress";
            this.StaffDGVStaffAddress.Name = "StaffDGVStaffAddress";
            this.StaffDGVStaffAddress.ReadOnly = true;
            // 
            // StaffDGVStaffPhone1
            // 
            this.StaffDGVStaffPhone1.DataPropertyName = "StaffPhone1";
            this.StaffDGVStaffPhone1.HeaderText = "StaffPhone1";
            this.StaffDGVStaffPhone1.Name = "StaffDGVStaffPhone1";
            this.StaffDGVStaffPhone1.ReadOnly = true;
            // 
            // StaffDGVStaffPhone2
            // 
            this.StaffDGVStaffPhone2.DataPropertyName = "StaffPhone2";
            this.StaffDGVStaffPhone2.HeaderText = "StaffPhone2";
            this.StaffDGVStaffPhone2.Name = "StaffDGVStaffPhone2";
            this.StaffDGVStaffPhone2.ReadOnly = true;
            // 
            // StaffDGVStaffEmail
            // 
            this.StaffDGVStaffEmail.DataPropertyName = "StaffEmail";
            this.StaffDGVStaffEmail.HeaderText = "StaffEmail";
            this.StaffDGVStaffEmail.Name = "StaffDGVStaffEmail";
            this.StaffDGVStaffEmail.ReadOnly = true;
            // 
            // staffBindingSource
            // 
            this.staffBindingSource.DataMember = "Staff";
            this.staffBindingSource.DataSource = this.clinicDBDataSet;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(12, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "button1";
            this.btnToolTip.SetToolTip(this.btnAdd, "Ctrl+N");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "minus.png");
            this.imageList1.Images.SetKeyName(1, "plus.png");
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(174, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "button2";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnToolTip.SetToolTip(this.btnDelete, "Ctrl+D");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnView
            // 
            this.btnView.Image = global::Gproject.Properties.Resources.view50;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(255, 10);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "button3";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnToolTip.SetToolTip(this.btnView, "Ctrl+P");
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Gproject.Properties.Resources.edit50;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(93, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "button1";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnToolTip.SetToolTip(this.btnEdit, "Ctrl+E");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 315);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // AppointmentsJoinTableAdapter
            // 
            this.AppointmentsJoinTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AppointmentsTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClientsTableAdapter = this.clientsTableAdapter;
            this.tableAdapterManager.StaffTableAdapter = this.staffTableAdapter;
            this.tableAdapterManager.UpdateOrder = Gproject.clinicDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.UpdateInsertDelete;
            // 
            // staffTableAdapter
            // 
            this.staffTableAdapter.ClearBeforeFill = true;
            // 
            // petsTableAdapter
            // 
            this.petsTableAdapter.ClearBeforeFill = true;
            // 
            // staffDropDownBindingSource
            // 
            this.staffDropDownBindingSource.DataMember = "StaffDropDown";
            this.staffDropDownBindingSource.DataSource = this.clinicDBDataSet;
            // 
            // staffDropDownTableAdapter
            // 
            this.staffDropDownTableAdapter.ClearBeforeFill = true;
            // 
            // appointmentsBindingSource
            // 
            this.appointmentsBindingSource.DataMember = "Appointments";
            this.appointmentsBindingSource.DataSource = this.clinicDBDataSet;
            // 
            // appointmentsTableAdapter
            // 
            this.appointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // clientsAutoCompleteBindingSource
            // 
            this.clientsAutoCompleteBindingSource.DataMember = "ClientsAutoComplete";
            this.clientsAutoCompleteBindingSource.DataSource = this.clinicDBDataSet;
            // 
            // clientsAutoCompleteTableAdapter
            // 
            this.clientsAutoCompleteTableAdapter.ClearBeforeFill = true;
            // 
            // petsAutoCompleteBindingSource
            // 
            this.petsAutoCompleteBindingSource.DataMember = "PetsAutoComplete";
            this.petsAutoCompleteBindingSource.DataSource = this.clinicDBDataSet;
            // 
            // petsAutoCompleteTableAdapter
            // 
            this.petsAutoCompleteTableAdapter.ClearBeforeFill = true;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 344);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tabMainDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(992, 383);
            this.Name = "formMain";
            this.Text = Properties.Resources.appName;
            this.Load += new System.EventHandler(this.formMain_Load_1);
            this.tabMainDisplay.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentsJoinBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicDBDataSet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.petsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petsBindingSource)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staffDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffDropDownBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsAutoCompleteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petsAutoCompleteBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMainDisplay;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnEdit;
        private clinicDBDataSet clinicDBDataSet;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private clinicDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private clinicDBDataSetTableAdapters.AppointmentsJoinTableAdapter AppointmentsJoinTableAdapter;
        private System.Windows.Forms.BindingSource AppointmentsJoinBindingSource;
        private System.Windows.Forms.DataGridView appointmentDataGridView;
        private clinicDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.BindingSource petsBindingSource;
        private clinicDBDataSetTableAdapters.PetsTableAdapter petsTableAdapter;
        private System.Windows.Forms.DataGridView petsDataGridView;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.BindingSource staffBindingSource;
        private clinicDBDataSetTableAdapters.StaffTableAdapter staffTableAdapter;
        private System.Windows.Forms.DataGridView staffDataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView clientsDataGridView;
        private System.Windows.Forms.BindingSource staffDropDownBindingSource;
        private clinicDBDataSetTableAdapters.StaffDropDownTableAdapter staffDropDownTableAdapter;
 //       private clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter clientsAutoCompleteTableAdapter;
        private System.Windows.Forms.BindingSource appointmentsBindingSource;
        private clinicDBDataSetTableAdapters.AppointmentsTableAdapter appointmentsTableAdapter;
        private System.Windows.Forms.BindingSource clientsAutoCompleteBindingSource;
        private clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter clientsAutoCompleteTableAdapter;
        private System.Windows.Forms.BindingSource petsAutoCompleteBindingSource;
        private clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter petsAutoCompleteTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientDGVID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientDGVClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientDGVClientSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientDGVClientAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientDGVClientPhone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientDGVClientPhone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientDGVClientEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientDGVClientRegDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffDGVID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffDGVStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffDGVStaffSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffDGVStaffQualification;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffDGVStaffAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffDGVStaffPhone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffDGVStaffPhone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffDGVStaffEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVAppointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVStaffSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVClientSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVPetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVPetSpecies;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVComments;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVClientPhone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVClientAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVPetGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVStaffQualification;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVClientPhone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVClientEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVPetBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVStaffAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVStaffPhone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVStaffPhone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppJoinDGVStaffEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetDGVPetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetDGVPetSpecies;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetDGVPetGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetDGVPetBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetDGVClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetDGVClientSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetDGVClientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetDGVID;
        private System.Windows.Forms.ToolTip btnToolTip;
    }
}

