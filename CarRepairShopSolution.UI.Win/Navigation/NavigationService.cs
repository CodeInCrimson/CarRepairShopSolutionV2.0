// <copyright file="NavigationService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.UI.Win.Navigation;

using CarRepairShopSolution.UI.Win.ViewModels;
using CarRepairShopSolution.UI.Win.ViewModels.Abstractions;
using Microsoft.Extensions.DependencyInjection;
public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public event EventHandler<ViewChangedEventArgs>? ViewChanged;

    public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
    {
        var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
        ChangeView(viewModel);
    }

    public void NavigateBack()
    {
        // TODO: Implement logic to navigate back to the HomePageViewModel
        NavigateTo<HomePageViewModel>();
    }

    private void ChangeView(ViewModelBase viewModel)
    {
        ViewChanged?.Invoke(this, new ViewChangedEventArgs(viewModel));
    }
}
