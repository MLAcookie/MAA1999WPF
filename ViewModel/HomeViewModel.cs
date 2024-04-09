using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace M9AWPF.ViewModel;

public partial class HomeViewModel : ObservableObject
{
    #region AutoProperties
    public string M9AVersion
    {
        get { return "M9A Version: "; }
    }
    public string UIVersion
    {
        get { return "UI Verion: "; }
    }
    #endregion

    #region ObservableProperties
    [ObservableProperty]
    List<string> configs;

    [ObservableProperty]
    List<string> configTasks;
    #endregion

    [RelayCommand]
    public void StartM9A(int index) { }
}
