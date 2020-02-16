using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPractice
{
    class CarModel: ViewModelBase
    {
        private bool mIsSelected = false;

        public CarDataModel CarData { get; set; }


        public ICommand BuyButtonPressedCommand { get; set; }

        public ICommand SellButtonPressedCommand { get; set; }

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

        public Action<CarModel> OnSelected { get; set; }

        public CarModel()
        {
            BuyButtonPressedCommand = new RelayCommand(BuyButtonPressed);
            SellButtonPressedCommand = new RelayCommand(SellButtonPressed);
        }

        public void BuyButtonPressed()
        {
            IsSelected = true;
        }

        public void SellButtonPressed()
        {
            IsSelected = true;
        }
    }
}
