namespace CarRepairShopSolution.UI.Win.Navigation;

using CarRepairShopSolution.UI.Win.ViewModels;
using CarRepairShopSolution.UI.Win.ViewModels.Abstractions;

public interface INavigationService
{
    event EventHandler<ViewChangedEventArgs> ViewChanged;

    void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;

    void NavigateBack();
}