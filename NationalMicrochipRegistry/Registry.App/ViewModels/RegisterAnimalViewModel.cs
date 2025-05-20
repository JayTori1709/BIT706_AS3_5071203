using ReactiveUI;
using System.Reactive;
using Registry.Data.Models;
using Registry.Data.Services;

namespace RegistryApp.ViewModels
{
    public class RegisterAnimalViewModel : ViewModelBase
    {
        private readonly AnimalService _animalService;

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
            _animalService = new AnimalService(App.DbContext);

            RegisterCommand = ReactiveCommand.Create(() =>
            {
                var animal = new Animal
                {
                    Name = AnimalName,
                    Species = Species,
                    OwnerName = OwnerName
                };

                _animalService.AddAnimal(animal);

                // Optional: clear fields after save
                AnimalName = Species = OwnerName = string.Empty;
            });
        }
    }
}
