using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace RegistryApp.ViewModels
{
    public class AssignMicrochipViewModel : ViewModelBase
    {
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

        public AssignMicrochipViewModel()
        {
            AssignCommand = ReactiveCommand.Create(() =>
            {
                // Logic to assign chip to animal
            });
        }
    }

    public class Animal { public string Name { get; set; } }
    public class Microchip { public string SerialNumber { get; set; } }
}
