using ReactiveUI;
using System.Reactive;

namespace RegistryApp.ViewModels
{
    public class RegisterAnimalViewModel : ViewModelBase
    {
        private string _animalName;
        private string _species;
        private string _ownerName;

        public string AnimalName
        {
            get => _animalName;
            set => this.RaiseAndSetIfChanged(ref _animalName, value);
        }

        public string Species
        {
            get => _species;
            set => this.RaiseAndSetIfChanged(ref _species, value);
        }

        public string OwnerName
        {
            get => _ownerName;
            set => this.RaiseAndSetIfChanged(ref _ownerName, value);
        }

        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

        public RegisterAnimalViewModel()
        {
            RegisterCommand = ReactiveCommand.Create(() =>
            {
                // Placeholder: Save animal to database
            });
        }
    }
}
