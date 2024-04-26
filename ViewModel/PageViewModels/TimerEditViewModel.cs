using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M9AWPF.Model;
using System.Collections.Generic;

namespace M9AWPF.ViewModel;

public partial class TimerEditViewModel : ObservableObject
{
    public static List<string> ConfigFiles
    {
        get { return M9AConfigManager.ConfigNames; }
    }

    #region ObservableProperties

    [ObservableProperty]
    private int selectIndex = -1;

    [ObservableProperty]
    private string timeText = "";

    [ObservableProperty]
    TimerViewModel currentTimer;

    #endregion ObservableProperties

    #region Commands

    [RelayCommand]
    void AddTimerTask()
    {
    }

    #endregion Commands
}