using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using Registry.Data.Models;
using Registry.Data.Services;

namespace RegistryApp.ViewModels
{
    public class ManageUsersViewModel : ViewModelBase
    {
        private readonly UserService _userService;
        public ObservableCollection<User> Users { get; } = new();

        public ReactiveCommand<User, Unit> DeleteCommand { get; }
        public ReactiveCommand<Unit, Unit> AddUserCommand { get; }

        public ManageUsersViewModel()
        {
            _userService = new UserService(App.DbContext);

            LoadUsers();

            DeleteCommand = ReactiveCommand.Create<User>(user =>
            {
                _userService.DeleteUser(user.Id);
                LoadUsers();
            });

            AddUserCommand = ReactiveCommand.Create(() =>
            {
                var newUser = new User { Username = "newuser", PasswordHash = "password", Role = "Clinic" };
                _userService.AddUser(newUser);
                LoadUsers();
            });
        }

        private void LoadUsers()
        {
            Users.Clear();
            foreach (var user in _userService.GetAllUsers())
                Users.Add(user);
        }
    }
}
