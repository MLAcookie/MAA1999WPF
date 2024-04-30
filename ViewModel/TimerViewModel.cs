using CommunityToolkit.Mvvm.ComponentModel;
using M9AWPF.JsonSerializeObject;
using System.Collections.ObjectModel;

namespace M9AWPF.ViewModel;

public partial class TimerViewModel : ObservableObject
{
    [ObservableProperty]
    private TaskTimerObject taskTimer;

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