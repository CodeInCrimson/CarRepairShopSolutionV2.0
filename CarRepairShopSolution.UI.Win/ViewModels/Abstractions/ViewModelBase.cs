using CommunityToolkit.Mvvm.ComponentModel;
using System.Net.Mail;

namespace CarRepairShopSolution.UI.Win.ViewModels.Abstractions;

public abstract class ViewModelBase : ObservableObject, IViewModel
{
    private bool _isLoading;
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

    protected bool ValidatePhone(string phoneInput)
    {
        if (string.IsNullOrWhiteSpace(phoneInput))
        {
            ErrorMessage = "TODO: ValidatePhone";
            return false;
        }

        ErrorMessage = string.Empty;

        return true;
    }
}
