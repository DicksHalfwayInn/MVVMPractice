using MVVMPractice.Commands;
using MVVMPractice.Models;
using MVVMPractice.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMPractice.ViewModels
{
    class HomeViewModel: ViewModelBase
    {
        
        public ObservableCollection<PersonModel> People { get; set; }

        public PersonModel SelectedPerson { get; set; }

        public ICommand PersonIsSelected { get; set; }

        public HomeViewModel()
        {
            People = new ObservableCollection<PersonModel>() {
                new PersonModel() { Name = "Bob Dylan", Money = 50000, OnSelected = SelectAPerson},
                new PersonModel() { Name = "Bob Marley", Money = 120000, OnSelected = SelectAPerson},
                new PersonModel() { Name = "Bob Ross", Money = 75000 , OnSelected = SelectAPerson},
                new PersonModel() { Name = "Bob Barker", Money = 350000, OnSelected = SelectAPerson }
            };



            PersonIsSelected = new RelayCommand(GotoGarageView);
        }

        public void GotoGarageView()
        {
            
                App.context.ChangePage(new GarageViewModel(SelectedPerson), new GarageView());
            
        }

        public void SelectAPerson(PersonModel selectedPerson)
        {

            foreach (var person in People)
            {
                if (person != selectedPerson)
                {
                    person.IsSelected = false;
                }
               
            }

            SelectedPerson = selectedPerson;
        }
    }
}
