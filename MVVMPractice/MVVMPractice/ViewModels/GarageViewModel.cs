using MVVMPractice.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPractice.ViewModels
{
    class GarageViewModel: ViewModelBase
    {
        public PersonModel SelectedPerson { get; set; }
        public ObservableCollection<CarModel> CarsForSale { get; set; }

        public GarageViewModel(PersonModel person)
        {
            SelectedPerson = person;

            CarsForSale = new ObservableCollection<CarModel>()
            {
                new CarModel(){ Brand = "Toyota", Model = "SomeModel", Condition = 67, Value = 6295, OnSelected = SelectedPerson.SelectACar},
                new CarModel(){ Brand = "Honda", Model = "Civic", Condition = 87, Value = 5000, OnSelected = SelectedPerson.SelectACar},
                new CarModel(){ Brand = "Ford", Model = "Mustang", Condition = 23, Value = 12995, OnSelected = SelectedPerson.SelectACar},
                new CarModel(){ Brand = "Ferrari", Model = "Enzo", Condition = 23, Value = 212995, OnSelected = SelectedPerson.SelectACar}
            };
        }
    }
}
