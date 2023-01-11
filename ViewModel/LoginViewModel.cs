using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppDemoCPCBhathi.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //define properties to estublish the binding between view and the viewodel

        //fields
        private string _username;
        private SecureString _password; //not nessesararaly this data type 
        private string _errorMessage;
        private bool _isViewVisible = true;

        //properties
        public string Username 
        {
            get => _username;
            set 
            { 
                _username = value;
                OnPropertyChanged(nameof(Username));
            } 
        }
        public SecureString Password 
        { 
            get => _password;
            set 
            { 
                _password = value;
                OnPropertyChanged(nameof(Password));
            } 
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set 
            { 
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            } 
        }
        public bool IsViewVisible 
        {
            get => _isViewVisible;
            set 
            { 
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            } 
        }

        //commands
        public ICommand LoginCommand { get;}

        //constructor
        public LoginViewModel() 
        {
            LoginCommand = new ViewModelCommand(ExcecuteLoginCommand, CanExcecuteLoginCommand);
        }

        private bool CanExcecuteLoginCommand(object obj)
        {
            bool validate;
            if(string.IsNullOrWhiteSpace(Username) || Username.Length < 2 || Password == null || Password.Length < 2) 
            {
                validate = false;
            }
            else 
            {
                validate = true;
            }

            return validate;
        }

        private void ExcecuteLoginCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
