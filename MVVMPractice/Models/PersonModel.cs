
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPractice
{
    class PersonModel : ViewModelBase
    {
        private bool mIsSelected = false;
        public string Name { get; set; }
        public double Money { get; set; }
        public ObservableCollection<CarModel> Cars { get; set; }

        public bool IsSelected
        {
            get
            {
                return mIsSelected;
            }
            set
            {
                mIsSelected = value;
                if (value)
                {
                    OnSelected?.Invoke(this);
                }
            }
        }
        public CarModel SelectedCar { get; set; }

        public Action<PersonModel> OnSelected { get; set; }

        public ICommand GotoGarageCommand { get; set; }

        public ICommand BuyCarCommand { get; set; }

        public ICommand SellCarCommand { get; set; }

        public PersonModel()
        {
            Cars = new ObservableCollection<CarModel>();

            GotoGarageCommand = new RelayCommand(OpenGarage);
            BuyCarCommand = new RelayCommand(BuyCar);
            SellCarCommand = new RelayCommand(SellCar);
        }

        public void SelectACar(CarModel carModel)
        {
            SelectedCar = carModel;
            BuyCar();
        }

        private void OpenGarage()
        {
            foreach(var car in Cars)
            {
                if (car != SelectedCar)
                {
                    car.IsSelected = false;
                }
                
            }

            IsSelected = true;

            App.context.ChangePage(new GarageViewModel(this), new GarageView());
        }

        private void BuyCar()
        {
            CarModel car = SelectedCar;
            if (SelectedCar != null)
            {
                if (Money > car.CarData.Value)
                {
                    Cars.Add(car);
                }
            }
            
        }

        private void SellCar()
        {
            CarModel car = SelectedCar;

            Money += car.CarData.Value;
            Cars.Remove(car);
        }
    }
}
