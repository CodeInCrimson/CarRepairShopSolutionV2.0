using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShopSolution.UI.Win.ViewModels;

public interface IViewModel
{
    public bool IsLoading { get; set; }

    public string ErrorMessage { get; set; }

    public void OnDismissed();

    public void OnLoaded();

    public Task InitializeAsync(object navigationData);
}
