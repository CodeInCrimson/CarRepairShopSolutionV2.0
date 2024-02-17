// <copyright file="NavigationService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.UI.Win.Navigation;

using CarRepairShopSolution.UI.Win.ViewModels;
using Microsoft.Extensions.DependencyInjection;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public event EventHandler<ViewChangedEventArgs>? ViewChanged;

    public void NavigateTo<TViewModel>()
        where TViewModel : IViewModel
    {
        var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
        ChangeView(viewModel);
    }

    public Task NavigateToAsync<TViewModel>(object parameter)
        where TViewModel : IViewModel
    {
        var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
        ChangeView(viewModel);

        // TODO: non-async navigation will not trigger this initialization
        return viewModel.InitializeAsync(parameter);
    }

    private void ChangeView(IViewModel newViewModel)
    {
        ViewChanged?.Invoke(this, new ViewChangedEventArgs(newViewModel));
    }
}
