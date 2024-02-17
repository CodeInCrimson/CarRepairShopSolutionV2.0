using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShopSolution.UI.Win.ViewModels.Abstractions;

public abstract class ViewModelBase : ObservableObject, IViewModel
{
    private bool _isLoading;
    private bool _isEmergency;
    private string _errorMessage = string.Empty;

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged(nameof(IsLoading));
        }
    }

    public bool IsEmergency
    {
        get => _isEmergency;
        set
        {
            _isEmergency = value;
            OnPropertyChanged(nameof(IsEmergency));
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }

    public virtual void OnDismissed()
    {
        // do nothing.
    }

    public virtual void OnLoaded()
    {
        // do nothing.
    }

    public virtual Task InitializeAsync(object navigationData)
    {
        return Task.CompletedTask;
    }

    protected void OnLoadingFinished()
    {
        IsLoading = false;
    }

    protected bool ValidateEmail(string emailInput)
    {
        if (string.IsNullOrWhiteSpace(emailInput))
        {
            ErrorMessage = "TODO: ValidateEmail";
            return false;
        }

        if (!MailAddress.TryCreate(emailInput, out MailAddress? _))
        {
            ErrorMessage = "TODO: ValidateEmail";
            return false;
        }

        ErrorMessage = string.Empty;

        return true;
    }
}
