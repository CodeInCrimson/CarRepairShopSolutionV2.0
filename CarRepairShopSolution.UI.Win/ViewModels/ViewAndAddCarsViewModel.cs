// <copyright file="ViewAndAddCarsViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.UI.Win.ViewModels;

using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.Repositories;
using CarRepairShopSolution.UI.Win.Commands;
using global::CarRepairShopSolution.UI.Win.ViewModels.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

public class ViewAndAddCarsViewModel : ViewModelBase
{
    private readonly IClientRepository clientRepository;

    private int selectedClientId = -1;

    private string selectedClientDisplayString;

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewAndAddCarsViewModel"/> class.
    /// </summary>
    /// <param name="clientRepository">Injection of the necessary repository</param>
    public ViewAndAddCarsViewModel(IClientRepository clientRepository)
    {
        this.clientRepository = clientRepository;
        AddCarCommand = new RelayCommand(async () => await AddCarAsync());

        LoadClientsAsync();
    }

    public ObservableCollection<CarModel> DisplayedCars { get; } = new ObservableCollection<CarModel>();

    // public ObservableCollection<ClientModel> Clients { get; } = new ObservableCollection<ClientModel>();

    public ObservableCollection<string> ClientListboxDisplayStrings { get; } = new ObservableCollection<string>();

    public int SelectedClientId
    {
        get => selectedClientId;
        set
        {
            SetProperty(ref selectedClientId, value);
        }
    }

    /// <summary>
    /// Gets or sets selectedClientDisplayString.
    /// Extract the client ID from the selected display string and update the NewCar.ClientId.
    /// </summary>
    public string SelectedClientDisplayString
    {
        get => selectedClientDisplayString;
        set
        {
            if (SetProperty(ref selectedClientDisplayString, value))
            {
                var clientId = ExtractClientId(value);
                SelectedClientId = clientId;
            }
        }
    }

    public ICommand AddCarCommand { get; }

    private async void LoadClientsAsync()
    {
        var clientModels = await this.clientRepository.GetAllAsync();
        foreach (var client in clientModels)
        {
            string displayString = $"ID: {client.Id} - {client.Firstname} {client.Lastname}";
            this.ClientListboxDisplayStrings.Add(displayString);
        }
    }

    /// <summary>
    /// idPart - Assuming the ID is always at the start followed by ":"
    /// </summary>
    /// <param name="displayString"></param>
    /// <returns></returns>
    private int ExtractClientId(string displayString)
    {
        var idPart = displayString.Split('-')[0].Trim();
        var idStr = idPart.Split(':')[1].Trim();
        if (int.TryParse(idStr, out var clientId))
        {
            return clientId;
        }

        return -1;
    }

    private async Task AddCarAsync()
    {
        // TODO: Implement the repository logic to add a new car

        var NewCar = new CarModel(string.Empty, string.Empty, DateTime.Now.Year, -1, DateTimeOffset.Now, DateTimeOffset.Now);
    }
}
