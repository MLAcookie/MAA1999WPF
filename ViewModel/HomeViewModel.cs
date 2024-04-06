using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;

namespace M9AWPF.ViewModel;
public partial class HomeViewModel:ObservableObject
{

    public string M9AVersion
    {
        get
        {
            return "M9A Version: ";
        }
    }
    public string UIVersion
    {
        get
        {
            return "UI Verion: ";
        }
    }

    [ObservableProperty]
    List<string> configs;

    [RelayCommand]
    public void StartM9A(int index)
    {

    }
}
