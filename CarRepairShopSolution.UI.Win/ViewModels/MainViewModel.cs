// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.UI.Win.ViewModels;

using CarRepairShopSolution.UI.Win.Navigation;
using CarRepairShopSolution.UI.Win.ViewModels.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class MainViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    private IViewModel? _currentViewModel;

    public IViewModel? CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.ViewChanged += OnViewChanged;
    }

    private void OnViewChanged(object? sender, ViewChangedEventArgs e)
    {
        CurrentViewModel?.OnDismissed();
        CurrentViewModel = e.ViewModel;
        CurrentViewModel.OnLoaded();
    }
}
