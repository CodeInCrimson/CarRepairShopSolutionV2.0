// <copyright file="ViewAndAddCarsViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.UI.Win.ViewModels;

using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.Repositories;
using CarRepairShopSolution.UI.Win.Commands;
using CarRepairShopSolution.UI.Win.Navigation;
using CarRepairShopSolution.UI.Win.ViewModels.Abstractions;
using Serilog;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

public class ViewAndAddCarsViewModel : ViewModelBase
{
    private readonly ICarRepository _carRepository;

    private readonly IClientRepository _clientRepository;

    private readonly INavigationService _navigationService;

    private ClientModel _selectedClient;

    private string brand = string.Empty;

    private string model = string.Empty;

    private int year = DateTime.Now.Year;

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewAndAddCarsViewModel"/> class.
    /// </summary>
    /// <param name="clientRepository">Injection of the necessary repository</param>
    public ViewAndAddCarsViewModel(INavigationService navigationService, ICarRepository carRepository, IClientRepository clientRepository)
    {
        this._navigationService = navigationService;
        this._carRepository = carRepository;
        this._clientRepository = clientRepository;

        AddCarCommand = new RelayCommand(async () => await AddCarAsync());
        GoBackCommand = new RelayCommand(_navigationService.NavigateBack);

        LoadClientsAsync();
        LoadCarsAsync();
    }

    public ObservableCollection<ClientModel> Clients { get; } = new ObservableCollection<ClientModel>();

    public ObservableCollection<CarModel> DisplayedCars { get; } = new ObservableCollection<CarModel>();

    public ObservableCollection<string> ClientListboxDisplayStrings { get; } = new ObservableCollection<string>();

    public ClientModel SelectedClient
    {
        get => _selectedClient;
        set
        {
            if (SetProperty(ref _selectedClient, value))
            {
                SelectedClientId = value?.Id ?? -1;
            }
        }
    }

    public int SelectedClientId { get; private set; }

    public string Brand
    {
        get => brand;
        set => SetProperty(ref brand, value);
    }

    public string Model
    {
        get => model;
        set => SetProperty(ref model, value);
    }

    public int Year
    {
        get => year;
        set => SetProperty(ref year, value);
    }

    /// <summary>
    /// Gets or sets selectedClientDisplayString.
    /// Extract the client ID from the selected display string and update the NewCar.ClientId.
    /// </summary>
    //public string SelectedClientDisplayString
    //{
    //    get => selectedClientDisplayString;
    //    set
    //    {
    //        if (SetProperty(ref selectedClientDisplayString, value))
    //        {
    //            var clientId = ExtractClientId(value);
    //            SelectedClientId = clientId;
    //        }
    //    }
    //}

    public ICommand AddCarCommand { get; }

    public ICommand GoBackCommand { get; }

    private async void LoadClientsAsync()
    {
        Clients.Clear();
        var clientModels = await _clientRepository.GetAllAsync();
        foreach (var client in clientModels)
        {
            Clients.Add(client);
        }
    }

    private async void LoadCarsAsync()
    {
        DisplayedCars.Clear();
        var carModels = await this._carRepository.GetAllAsync();
        foreach (var car in carModels)
        {
            DisplayedCars.Add(car);
        }
    }

    /// <summary>
    /// idPart - Assuming the ID is always at the start followed by ":"
    /// </summary>
    /// <param name="displayString"></param>
    /// <returns></returns>
    //private int ExtractClientId(string displayString)
    //{
    //    var idPart = displayString.Split('-')[0].Trim();
    //    var idStr = idPart.Split(':')[1].Trim();
    //    if (int.TryParse(idStr, out var clientId))
    //    {
    //        return clientId;
    //    }

    //    return -1;
    //}

    private async Task AddCarAsync()
    {
        try
        {
            if (SelectedClientId > 0 && Year > 1920 && !string.IsNullOrEmpty(Brand) && !string.IsNullOrEmpty(Model))
            {
                var newCarModel = new CarModel(Brand, Model, Year, SelectedClientId, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);

                var success = await _carRepository.AddAsync(newCarModel);
                if (success)
                {
                    // Refresh the collection
                    LoadCarsAsync();
                    Brand = string.Empty;
                    Model = string.Empty;
                    Year = -1;
                }
                else
                {
                    ErrorMessage = "Failed to add car.";
                    Log.Information(ErrorMessage);
                }
            }
        }
        catch (Exception ex)
        {
            // Consider logging the exception
            ErrorMessage = $"Failed to add car: {ex.Message}";
            Log.Information(ErrorMessage);
        }
    }
}
