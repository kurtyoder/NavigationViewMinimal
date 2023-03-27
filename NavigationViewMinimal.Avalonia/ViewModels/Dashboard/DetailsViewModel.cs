using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NavigationViewMinimal.Avalonia.Models;

namespace NavigationViewMinimal.Avalonia.ViewModels.Dashboard;

public class DetailsViewModel : DashboardViewModelBase
{
    public ObservableCollection<DetailModel> Details { get; set; } = new();

    public DetailsViewModel()
    {
    }

    public override async Task LoadTabData()
    {
        await Task.Delay(2000);
        Details.Clear();

        for (int i = 0; i < 15; i++)
        {
            Details.Add(new DetailModel()
            {
                Title = i.ToString()
            });
        }
    }
}