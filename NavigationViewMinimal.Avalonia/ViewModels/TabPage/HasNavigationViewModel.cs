using System.Collections.ObjectModel;
using FluentAvalonia.UI.Controls;
using NavigationViewMinimal.Avalonia.Models;
using NavigationViewMinimal.Avalonia.ViewModels.Dashboard;
using ReactiveUI;

namespace NavigationViewMinimal.Avalonia.ViewModels.TabPage;

public class HasNavigationViewModel : TabViewModelBase
{
    private ViewModelBase? _navigationCurrentViewModel;
    private NavigationCategory? _selectedCategory;

    public ObservableCollection<NavigationCategory> Categories { get; } = new()
    {
        new NavigationCategory()
        {
            Title = "Details",
        },
        new NavigationCategory()
        {
            Title = "Settings",
        }
    };

    public ViewModelBase? NavigationCurrentViewModel
    {
        get => _navigationCurrentViewModel;
        set => this.RaiseAndSetIfChanged(ref _navigationCurrentViewModel, value);
    }

    public NavigationCategory? SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedCategory, value);
            if (value != null)
            {
               SetCurrentPage(); 
            }
        }
    }

    public HasNavigationViewModel(string title)
    {
        Title = title;
    }

    private void SetCurrentPage()
    {
        switch (SelectedCategory?.Title)
        {
           case "Settings":
               NavigationCurrentViewModel = new SettingsViewModel();
               break;
           case "Details":
               NavigationCurrentViewModel = new DetailsViewModel();
               break;
        }
    }
}