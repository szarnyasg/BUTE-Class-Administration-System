using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using System.Windows;
using System.ComponentModel;
using System.Text.RegularExpressions;
using BUTEClassAdministrationClient.View;

namespace BUTEClassAdministrationClient.ViewModels
{
    public class InstructorViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        Window insertInstructorWindow;

        private Instructor _instructor;

        #region Properties

        public string Name 
        { 
            get
            {
                return _instructor.Name;
            }
            set
            {
                if (_instructor.Name != value)
                {
                    _instructor.Name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public string Neptun
        {
            get
            {
                return _instructor.Neptun;
            }
            set
            {
                if (_instructor.Neptun != value)
                {
                    _instructor.Neptun = value;
                    NotifyPropertyChanged("Neptun");
                }
            }
        }

        public string Email
        {
            get
            {
                return _instructor.Email;
            }
            set
            {
                if (_instructor.Email != value)
                {
                    _instructor.Email = value;
                    NotifyPropertyChanged("Email");
                }
            }
        }

        #endregion

        #region Constructor

        public InstructorViewModel()
        {
            _instructor =  new Instructor();
            Name = "";
            Neptun = "";
            Email = "";

            insertInstructorWindow = new InsertInstructorWindow();

            insertInstructorWindow.DataContext = this;

            insertInstructorWindow.ShowDialog();
        }

        #endregion

        #region save instructor command members

        private DelegateCommand _saveInstructorCommand;
        public ICommand SaveInstructorCommand
        {
            get
            {
                if(_saveInstructorCommand == null)
                    _saveInstructorCommand = new DelegateCommand(new Action(saveInstruktorExecuted), new Func<bool>(saveInstructorcanExecuted));
                return _saveInstructorCommand;
            }
        }

        public void saveInstruktorExecuted()
        {
            using (var service = new ClassAdministrationServiceClient())
            {

                service.CreateInstructor(new Instructor[] { _instructor });
                _instructor.AcceptChanges();

                MessageBox.Show("Rekord beszúrva.");

                insertInstructorWindow.Close();
            }
        }

        public bool saveInstructorcanExecuted()
        {
            return nameIsValid(Name) && neptunIsValid(Neptun) && emailIsValid(Email);
        }

        #endregion 

        #region cancel command members

        private DelegateCommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new DelegateCommand(new Action(cancelExecuted));
                return _cancelCommand;
            }
        }

        public void cancelExecuted()
        {
            insertInstructorWindow.Close();
        }

        #endregion

        #region INotifyPropertyChanged members

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region validation

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { return validateInstructor(columnName); }
        }

        private string validateInstructor(string propName)
        {

            switch (propName)
            {
                case "Name":
                    {
                        if (nameIsValid(Name)) return null;
                        else return "Kérem adja meg a gyakorlatvezető nevét!";
                    }
                case "Neptun":
                    {
                        if (neptunIsValid(Neptun)) return null;
                        else return "A Neptunkód nincs megadva, vagy hibás formátumú.";
                    }
                case "Email":
                    {
                        if (emailIsValid(Email)) return null;
                        else return "Az email nincs megadva, vagy hibás formátumú.";
                    }
                default:
                    return "Nem leteyo properti validalas.";
            }

        }

        public bool nameIsValid(string value)
        {
            return (value.Length > 0);
        }

        public bool neptunIsValid(string value)
        {
            string neptunregex = @"^[A-Z][A-Z0-9]{5}$";
            return Regex.IsMatch(value, neptunregex, RegexOptions.IgnoreCase);
        }

        public static bool emailIsValid(string value)
        {
            string emailregex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return Regex.IsMatch(value, emailregex, RegexOptions.IgnoreCase);

        }

        #endregion 


    }
}
