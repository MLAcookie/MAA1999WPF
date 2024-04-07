using System.Linq;
using System.Windows;
using System.Windows.Controls;
using M9AWPF.CustomControls;
using M9AWPF.ViewModel;

namespace M9AWPF.View;

/// <summary>
/// TaskEditView.xaml 的交互逻辑
/// </summary>
public partial class TaskEditView : UserControl
{
    public TaskEditView()
    {
        InitializeComponent();
    }

    private void TaskTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TaskSettingPanel.Children.Clear();
        var str = (sender as ComboBox)!.SelectedValue.ToString()!;

        var options = TaskEditViewModel.TaskMap2Option[str];
        if (options.Count == 0)
            return;

        foreach (var option in options)
        {
            var opt = new OptionTemplate(option, TaskEditViewModel.OptionMap2Values[option]);
            TaskSettingPanel.Children.Add(opt);
        }
    }
}
