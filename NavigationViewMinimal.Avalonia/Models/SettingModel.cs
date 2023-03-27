using System.Reactive;
using NavigationViewMinimal.Avalonia.ViewModels.Dashboard;
using ReactiveUI;

namespace NavigationViewMinimal.Avalonia.Models;

public class SettingModel
{
    public string Title { get; set; } = "No Title";
    public ReactiveCommand<Unit, Unit> DoSettingCommand { get; }

    public SettingModel(SettingsViewModel.DoSettingDel doSettingDel)
    {
        
        DoSettingCommand = ReactiveCommand.Create(() =>doSettingDel());
    } 
}