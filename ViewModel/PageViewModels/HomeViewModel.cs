using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M9AWPF.Model;

namespace M9AWPF.ViewModel;

public partial class HomeViewModel : ObservableObject
{
    private M9AConfig currentConfig;

    #region Properties

    private int configIndex = -1;

    public int ConfigIndex
    {
        get { return configIndex; }
        set
        {
            configIndex = value;
            currentConfig = M9AConfigManager.NameToObject[Configs[value]];
            ConfigTasks = M9ATaskViewModel.ToTaskVMCollection(currentConfig);
            M9AConfigManager.IsConfigChanged[Configs[value]] = true;
        }
    }

    #endregion Properties

    #region AutoProperties

    public string M9AVersion
    {
        get { return "M9A Version: "; }
    }

    public string UIVersion
    {
        get { return "UI Verion: "; }
    }

    #endregion AutoProperties

    #region ObservableProperties

    [ObservableProperty]
    private List<string> configs = M9AConfigManager.ConfigNames;

    [ObservableProperty]
    private ObservableCollection<M9ATaskViewModel> configTasks;

    #endregion ObservableProperties

    public HomeViewModel()
    { }

    [RelayCommand]
    public void StartM9A()
    {
        ConsoleBehavior.Instance.Start();
    }
}