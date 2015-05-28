using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace Gproject
{
    public static class dataManipulation
    {
        public static int getColumnIdByPropertyName(DataGridView _dataGridView, String _dataPropertyName)
        {
            int columnId = 0;
            int columnCount = _dataGridView.ColumnCount;

            if (_dataGridView == null || _dataPropertyName == String.Empty)
            {
                return -1;    
            }

            for (int i = 0; i < columnCount; i++)
            {
                if (_dataGridView.Columns[i].DataPropertyName == _dataPropertyName)
                {
                    columnId = i;
                    break;
                }    
            }

            return columnId;
        }

        public static void changeColumnHeaderTxt(int _tabIndex, DataGridView _dataGridView)
        {
            if (_tabIndex < 0 || _dataGridView == null)
            {
                return;
            }

            if (_tabIndex == 0)         // appointments
            {
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldAppointmentDate)].HeaderText = Properties.Resources.date;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldComments)].HeaderText = Properties.Resources.comment;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStatus)].HeaderText = Properties.Resources.status;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldPetName)].HeaderText = Properties.Resources.petName;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldPetSpecies)].HeaderText = Properties.Resources.petSpecies;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldPetGender)].HeaderText = Properties.Resources.petGender;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStaffName)].HeaderText = Properties.Resources.doctorName;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStaffSurname)].HeaderText = Properties.Resources.doctorSurname;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStaffQualification)].HeaderText = Properties.Resources.qualification;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientName)].HeaderText = Properties.Resources.ownerName;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientSurname)].HeaderText = Properties.Resources.ownerSurname;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientAddress)].HeaderText = Properties.Resources.address;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientPhone1)].HeaderText = Properties.Resources.phone;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientPhone2)].HeaderText = Properties.Resources.phone;    
            }

            if (_tabIndex == 1)         // clients
            {
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientName)].HeaderText = Properties.Resources.name;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientSurname)].HeaderText = Properties.Resources.surName;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientAddress)].HeaderText = Properties.Resources.address;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientPhone1)].HeaderText = Properties.Resources.phone;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientPhone2)].HeaderText = Properties.Resources.phone;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientEmail)].HeaderText = Properties.Resources.email;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientRegDate)].HeaderText = Properties.Resources.regDate;
            }

            if (_tabIndex ==2)          // pets     
            {
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldPetName)].HeaderText = Properties.Resources.petName;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldPetSpecies)].HeaderText = Properties.Resources.petSpecies;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldPetGender)].HeaderText = Properties.Resources.petGender;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldPetBirthDate)].HeaderText = Properties.Resources.petBirthDate;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientName)].HeaderText = Properties.Resources.ownerName;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldClientSurname)].HeaderText = Properties.Resources.ownerSurname;
            }

            if (_tabIndex == 3)          // staff     
            {
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStaffName)].HeaderText = Properties.Resources.doctorName;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStaffSurname)].HeaderText = Properties.Resources.doctorSurname;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStaffQualification)].HeaderText = Properties.Resources.qualification;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStaffAddress)].HeaderText = Properties.Resources.address;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStaffPhone1)].HeaderText = Properties.Resources.phone;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStaffPhone2)].HeaderText = Properties.Resources.phone;
                _dataGridView.Columns[dataManipulation.getColumnIdByPropertyName(_dataGridView, Properties.Resources.dataBaseFieldStaffEmail)].HeaderText = Properties.Resources.email;
            }
        }

        public static void insertClients(clinicDBDataSetTableAdapters.ClientsTableAdapter _clientsTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _surName, string _address, string _phone1, string _phone2, string _email)
        {
            //
            if (_clientsTableAdapter == null || _clinicDBDataSet == null || _name == String.Empty || _surName == String.Empty || _address == String.Empty || _phone1 == String.Empty)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgInsertFailed);
                return;    
            }

            try
            {
                _clientsTableAdapter.Connection.Open();
                _clientsTableAdapter.ClientInsertQuery(_name, _surName, _address, _phone1, _phone2, _email, DateTime.Now);
                _clientsTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgInsertFailed);
            }
        }

        public static void updateClients(clinicDBDataSetTableAdapters.ClientsTableAdapter _clientsTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _surName, string _address, string _phone1, string _phone2, string _email, int _id)
        {
            //
            if (_clientsTableAdapter == null || _clinicDBDataSet == null || _name == String.Empty || _surName == String.Empty || _address == String.Empty || _phone1 == String.Empty || _id <= 0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgUpdateFailed);
                return;
            }

            try
            {
                _clientsTableAdapter.Connection.Open();
                _clientsTableAdapter.ClientUpdateQuery(_name, _surName, _address, _phone1, _phone2, _email, _id);
                _clientsTableAdapter.Connection.Close();   
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgUpdateFailed);
            }
        }

        public static void deleteClients(clinicDBDataSetTableAdapters.ClientsTableAdapter _clientsTableAdapter, clinicDBDataSetTableAdapters.PetsTableAdapter _petsTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _surName, string _address, string _phone1, string _phone2, string _email, int _id)
        {
            var clientDeleteSuccessful = false;


            if (_clientsTableAdapter == null || _petsTableAdapter == null || _clinicDBDataSet == null || _name == String.Empty || _surName == String.Empty || _address == String.Empty || _phone1 == String.Empty || _id <= 0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgDeleteFailed);
                return;
            }

            try
            {
                _clientsTableAdapter.Connection.Open();
                _clientsTableAdapter.ClientDeleteQuery(_id,_name, _surName, _address, _phone1, _phone2, _email);
                clientDeleteSuccessful = true;
                _clientsTableAdapter.Update(_clinicDBDataSet.Clients);
                _clientsTableAdapter.Connection.Close();

                if (clientDeleteSuccessful == true)
                {
                    _petsTableAdapter.Connection.Open();
                    _petsTableAdapter.PetsDeleteQueryByClientID(_id);
                    _petsTableAdapter.Connection.Close();
                }
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgDeleteFailed);
            }
        }

        public static void insertStaff(clinicDBDataSetTableAdapters.StaffTableAdapter _staffTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _surName, string _qualifications, string _address, string _phone1, string _phone2, string _email)
        {
            //
            if (_staffTableAdapter == null || _clinicDBDataSet == null || _name == String.Empty || _surName == String.Empty || _qualifications == String.Empty ||_address == String.Empty || _phone1 == String.Empty)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgInsertFailed);
                return;
            }

            try
            {
                _staffTableAdapter.Connection.Open();
                _staffTableAdapter.StaffInsertQuery(_name, _surName, _qualifications, _address, _phone1, _phone2, _email);
                _staffTableAdapter.Connection.Close();

            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgInsertFailed);
            }
        }

        public static void updateStaff(clinicDBDataSetTableAdapters.StaffTableAdapter _staffTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _surName, string _qualifications, string _address, string _phone1, string _phone2, string _email, int _id)
        {
            //
            if (_staffTableAdapter == null || _clinicDBDataSet == null || _name == String.Empty || _surName == String.Empty || _qualifications == String.Empty || _address == String.Empty || _phone1 == String.Empty || _id <= 0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgUpdateFailed);
                return;
            }

            try
            {
                _staffTableAdapter.Connection.Open();
                _staffTableAdapter.StaffUpdateQuery(_name, _surName, _qualifications, _address, _phone1, _phone2, _email, _id);
                _staffTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgUpdateFailed);
            }
        }

        public static void deleteStaff(clinicDBDataSetTableAdapters.StaffTableAdapter _staffTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _surName, string _qualifications, string _address, string _phone1, string _phone2, string _email, int _id)
        {
            if (_staffTableAdapter == null || _clinicDBDataSet == null|| _name == String.Empty || _surName == String.Empty || _qualifications == String.Empty || _address == String.Empty || _phone1 == String.Empty || _id <= 0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgDeleteFailed);
                return;
            }

            try
            {
                _staffTableAdapter.Connection.Open();
                _staffTableAdapter.StaffDeleteQuery(_id, _name, _surName, _qualifications, _address, _phone1, _phone2, _email);
                _staffTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgDeleteFailed);
            }
        }

        public static int getClientIdForPets(clinicDBDataSetTableAdapters.ClientsTableAdapter _clientsTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _surName, string _address)
        {
            int? clientIdNullable;
            int clientId = 0;

            if (_clientsTableAdapter == null || _clinicDBDataSet == null || _name == String.Empty || _surName == String.Empty || _address == String.Empty)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGettingClientID);
                return -1;
            }

            try
            {
                _clientsTableAdapter.Connection.Open();
                clientIdNullable = _clientsTableAdapter.ClientSelectIDQuery(_name, _surName, _address);
                _clientsTableAdapter.Connection.Close();
                clientId = clientIdNullable ?? -1;    
            }

            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGettingClientID);
            }

            return clientId;
        }

        public static int getStaffIdNameSurnameQualifications(clinicDBDataSetTableAdapters.StaffTableAdapter _staffTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _surName)
        {
            int? staffIdNullable;
            int staffId = 0;

            if (_staffTableAdapter == null || _clinicDBDataSet == null || _name == String.Empty || _surName == String.Empty)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGettingStaffID);
                return -1;
            }

            try
            {
                _staffTableAdapter.Connection.Open();
                staffIdNullable = _staffTableAdapter.StaffSelectIDQuery(_name, _surName);
                _staffTableAdapter.Connection.Close();
                staffId = staffIdNullable ?? -1;
            }

            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGettingStaffID);
            }

            return staffId;
        }

        public static int getPetIdNameGenderSpeciesClientId(clinicDBDataSetTableAdapters.PetsTableAdapter _petsTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _species, string _gender, int _petClientId)
        {
            int? petIdNullable;
            int petId = 0;

            if (_petsTableAdapter == null || _clinicDBDataSet == null || _name == String.Empty || _species == String.Empty || _gender == String.Empty || _petClientId < 0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGettingClientID);
                return -1;
            }

            try
            {
                _petsTableAdapter.Connection.Open();
                petIdNullable = _petsTableAdapter.PetsSelectIDQuery(_name, _species, _gender, _petClientId);
                _petsTableAdapter.Connection.Close();
                petId = petIdNullable ?? -1;
            }

            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGettingClientID);
            }

            return petId;
        }

        public static void insertPets(clinicDBDataSetTableAdapters.PetsTableAdapter _petsTableAdapter, clinicDBDataSet _clinicDBDataSet, string _petName, string _petSpecies, string _petGender, DateTime _petBirthDate, int _petClientId)
        {

            if (_petsTableAdapter == null || _clinicDBDataSet == null || _petName == String.Empty || _petSpecies == String.Empty || _petGender == String.Empty || _petClientId < 0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgInsertFailed);
                return;
            }

            try
            {
                _petsTableAdapter.Connection.Open();
                _petsTableAdapter.PetsInsertQuery(_petName, _petSpecies, _petGender, _petBirthDate, _petClientId);
                _petsTableAdapter.Connection.Close();
            }

            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgInsertFailed);
            }
        }

        public static void updatePets(clinicDBDataSetTableAdapters.PetsTableAdapter _petsTableAdapter, clinicDBDataSet _clinicDBDataSet, string _petName, string _petSpecies, string _petGender, DateTime _petBirthDate, int _petClientId, int _id)
        {

            if (_petsTableAdapter == null || _clinicDBDataSet == null || _petName == String.Empty || _petSpecies == String.Empty || _petGender == String.Empty || _petClientId < 0 || _id <=0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgUpdateFailed);
                return;
            }

            try
            {
                _petsTableAdapter.Connection.Open();
                _petsTableAdapter.PetsUpdateQuery(_petName, _petSpecies, _petGender, _petBirthDate, _petClientId, _id);
                _petsTableAdapter.Connection.Close();
            }

            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgUpdateFailed);
            }
        }

        public static void deletePets(clinicDBDataSetTableAdapters.PetsTableAdapter _petsTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _species, string _gender, DateTime _petBirthDate, int _petClientId, int _id)
        {
            if (_petsTableAdapter == null || _clinicDBDataSet == null || _name == String.Empty || _species == String.Empty || _gender == String.Empty || _petClientId < 0 || _id <= 0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgDeleteFailed);
                return;
            }

            try
            {
                _petsTableAdapter.Connection.Open();
                _petsTableAdapter.PetsDeleteQuery(_id, _name, _species, _gender, _petBirthDate, _petClientId);
                _petsTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgDeleteFailed);
            }
        }

        public static string getStaffNameOrSurname(string _nameAndSurName, int _possition)
        {
            string[] ret;
            char splitChar = ' ';

            ret = _nameAndSurName.Split(splitChar);
            return ret[_possition];
        }

        public static void insertAppointmentsWithPets(clinicDBDataSetTableAdapters.AppointmentsTableAdapter _appointmentsTableAdapter, clinicDBDataSet _clinicDBDataSet, int _petId, int _staffId, int _clientId, string _comment, DateTime _date, int _status)
        {
            if (_appointmentsTableAdapter == null || _clinicDBDataSet == null || _petId < 0 || _staffId < 0 || _clientId < 0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgInsertFailed);
                return;
            }

            try
            {
                _appointmentsTableAdapter.Connection.Open();
                _appointmentsTableAdapter.AppointmentsInsertWithPetQuery(_petId, _staffId, _date, _comment, 1, _clientId);
                _appointmentsTableAdapter.Connection.Close();
            }

            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgInsertFailed);
            }
        }

        public static void insertAppointmentsNoPets(clinicDBDataSetTableAdapters.AppointmentsTableAdapter _appointmentsTableAdapter, clinicDBDataSet _clinicDBDataSet, int _staffId, int _clientId, string _comment, DateTime _date, int _status)
        {
            if (_appointmentsTableAdapter == null || _clinicDBDataSet == null || _staffId < 0 || _clientId < 0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgInsertFailed);
                return;
            }

            try
            {
                _appointmentsTableAdapter.Connection.Open();
                _appointmentsTableAdapter.AppointmentsInsertNoPetQuery(_staffId, _date, _comment, 1, _clientId);
                _appointmentsTableAdapter.Connection.Close();
            }

            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgInsertFailed);
            }
        }

        public static void updateAppointmentsWithPets(clinicDBDataSetTableAdapters.AppointmentsTableAdapter _appointmentsTableAdapter, clinicDBDataSet _clinicDBDataSet, int _petId, int _staffId, int _clientId, string _comment, DateTime _date, int _status, int _id)
        {
            if (_appointmentsTableAdapter == null || _clinicDBDataSet == null || _petId < 0 || _staffId < 0 || _clientId < 0 || _id <=0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgUpdateFailed);
                return;
            }

            try
            {
                _appointmentsTableAdapter.Connection.Open();
                _appointmentsTableAdapter.AppointmentsUpdateWithPetQuery(_petId, _staffId, _date, _comment, 1, _clientId, _id);
                _appointmentsTableAdapter.Connection.Close();
            }

            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgUpdateFailed);
            }
        }

        public static void updateAppointmentsNoPets(clinicDBDataSetTableAdapters.AppointmentsTableAdapter _appointmentsTableAdapter, clinicDBDataSet _clinicDBDataSet, int _staffId, int _clientId, string _comment, DateTime _date, int _status, int _id)
        {
            if (_appointmentsTableAdapter == null || _clinicDBDataSet == null  || _staffId < 0 || _clientId < 0 || _id <= 0)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgUpdateFailed);
                return;
            }

            try
            {
                _appointmentsTableAdapter.Connection.Open();
                _appointmentsTableAdapter.AppointmentsUpdateNoPetQuery(_staffId, _date, _comment, 1, _clientId, _id);
                _appointmentsTableAdapter.Connection.Close();
            }

            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgUpdateFailed);
            }
        }

        public static void deleteAppointments(clinicDBDataSetTableAdapters.AppointmentsTableAdapter _appointmentsTableAdapter, clinicDBDataSet _clinicDBDataSet, string _comment, DateTime _date, int _id)
        {
            if (_appointmentsTableAdapter == null || _clinicDBDataSet == null || _comment == String.Empty || _id <= 0)
            {
                // fill in error reporting
                return;
            }

            try
            {
                _appointmentsTableAdapter.Connection.Open();
                _appointmentsTableAdapter.AppointmentsDeleteQuery(_id, _date, _comment);
                _appointmentsTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgDeleteFailed);
            }
        }

        public static void getClientNameAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillByName(_clinicDBDataSet.ClientsAutoComplete);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientNameWhereSurNameAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, string _surName)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _surName == string.Empty)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillByNameWhereSurname(_clinicDBDataSet.ClientsAutoComplete, _surName);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientNameWhereAddressAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, string _address)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _address == string.Empty)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillByNameWhereAddress(_clinicDBDataSet.ClientsAutoComplete, _address);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientNameWhereSurNameAndAddressAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, string _surname, string _address)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _address == string.Empty || _surname == string.Empty)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillByNameWhereSurnameAndAddress(_clinicDBDataSet.ClientsAutoComplete, _surname, _address);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientSurNameAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillBySurName(_clinicDBDataSet.ClientsAutoComplete);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientSurNameWhereNameAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _name == string.Empty)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillBySurNameWhereName(_clinicDBDataSet.ClientsAutoComplete, _name);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientSurNameWhereAddressAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, string _address)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _address == string.Empty)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillBySurNameWhereAddress(_clinicDBDataSet.ClientsAutoComplete, _address);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientSurNameWhereSurNameAndAddressAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _address)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _name == string.Empty ||_address == string.Empty)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillBySurNameWhereNameAndAddress(_clinicDBDataSet.ClientsAutoComplete, _name, _address);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getStaffQualificationAutoCmplt(clinicDBDataSetTableAdapters.StaffDropDownTableAdapter _staffAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet)
        {
            if (_staffAutoCmpltTableAdapter == null || _clinicDBDataSet == null)
            {
                return;
            }

            try
            {
                _staffAutoCmpltTableAdapter.Connection.Open();
                _staffAutoCmpltTableAdapter.FillByQualifications(_clinicDBDataSet.StaffDropDown);
                _staffAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.erorMsgGetAutoCmpltStaffData);
            }
        }

        public static void getClientAddressAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillByAddress(_clinicDBDataSet.ClientsAutoComplete);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientAddressWhereNameAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _name == string.Empty)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillByAddressWhereName(_clinicDBDataSet.ClientsAutoComplete, _name);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientAddressWhereSurNameAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, string _surName)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _surName == string.Empty)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillByAddressWhereSurName(_clinicDBDataSet.ClientsAutoComplete, _surName);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientAddressWhereNameAndSurNameAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, string _name, string _surName)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _surName == string.Empty || _name == string.Empty)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillByAddressWhereNameAndSurName(_clinicDBDataSet.ClientsAutoComplete, _name, _surName);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getClientEmailAutoCmplt(clinicDBDataSetTableAdapters.ClientsAutoCompleteTableAdapter _clientsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet)
        {
            if (_clientsAutoCmpltTableAdapter == null || _clinicDBDataSet == null)
            {
                return;
            }

            try
            {
                _clientsAutoCmpltTableAdapter.Connection.Open();
                _clientsAutoCmpltTableAdapter.FillByEmails(_clinicDBDataSet.ClientsAutoComplete);
                _clientsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltClientData);
            }
        }

        public static void getPetNameAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillByName(_clinicDBDataSet.PetsAutoComplete);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static void getPetSpeciesAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillBySpecies(_clinicDBDataSet.PetsAutoComplete);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }


        public static ArrayList autoCmpltClientNameArray(clinicDBDataSet.ClientsAutoCompleteDataTable _clientsAutoCompleteDataTable)
        {
            ArrayList listFromDataTable = new ArrayList();

            foreach (DataRow row in _clientsAutoCompleteDataTable.Rows)
            {
                listFromDataTable.Add(row[Properties.Resources.dataBaseFieldClientName].ToString());           
            }

            return listFromDataTable;
        }

        public static ArrayList autoCmpltClientSurNameArray(clinicDBDataSet.ClientsAutoCompleteDataTable _clientsAutoCompleteDataTable)
        {
            ArrayList listFromDataTable = new ArrayList();

            foreach (DataRow row in _clientsAutoCompleteDataTable.Rows)
            {
                listFromDataTable.Add(row[Properties.Resources.dataBaseFieldClientSurname].ToString());
            }

            return listFromDataTable;
        }

        public static ArrayList autoCmpltClientAddressArray(clinicDBDataSet.ClientsAutoCompleteDataTable _clientsAutoCompleteDataTable)
        {
            ArrayList listFromDataTable = new ArrayList();

            foreach (DataRow row in _clientsAutoCompleteDataTable.Rows)
            {
                listFromDataTable.Add(row[Properties.Resources.dataBaseFieldClientAddress].ToString());
            }

            return listFromDataTable;
        }

        public static ArrayList autoCmpltClientEmailArray(clinicDBDataSet.ClientsAutoCompleteDataTable _clientsAutoCompleteDataTable)
        {
            ArrayList listFromDataTable = new ArrayList();

            foreach (DataRow row in _clientsAutoCompleteDataTable.Rows)
            {
                listFromDataTable.Add(row[Properties.Resources.dataBaseFieldClientEmail].ToString());
            }

            return listFromDataTable;
        }

        public static ArrayList autoCmpltStaffQualificationsArray(clinicDBDataSet.StaffDropDownDataTable _staffAutoCompleteDataTable)
        {
            ArrayList listFromDataTable = new ArrayList();

            foreach (DataRow row in _staffAutoCompleteDataTable.Rows)
            {
                listFromDataTable.Add(row[Properties.Resources.dataBaseFieldStaffQualification].ToString());
            }

            return listFromDataTable;
        }

        public static ArrayList autoCmpltPetNameArray(clinicDBDataSet.PetsAutoCompleteDataTable _petsAutoCompleteDataTable)
        {
            ArrayList listFromDataTable = new ArrayList();

            foreach (DataRow row in _petsAutoCompleteDataTable.Rows)
            {
                listFromDataTable.Add(row[Properties.Resources.dataBaseFieldPetName].ToString());
            }

            return listFromDataTable;
        }


        public static ArrayList autoCmpltPetSpeciesArray(clinicDBDataSet.PetsAutoCompleteDataTable _petsAutoCompleteDataTable)
        {
            ArrayList listFromDataTable = new ArrayList();

            foreach (DataRow row in _petsAutoCompleteDataTable.Rows)
            {
                listFromDataTable.Add(row[Properties.Resources.dataBaseFieldPetSpecies].ToString());
            }

            return listFromDataTable;
        }

        public static ArrayList autoCmpltPetGenderArray(clinicDBDataSet.PetsAutoCompleteDataTable _petsAutoCompleteDataTable)
        {
            ArrayList listFromDataTable = new ArrayList();

            foreach (DataRow row in _petsAutoCompleteDataTable.Rows)
            {
                listFromDataTable.Add(row[Properties.Resources.dataBaseFieldPetGender].ToString());
            }

            return listFromDataTable;
        }

        public static void getPetNameAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillByNameWhereClientId(_clinicDBDataSet.PetsAutoComplete, _clientId);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static void getPetsNameWhereSpeciesAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId, string _species)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0 || _species == string.Empty)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillByNameWhereClientIdSpecies(_clinicDBDataSet.PetsAutoComplete, _clientId, _species);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static void getPetsNameWhereGenderAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId, string _gender)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0 || _gender == string.Empty)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillByNameWhereClientIdGender(_clinicDBDataSet.PetsAutoComplete, _clientId, _gender);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static void getPetsNameWhereSpeciesGenderAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId, string _gender, string _species)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0 || _gender == string.Empty || _species == string.Empty)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillByNameWhereClientIdSpeciesGender(_clinicDBDataSet.PetsAutoComplete, _clientId, _species, _gender);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        //
        public static void getPetSpeciesAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillBySpeciesWhereClientId(_clinicDBDataSet.PetsAutoComplete, _clientId);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static void getPetsSpeciesWhereNameAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId, string _name)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0 || _name == string.Empty)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillBySpeciesWhereClientIdName(_clinicDBDataSet.PetsAutoComplete, _clientId, _name);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static void getPetsSpeciesWhereGenderAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId, string _gender)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0 || _gender == string.Empty)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillBySpeciesWhereClientIdGender(_clinicDBDataSet.PetsAutoComplete, _clientId, _gender);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static void getPetsSpeciesWhereNameGenderAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId, string _gender, string _name)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0 || _gender == string.Empty || _name == string.Empty)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillBySpeciesWhereClientIdNameGender(_clinicDBDataSet.PetsAutoComplete, _clientId, _name, _gender);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        //
        public static void getPetGenderAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillByGenderWhereClientId(_clinicDBDataSet.PetsAutoComplete, _clientId);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static void getPetsGenderWhereNameAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId, string _name)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0 || _name == string.Empty)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillByGenderWhereClientIdName(_clinicDBDataSet.PetsAutoComplete, _clientId, _name);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static void getPetsGenderWhereSpeciesAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId, string _species)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0 || _species == string.Empty)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillByGenderWhereClientIdSpecies(_clinicDBDataSet.PetsAutoComplete, _clientId, _species);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static void getPetsGenderWhereNameSpeciesAutoCmplt(clinicDBDataSetTableAdapters.PetsAutoCompleteTableAdapter _petsAutoCmpltTableAdapter, clinicDBDataSet _clinicDBDataSet, int _clientId, string _species, string _name)
        {
            if (_petsAutoCmpltTableAdapter == null || _clinicDBDataSet == null || _clientId < 0 || _species == string.Empty || _name == string.Empty)
            {
                return;
            }

            try
            {
                _petsAutoCmpltTableAdapter.Connection.Open();
                _petsAutoCmpltTableAdapter.FillByGenderWhereClientIdNameSpecies(_clinicDBDataSet.PetsAutoComplete, _clientId, _name, _species);
                _petsAutoCmpltTableAdapter.Connection.Close();
            }
            catch (System.Exception ex)
            {
                // fill in error reporting
                MessageBox.Show(Properties.Resources.errorMsgGetAutoCmpltPetData);
            }
        }

        public static ArrayList getFullPetInfoList(clinicDBDataSet.PetsDataTable _petsDataTable)
        {
            ArrayList listFromDataTable = new ArrayList();

            foreach (DataRow row in _petsDataTable.Rows)
            {
                listFromDataTable.Add(row[Properties.Resources.dataBaseFieldPetSpecies].ToString() + ' ' + row[Properties.Resources.dataBaseFieldPetName].ToString() + ' ' + row[Properties.Resources.dataBaseFieldPetGender].ToString().ToLower());
            }

            return listFromDataTable;
        }

        public static string createGridFilterClause(TextBox[] _appointmentJoinGridFilterTextBoxes, string _dataBaseFieldReplace)
        {
            string appJoinFilterDataBaseName = String.Empty, appJoinFilterDataBaseValue = String.Empty, appJoinFilterFieldClause = String.Empty, appJoinFilterFullClause = String.Empty;    

            for (int i = 0; i < _appointmentJoinGridFilterTextBoxes.Count(); i++)
            {
                if (i != 0 && _appointmentJoinGridFilterTextBoxes[i].Text != string.Empty)
                {
                    appJoinFilterDataBaseName = _appointmentJoinGridFilterTextBoxes[i].Name.Replace(_dataBaseFieldReplace, "");
                    appJoinFilterDataBaseValue = _appointmentJoinGridFilterTextBoxes[i].Text;
                    appJoinFilterFieldClause = appJoinFilterDataBaseName.Contains(Properties.Resources.checkIfDataFieldContainsDate) ? String.Concat(appJoinFilterDataBaseName, " ", "=", " ", "'", appJoinFilterDataBaseValue, "'") : String.Concat(appJoinFilterDataBaseName, " ", "like", " ", "'", "*", appJoinFilterDataBaseValue, "*", "'");
                    if (appJoinFilterFullClause != String.Empty)
                    {
                        appJoinFilterFieldClause = String.Concat(" ", "AND", " ", appJoinFilterFieldClause);    
                    }
                    appJoinFilterFullClause = String.Concat(appJoinFilterFullClause, appJoinFilterFieldClause);    
                }

                if (i == 0 && _appointmentJoinGridFilterTextBoxes[i].Text != string.Empty)
                {
                    // 1. is textboxo name sugeneruojam DB lauko pavadinima
                    appJoinFilterDataBaseName = _appointmentJoinGridFilterTextBoxes[i].Name.Replace(_dataBaseFieldReplace, "");
                    // 2. is textboxo paimam text verte
                    appJoinFilterDataBaseValue = _appointmentJoinGridFilterTextBoxes[i].Text;
                    // 3. format full string pagal textboxa
                    appJoinFilterFieldClause = appJoinFilterDataBaseName.Contains(Properties.Resources.checkIfDataFieldContainsDate) ? String.Concat(appJoinFilterDataBaseName, " ", "=", " ", "'", appJoinFilterDataBaseValue, "'") : String.Concat(appJoinFilterDataBaseName, " ", "like", " ", "'", "*", appJoinFilterDataBaseValue, "*", "'");    
                    // 5. visa pridedam prie clause stringo
                    appJoinFilterFullClause = String.Concat(appJoinFilterFullClause, appJoinFilterFieldClause);  
                }
            }
            return appJoinFilterFullClause;
        }

        public static void filterBindingSource(BindingSource _bindingSource, string _clause)
        {
            if (_bindingSource == null || _clause == String.Empty)
            {
                MessageBox.Show(Properties.Resources.errorMsgFilteringFailed); 
                return;    
            }

            try
            {
                _bindingSource.Filter = _clause;
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.errorMsgFilteringFailed); 
            }
        }
    }
}
