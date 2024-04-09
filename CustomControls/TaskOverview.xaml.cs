using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using M9AWPF.ViewModel;

namespace M9AWPF.CustomControls;

/// <summary>
/// TaskOverview.xaml 的交互逻辑
/// </summary>
public partial class TaskOverview : Border
{
    #region TaskSource_propdp
    public List<MAATaskViewModel> TaskSource
    {
        get { return (List<MAATaskViewModel>)GetValue(TaskSourceProperty); }
        set { SetValue(TaskSourceProperty, value); }
    }
    public static readonly DependencyProperty TaskSourceProperty = DependencyProperty.Register(
        "TaskSource",
        typeof(List<MAATaskViewModel>),
        typeof(TaskOverview),
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
            typeof(TaskOverview),
            new PropertyMetadata(true)
        );
    #endregion

    public TaskOverview()
    {
        InitializeComponent();
    }

    #region ClickEvents
    private void Delete_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var selectM9ATask = ((sender as MenuItem)!.DataContext as MAATaskViewModel)!;
        for (int i = 0; i < TaskSource.Count; i++)
        {
            if (TaskSource[i] == selectM9ATask)
            {
                TaskSource.RemoveAt(i);
                break;
            }
        }
        ItemsRefresh();
    }

    private void MoveDown_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var selectM9ATask = ((sender as MenuItem)!.DataContext as MAATaskViewModel)!;
        for (int i = 0; i < TaskSource.Count; i++)
        {
            if (TaskSource[i] == selectM9ATask)
            {
                if (i == TaskSource.Count - 1)
                    return;
                (TaskSource[i], TaskSource[i + 1]) = (TaskSource[i + 1], TaskSource[i]);
                break;
            }
        }
        ItemsRefresh();
    }

    private void MoveUp_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var selectM9ATask = ((sender as MenuItem)!.DataContext as MAATaskViewModel)!;
        for (int i = 0; i < TaskSource.Count; i++)
        {
            if (TaskSource[i] == selectM9ATask)
            {
                if (i == 0)
                    return;
                (TaskSource[i], TaskSource[i - 1]) = (TaskSource[i - 1], TaskSource[i]);
                break;
            }
        }
        ItemsRefresh();
    }
    #endregion

    public void ItemsRefresh()
    {
        TaskList_ItemControl.Items.Refresh();
    }
}
