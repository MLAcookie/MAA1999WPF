﻿using System.Collections.Generic;
using System.Linq;
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

    List<MAATaskViewModel> testTasks =
    [
        new MAATaskViewModel
        {
            Name = "Test1",
            Options = { "测试一", "测试二" },
            OptionVals = { "1", "2" },
        },
        new MAATaskViewModel
        {
            Name = "Test2",
            Options = { "测试一", "测试二" },
            OptionVals = { "1", "2" },
        }
    ];

    public List<MAATaskViewModel> TestTasks
    {
        get { return testTasks; }
    }

    public TaskOverview()
    {
        InitializeComponent();
    }

    private void Delete_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var boxedMAATask = ((sender as MenuItem)!.DataContext as MAATaskViewModel)!;
        var tasks = TaskEditViewModel.AllMAATasks.ToList();
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Name == boxedMAATask.Name)
            {
                tasks.RemoveAt(i);
                break;
            }
        }

        TaskEditViewModel.AllMAATasks = tasks;
        var itemsControl = (FindName("TaskList_ItemControl") as ItemsControl)!;
        itemsControl.ItemsSource = tasks;
    }

    /// <summary>
    /// 右键菜单下移某个item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MoveDown_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var boxedMAATask = ((sender as MenuItem)!.DataContext as MAATaskViewModel)!;
        var tasks = TaskEditViewModel.AllMAATasks.ToList();
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Name == boxedMAATask.Name)
            {
                if (i == tasks.Count - 1)
                    return;
                (tasks[i], tasks[i + 1]) = (tasks[i + 1], tasks[i]);
                break;
            }
        }

        TaskEditViewModel.AllMAATasks = tasks;
        var itemsControl = (FindName("TaskList_ItemControl") as ItemsControl)!;
        itemsControl.ItemsSource = tasks;
    }

    /// <summary>
    /// 右键菜单上移某个item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MoveUp_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var boxedMAATask = ((sender as MenuItem)!.DataContext as MAATaskViewModel)!;
        var tasks = TaskEditViewModel.AllMAATasks.ToList();
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Name == boxedMAATask.Name)
            {
                if (i == 0)
                    return;
                (tasks[i], tasks[i - 1]) = (tasks[i - 1], tasks[i]);
                break;
            }
        }

        TaskEditViewModel.AllMAATasks = tasks;
        var itemsControl = (FindName("TaskList_ItemControl") as ItemsControl)!;
        itemsControl.ItemsSource = tasks;
    }
}
