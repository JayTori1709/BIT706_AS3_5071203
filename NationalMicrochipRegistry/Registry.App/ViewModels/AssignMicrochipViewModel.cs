using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using Registry.Data.Models;
using Registry.Data.Services;

namespace RegistryApp.ViewModels
{
    public class AssignMicrochipViewModel : ViewModelBase
    {
        private readonly AnimalService _animalService;
        private readonly MicrochipService _microchipService;

        public ObservableCollection<Animal> Animals { get; } = new();
        public ObservableCollection<Microchip> AvailableChips { get; } = new();
    

        public Animal SelectedAnimal { get; set; }
        public Microchip SelectedChip { get; set; }

        public ReactiveCommand<Unit, Unit> AssignCommand { get; }

        public AssignMicrochipViewModel()
        {
            _animalService = new AnimalService(App.DbContext);
            _microchipService = new MicrochipService(App.DbContext);

            // Populate dropdowns
            foreach (var animal in _animalService.GetAnimalsWithoutChip())
                Animals.Add(animal);

            foreach (var chip in _microchipService.GetUnassignedChips())
                AvailableChips.Add(chip);

            AssignCommand = ReactiveCommand.Create(() =>
            {
                if (SelectedAnimal != null && SelectedChip != null)
                {
                    _microchipService.AssignMicrochipToAnimal(SelectedChip.Id, SelectedAnimal.Id);
                }
            });
        }
    }
}
