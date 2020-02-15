using MVVMPractice.Views;
using System.Windows.Controls;

namespace MVVMPractice.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ViewModelBase SelectedViewModel { get; set; } = new HomeViewModel();

        public UserControl SelectedView { get; set; } = new HomeView();

        public ShellViewModel()
        {
            SelectedView.DataContext = SelectedViewModel;
        }

        public void ChangePage(ViewModelBase viewModel, UserControl view)
        {
            SelectedViewModel = viewModel;
            SelectedView = view;
            SelectedView.DataContext = SelectedViewModel;
        }
    }
}
