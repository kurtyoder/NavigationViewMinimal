using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using NavigationViewMinimal.Avalonia.ViewModels.Dashboard;

namespace NavigationViewMinimal.Avalonia.Views.Dashboard;

public partial class DetailsView : ReactiveUserControl<DetailsViewModel>
{
    public DetailsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}