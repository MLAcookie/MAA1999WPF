using M9AWPF.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace M9AWPF.CustomControls;

/// <summary>
/// TimerOverview.xaml 的交互逻辑
/// </summary>
public partial class TimerOverview : Border
{
    #region CurrentTimer_propdp

    public TimerViewModel CurrentTimer
    {
        get { return (TimerViewModel)GetValue(CurrentTimerProperty); }
        set { SetValue(CurrentTimerProperty, value); }
    }

    public static readonly DependencyProperty CurrentTimerProperty = DependencyProperty.Register(
        "CurrentTimer",
        typeof(TimerViewModel),
        typeof(TimerOverview),
        null
    );

    #endregion CurrentTimer_propdp

    #region TaskSource_propdp

    public Collection<TimerTaskViewModel> TaskSource
    {
        get { return (Collection<TimerTaskViewModel>)GetValue(TaskSourceProperty); }
        set { SetValue(TaskSourceProperty, value); }
    }

    public static readonly DependencyProperty TaskSourceProperty = DependencyProperty.Register(
        "TaskSource",
        typeof(Collection<TimerTaskViewModel>),
        typeof(TimerOverview),
        null
    );

    #endregion TaskSource_propdp

    #region IsEnableContextMenu_propdp

    public bool IsEnableContextMenu
    {
        get { return (bool)GetValue(IsEnableContextMenuProperty); }
        set { SetValue(IsEnableContextMenuProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsEnableContextMenu.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsEnableContextMenuProperty =
        DependencyProperty.Register(
            "IsEnableContextMenu",
            typeof(bool),
            typeof(TimerOverview),
            new PropertyMetadata(true)
        );

    #endregion IsEnableContextMenu_propdp

    private List<TimerTaskViewModel> testTasks =
    [
        new TimerTaskViewModel { Time = "09:10", File = "Test1.json" },
        new TimerTaskViewModel { Time = "09:20", File = "Test2.json" }
    ];

    public List<TimerTaskViewModel> TestTasks
    {
        get { return testTasks; }
    }

    public TimerOverview()
    {
        InitializeComponent();
    }

    #region ClickEvents

    private void Delete_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var selectTimerTask = ((sender as MenuItem)!.DataContext as TimerTaskViewModel)!;
        for (int i = 0; i < TaskSource.Count; i++)
        {
            if (TaskSource[i] == selectTimerTask)
            {
                TaskSource.RemoveAt(i);
                break;
            }
        }
        ItemsRefresh();
    }

    #endregion ClickEvents

    public void ItemsRefresh()
    {
        TaskList_ItemControl.Items.Clear();
    }
}