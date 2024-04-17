using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using M9AWPF.ViewModel;

namespace M9AWPF.CustomControls;

/// <summary>
/// TimerOverview.xaml 的交互逻辑
/// </summary>
public partial class TimerOverview : Border
{
    #region TaskSource_propdp
    public List<TimerTaskViewModel> TaskSource
    {
        get { return (List<TimerTaskViewModel>)GetValue(TaskSourceProperty); }
        set { SetValue(TaskSourceProperty, value); }
    }
    public static readonly DependencyProperty TaskSourceProperty = DependencyProperty.Register(
        "TaskSource",
        typeof(List<TimerTaskViewModel>),
        typeof(TimerOverview),
        null
    );
    #endregion

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
    #endregion

    List<TimerTaskViewModel> testTasks =
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
    #endregion

    public void ItemsRefresh()
    {
        TaskList_ItemControl.Items.Clear();
    }
}
