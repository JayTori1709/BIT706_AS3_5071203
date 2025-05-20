using ReactiveUI;
using System;
using System.Reactive;
using Registry.Data.Services;

namespace RegistryApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _hasError;

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        public bool HasError
        {
            get => _hasError;
            set => this.RaiseAndSetIfChanged(ref _hasError, value);
        }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        public event Action LoginSucceeded;

        public LoginViewModel()
        {
            LoginCommand = ReactiveCommand.Create(() =>
            {
                if (Username == "admin" && Password == "password")
                {
                    LoginSucceeded?.Invoke();
                }
                else
                {
                    HasError = true;
                    ErrorMessage = "Invalid username or password.";
                }
            });
        }
    }
}
