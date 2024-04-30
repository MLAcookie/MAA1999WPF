using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M9AWPF.Constants;
using M9AWPF.Model;

namespace M9AWPF.ViewModel;

public partial class HomeViewModel : ObservableObject
{
    public HomeViewModel()
    {
        if (UIConfigManager.IsLastUseTimer)
        {
            IsUseTimer = true;
        }
        if (UIConfigManager.LastSelectConfig is not null)
        {
            SelectIndex = ConfigFiles.IndexOf(UIConfigManager.LastSelectConfig);
            CurrentConfig = M9AConfigViewModel.GetVMFromConfigName(UIConfigManager.LastSelectConfig);
        }
    }

    #region AutoProperties

    public string M9AVersion
    {
        get { return "M9A Version: "; }
    }

    public string UIVersion
    {
        get { return $"UI Verion: {ConfKeys.UIVersion}"; }
    }

    #endregion AutoProperties

    #region ObservableProperties

    [ObservableProperty]
    private List<string> configFiles = M9AConfigManager.ConfigNames;

    [ObservableProperty]
    private M9AConfigViewModel currentConfig;

    [ObservableProperty]
    private int selectIndex = -1;

    partial void OnSelectIndexChanged(int value)
    {
        CurrentConfig = M9AConfigViewModel.GetVMFromConfigName(ConfigFiles[value]);
    }

    [ObservableProperty]
    private bool isUseTimer = false;

    #endregion ObservableProperties

    #region Commands

    [RelayCommand]
    public void StartM9A()
    {
        ConsoleBehavior.Instance.Start();
    }

    #endregion Commands
}