using System.Windows;
using System.Windows.Controls;
using M9AWPF.ViewModel;

namespace M9AWPF.CustomControls;

/// <summary>
/// TaskOverview.xaml 的交互逻辑
/// </summary>
public partial class TaskOverview : Border
{
    #region CurrentM9AConfig_propdp

    public static readonly DependencyProperty CurrentM9AConfigProperty = DependencyProperty.Register(
        "CurrentM9AConfig",
        typeof(M9AConfigViewModel),
        typeof(TaskOverview),
        null
    );

    public M9AConfigViewModel CurrentM9AConfig
    {
        get { return (M9AConfigViewModel)GetValue(CurrentM9AConfigProperty); }
        set
        {
            SetValue(CurrentM9AConfigProperty, value);
        }
    }

    #endregion CurrentM9AConfig_propdp

    #region IsEnableContextMenu_propdp

    public static readonly DependencyProperty IsEnableContextMenuProperty =
        DependencyProperty.Register(
            "IsEnableContextMenu",
            typeof(bool),
            typeof(TaskOverview),
            new PropertyMetadata(true)
        );

    public bool IsEnableContextMenu
    {
        get { return (bool)GetValue(IsEnableContextMenuProperty); }
        set { SetValue(IsEnableContextMenuProperty, value); }
    }

    #endregion IsEnableContextMenu_propdp

    public TaskOverview()
    {
        InitializeComponent();
    }

    #region ClickEvents

    private void Delete_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var selectM9ATask = ((sender as MenuItem)!.DataContext as M9ATaskViewModel)!;
        for (int i = 0; i < CurrentM9AConfig.M9aTasks.Count; i++)
        {
            if (CurrentM9AConfig.M9aTasks[i] == selectM9ATask)
            {
                CurrentM9AConfig.M9aTasks.RemoveAt(i);
                break;
            }
        }
        ItemsRefresh();
    }

    private void MoveDown_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var selectM9ATask = ((sender as MenuItem)!.DataContext as M9ATaskViewModel)!;
        for (int i = 0; i < CurrentM9AConfig.M9aTasks.Count; i++)
        {
            if (CurrentM9AConfig.M9aTasks[i] == selectM9ATask)
            {
                if (i == CurrentM9AConfig.M9aTasks.Count - 1)
                    return;
                (CurrentM9AConfig.M9aTasks[i], CurrentM9AConfig.M9aTasks[i + 1]) = (CurrentM9AConfig.M9aTasks[i + 1], CurrentM9AConfig.M9aTasks[i]);
                break;
            }
        }
        ItemsRefresh();
    }

    private void MoveUp_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var selectM9ATask = ((sender as MenuItem)!.DataContext as M9ATaskViewModel)!;
        for (int i = 0; i < CurrentM9AConfig.M9aTasks.Count; i++)
        {
            if (CurrentM9AConfig.M9aTasks[i] == selectM9ATask)
            {
                if (i == 0)
                    return;
                (CurrentM9AConfig.M9aTasks[i], CurrentM9AConfig.M9aTasks[i - 1]) = (CurrentM9AConfig.M9aTasks[i - 1], CurrentM9AConfig.M9aTasks[i]);
                break;
            }
        }
        ItemsRefresh();
    }

    #endregion ClickEvents

    #region PublicMethods

    public void SaveItems() => CurrentM9AConfig.SaveConfig();

    public void ItemsRefresh() => TaskList_ItemControl.Items.Refresh();

    #endregion PublicMethods
}