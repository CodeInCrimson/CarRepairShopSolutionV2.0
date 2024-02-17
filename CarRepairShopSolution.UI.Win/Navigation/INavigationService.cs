namespace CarRepairShopSolution.UI.Win.Navigation;

using CarRepairShopSolution.UI.Win.ViewModels;

public interface INavigationService
{
    event EventHandler<ViewChangedEventArgs> ViewChanged;

    void NavigateTo<TViewModel>()
        where TViewModel : IViewModel;

    Task NavigateToAsync<TViewModel>(object parameter)
        where TViewModel : IViewModel;
}
