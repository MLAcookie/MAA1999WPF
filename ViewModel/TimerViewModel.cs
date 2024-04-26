using CommunityToolkit.Mvvm.ComponentModel;
using M9AWPF.Model;
using System.Collections.ObjectModel;

namespace M9AWPF.ViewModel;

public partial class TimerViewModel : ObservableObject
{
    [ObservableProperty]
    private TaskTimer taskTimer;

    [ObservableProperty]
    private ObservableCollection<TimerViewModel> tasks;

    #region PublicMethods

    public void SaveTask()
    {

    }
    public void AddTimerTask()
    {
    }

    #endregion PublicMethods
}