using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace NavigationViewMinimal.Avalonia.ViewModels;

public class TabViewModelBase : ViewModelBase, IActivatableViewModel
{
    public string Title { get; set; } = "No Title Given";
    
    private ReactiveCommand<Unit, Unit> LoadTabDataCommand { get; }

    public TabViewModelBase()
    {
        LoadTabDataCommand = ReactiveCommand.CreateFromTask(LoadTabData);

        this.WhenActivated((CompositeDisposable disposables) =>
        {
            LoadTabDataCommand.Execute().ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe().DisposeWith(disposables);
        });
    }

    public virtual Task LoadTabData()
    {
        return Task.CompletedTask;
    }

    public ViewModelActivator Activator { get; } = new();
}