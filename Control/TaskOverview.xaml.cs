using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using M9AWPF.ViewModel;

namespace M9AWPF.Control;

/// <summary>
/// TaskOverview.xaml 的交互逻辑
/// </summary>
public partial class TaskOverview : Border
{
    List<BoxedMAATask> testTasks =
        [
            new BoxedMAATask
            {
                Name = "Test1",
                Options = { "测试一", "测试二" },
                OptionVals = { "1", "2" },
            },
            new BoxedMAATask
            {
                Name = "Test2",
                Options = { "测试一", "测试二" },
                OptionVals = { "1", "2" },
            }
        ];
    public List<BoxedMAATask> TestTasks
    {
        get { return testTasks; }
    }

    public List<BoxedMAATask> TaskSource
    {
        get { return (List<BoxedMAATask>)GetValue(TaskSourceProperty); }
        set { SetValue(TaskSourceProperty, value); }
    }
    public static readonly DependencyProperty TaskSourceProperty = DependencyProperty.Register(
        "TaskSource",
        typeof(List<BoxedMAATask>),
        typeof(TaskOverview),
        null
    );

    public TaskOverview()
    {
        InitializeComponent();
    }

    private void Delete_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var boxedMAATask = ((sender as MenuItem)!.DataContext as BoxedMAATask)!;
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
        var boxedMAATask = ((sender as MenuItem)!.DataContext as BoxedMAATask)!;
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
        var boxedMAATask = ((sender as MenuItem)!.DataContext as BoxedMAATask)!;
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
