using System.Collections.Generic;
using NavigationViewMinimal.Avalonia.Models;

namespace NavigationViewMinimal.Avalonia.ViewModels.Dashboard;

public class SettingsViewModel : DashboardViewModelBase
{
    public List<SettingModel> Settings { get; set; } = new();

    public delegate void DoSettingDel();

    public SettingsViewModel()
    {
        for (int i = 0; i < 15; i++)
        {
            Settings.Add(new SettingModel(DoSetting)
            {
                Title = $"Setting {i}"
            });
        }
    }

    private void DoSetting()
    {
       //Nothing goes here 
    }
}