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
        public ReactiveCommand<Unit, Unit> GenerateChipsCommand { get; }
        public ReactiveCommand<Unit, Unit> BackCommand { get; }

        public AssignMicrochipViewModel()
        {
            _animalService = new AnimalService(App.DbContext);
            _microchipService = new MicrochipService(App.DbContext);

            LoadData();

            AssignCommand = ReactiveCommand.Create(() =>
            {
                if (SelectedAnimal != null && SelectedChip != null)
                {
                    _microchipService.AssignMicrochipToAnimal(SelectedChip.Id, SelectedAnimal.Id);
                    LoadData(); // Refresh the lists
                }
            });

            GenerateChipsCommand = ReactiveCommand.Create(() =>
            {
                _microchipService.GenerateMicrochips(10); // Add 10 chips
                LoadData(); // Refresh the list
            });

            BackCommand = ReactiveCommand.Create(() =>
            {
                MainWindowViewModel.Instance.CurrentView = new DashboardViewModel();
            });
        }

        private void LoadData()
        {
            Animals.Clear();
            AvailableChips.Clear();

            foreach (var animal in _animalService.GetAnimalsWithoutChip())
                Animals.Add(animal);

            foreach (var chip in _microchipService.GetUnassignedChips())
                AvailableChips.Add(chip);
        }
    }
}
