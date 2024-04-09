using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using HandyControl.Controls;
using HandyControl.Tools;
using HandyControl.Tools.Extension;
using M9AWPF.CustomControls;
using M9AWPF.ViewModel;

namespace M9AWPF.View;

/// <summary>
/// TaskEditView.xaml 的交互逻辑
/// </summary>
public partial class TaskEditView : UserControl
{
    TaskEditViewModel viewModel;
    public TaskEditView()
    {
        InitializeComponent();
        viewModel = (DataContext as TaskEditViewModel)!;
    }

    private void TaskTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TaskSettingPanel.Children.Clear();
        var str = (sender as System.Windows.Controls.ComboBox)!.SelectedValue.ToString()!;

        var options = TaskEditViewModel.TaskMap2Option[str];
        if (options.Count == 0)
            return;

        foreach (var option in options)
        {
            var opt = new OptionTemplate(option, TaskEditViewModel.OptionMap2Values[option]);
            TaskSettingPanel.Children.Add(opt);
        }
    }

    private void AddTaskButton_Click(object sender, RoutedEventArgs e)
    {

    }

    [DllImport("user32")]
    public static extern IntPtr SetFocus(IntPtr hWnd);

    private async void NewConfigButton_Click(object sender, RoutedEventArgs e)
    {
        await Task.Yield();
        NewConfigPopup.IsOpen = true;

        // 必须显式让 Popup 获得焦点，否则内部的 TextBox 输入时，IME 输入框无法跟随。
        await Task.Yield();
        var source = (HwndSource)PresentationSource.FromVisual(NewConfigPopup.Child);
        SetFocus(source.Handle);
    }
}
