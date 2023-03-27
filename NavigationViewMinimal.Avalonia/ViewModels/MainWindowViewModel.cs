using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DynamicData;
using DynamicData.Binding;
using NavigationViewMinimal.Avalonia.ViewModels.TabPage;
using ReactiveUI;

namespace NavigationViewMinimal.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private TabViewModelBase _currentTab;
    public string Greeting => "Welcome to Avalonia!";


    public TabViewModelBase CurrentTab
    {
        get => _currentTab;
        set => this.RaiseAndSetIfChanged(ref _currentTab, value);
    }

    public ObservableCollection<TabViewModelBase> TabPages { get; } = new();


    public MainWindowViewModel()
    {
        TabPages.Add(new HasNothingViewModel("Tab Page 1"));
        TabPages.Add(new HasNavigationViewModel("Tab Page 2"));



        _currentTab = TabPages.First();
    }
}