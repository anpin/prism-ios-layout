using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ios_layout;

public record CmdArgs(Picker btn);

public interface IShellModel
{
    IRelayCommand<CmdArgs> PickCityCommand { get; } 
}
internal partial class ShellModel : IShellModel
{
    int count = 0;
    
    [RelayCommand]
    private  void PickCity(CmdArgs args)
    {
        args.btn.Title = $"A city was picked {++count} times";
    }
}

public interface IIPageModel : IPageLifecycleAware
{
    string Name { get; }
    ObservableCollection<string> Items { get;  }
    string SelectedItem { get;  }
    IAsyncRelayCommand RefreshCommand { get; }
}
[ObservableObject]
internal partial class PageModel : IIPageModel
{
    public string Name =>
#if __NO_PRISM__
        "MAUI navigation page";
#else 
        "PRISM naviagtion page";
#endif 
    private const string none = "Pick a city";
    public ObservableCollection<string> Items { get; } = new ();
    async Task Setitems()
    {
        foreach( var item in new [] {  "Cape Town", "Dakar", "Marrakesh", "Alexandria", "Addis Ababa" })
        {
            await Task.Delay(Random.Shared.Next(500, 2000));
            Items.Add(item);
        }
    }
    [ObservableProperty]
    string selectedItem  = none;

    public void OnAppearing() => 
        RefreshCommand.Execute(default);
    

    public void OnDisappearing()
    {
        Items.Clear();
    }
    [RelayCommand]
    public async Task Refresh()
    {
        Items.Clear();
        await Setitems();
    }
}