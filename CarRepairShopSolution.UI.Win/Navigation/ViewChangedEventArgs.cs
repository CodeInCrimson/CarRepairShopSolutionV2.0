namespace CarRepairShopSolution.UI.Win.Navigation;

using CarRepairShopSolution.UI.Win.ViewModels;

public class ViewChangedEventArgs : EventArgs
{
    public ViewChangedEventArgs(IViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public IViewModel ViewModel { get; }
}