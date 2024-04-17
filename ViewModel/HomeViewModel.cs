using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M9AWPF.Model;

namespace M9AWPF.ViewModel;

public partial class HomeViewModel : ObservableObject
{
    M9AConfig currentConfig;

    #region Properties
    int configIndex = -1;
    public int ConfigIndex
    {
        get { return configIndex; }
        set
        {
            configIndex = value;
            currentConfig = M9AConfigManager.NameToObject[Configs[value]];
            ConfigTasks = M9ATaskViewModel.GetTaskVMFromConfig(currentConfig);
            M9AConfigManager.IsConfigChanged[Configs[value]] = true;
        }
    }
    #endregion

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
    List<string> configs = M9AConfigManager.ConfigNames;

    [ObservableProperty]
    List<M9ATaskViewModel> configTasks;
    #endregion

    public HomeViewModel() { }

    [RelayCommand]
    public void StartM9A()
    {
        ConsoleBehavior.Instance.Start();
    }
}
