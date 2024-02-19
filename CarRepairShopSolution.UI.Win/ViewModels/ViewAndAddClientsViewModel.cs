// <copyright file="ViewAndAddClientsViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.UI.Win.ViewModels;

using CarRepairShopSolution.UI.Win.Commands;
using CarRepairShopSolution.UI.Win.Navigation;
using CarRepairShopSolution.UI.Win.ViewModels.Abstractions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.Repositories;

public partial class ViewAndAddClientsViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    private readonly IClientRepository _clientRepository;

    private string _firstName;

    private string _lastName;

    private string _phoneNumber;

    public ObservableCollection<ClientModel> Clients { get; set; } = new ObservableCollection<ClientModel>();

    public string FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    public string LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => SetProperty(ref _phoneNumber, value);
    }

    public ICommand AddClientCommand { get; }

    public ICommand GoBackCommand { get; }

    public ViewAndAddClientsViewModel(INavigationService navigationService, IClientRepository clientRepository)
    {
        _navigationService = navigationService;
        _clientRepository = clientRepository;

        AddClientCommand = new RelayCommand(async () => await AddClientAsync());
        GoBackCommand = new RelayCommand(() => _navigationService.NavigateBack());

        LoadClientsAsync();
    }

    private async void LoadClientsAsync()
    {
        Clients.Clear();
        var clientModels = await _clientRepository.GetAllAsync();

        foreach (var client in clientModels)
        {
            Clients.Add(client);
        }
    }

    private async Task AddClientAsync()
    {
        var clientModel = new ClientModel(FirstName, LastName, PhoneNumber, DateTimeOffset.Now, DateTimeOffset.Now);

        try
        {
            var success = await _clientRepository.AddAsync(clientModel);
            if (success)
            {
                // Refresh the collection
                LoadClientsAsync();
                FirstName = string.Empty;
                LastName = string.Empty;
                PhoneNumber = string.Empty;
            }
            else
            {
                ErrorMessage = "Failed to add client.";
            }
        }
        catch (Exception ex)
        {
            // Consider logging the exception
            ErrorMessage = $"Failed to add client: {ex.Message}";
        }
    }
}
