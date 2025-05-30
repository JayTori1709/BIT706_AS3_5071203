using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using Registry.Data.Models;
using Registry.Data.Services;

namespace RegistryApp.ViewModels
{
    public class RegisterAnimalViewModel : ViewModelBase
    {
        private readonly AnimalService _animalService;
        private readonly ClinicService _clinicService;

        private string _animalName;
        private string _species;
        private string _ownerName;
        private Clinic _selectedClinic;

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

        public Clinic SelectedClinic
        {
            get => _selectedClinic;
            set => this.RaiseAndSetIfChanged(ref _selectedClinic, value);
        }

        public ObservableCollection<Clinic> Clinics { get; } = new();

        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }
        public ReactiveCommand<Unit, Unit> BackCommand { get; }

        public RegisterAnimalViewModel()
        {
            _animalService = new AnimalService(App.DbContext);
            _clinicService = new ClinicService(App.DbContext);

            var clinics = _clinicService.GetAllClinics();
            if (clinics != null)
            {
                foreach (var clinic in clinics)
                    Clinics.Add(clinic);
            }

            RegisterCommand = ReactiveCommand.Create(RegisterAnimal);
            BackCommand = ReactiveCommand.Create(() =>
            {
                MainWindowViewModel.Instance.CurrentView = new DashboardViewModel();
            });
        }

        private void RegisterAnimal()
        {
            if (string.IsNullOrWhiteSpace(AnimalName) ||
                string.IsNullOrWhiteSpace(Species) ||
                string.IsNullOrWhiteSpace(OwnerName) ||
                SelectedClinic == null)
                return;

            var animal = new Animal
            {
                Name = AnimalName,
                Species = Species,
                OwnerName = OwnerName,
                ClinicId = SelectedClinic.Id
            };

            _animalService.AddAnimal(animal);

            // Clear fields after registration
            AnimalName = Species = OwnerName = string.Empty;
            SelectedClinic = null;
        }
    }
}
