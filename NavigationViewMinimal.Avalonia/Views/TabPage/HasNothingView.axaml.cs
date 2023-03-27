using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NavigationViewMinimal.Avalonia.Views.TabPage;

public partial class HasNothingView : UserControl
{
    public HasNothingView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}