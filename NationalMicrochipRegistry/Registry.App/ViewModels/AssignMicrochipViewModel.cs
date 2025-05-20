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

        private Animal _selectedAnimal;
        public Animal SelectedAnimal
        {
            get => _selectedAnimal;
            set => this.RaiseAndSetIfChanged(ref _selectedAnimal, value);
        }

        private Microchip _selectedChip;
        public Microchip SelectedChip
        {
            get => _selectedChip;
            set => this.RaiseAndSetIfChanged(ref _selectedChip, value);
        }

        public ReactiveCommand<Unit, Unit> AssignCommand { get; }
        public ReactiveCommand<Unit, Unit> BackCommand { get; }

        public AssignMicrochipViewModel()
        {
            _animalService = new AnimalService(App.DbContext);
            _microchipService = new MicrochipService(App.DbContext);

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

            BackCommand = ReactiveCommand.Create(() =>
            {
                MainWindowViewModel.Instance.CurrentView = new DashboardViewModel();
            });
        }
    }
}