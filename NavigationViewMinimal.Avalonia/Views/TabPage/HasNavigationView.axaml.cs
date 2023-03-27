using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NavigationViewMinimal.Avalonia.Views.TabPage;

public partial class HasNavigationView : UserControl
{
    public HasNavigationView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}