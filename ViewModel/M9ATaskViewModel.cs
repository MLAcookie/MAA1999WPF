using System.Collections.Generic;
using System.Collections.ObjectModel;
using M9AWPF.JsonSerializeObject;
using M9AWPF.Model;

namespace M9AWPF.ViewModel;

/// <summary>
/// 封装的MAA Task
/// </summary>
public class M9ATaskViewModel
{
    /// <summary>
    /// 任务名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 任务选项
    /// </summary>
    public List<string> Options { get; set; } = new();

    /// <summary>
    /// 任务选项对应的值
    /// </summary>
    public List<string> OptionVals { get; set; } = new();

    public static M9ATaskViewModel FromMAATask(M9AConfigObject.Task task)
    {
        var res = new M9ATaskViewModel { Name = task.name };
        foreach (var item in task.option)
        {
            res.Options.Add(item.name);
            res.OptionVals.Add(item.value);
        }
        return res;
    }

    public static M9AConfigObject.Task ToTask(M9ATaskViewModel viewModel)
    {
        M9AConfigObject.Task task = new()
        {
            name = viewModel.Name
        };
        for (int i = 0; i < viewModel.Options.Count; i++)
        {
            task.option.Add(new() { name = viewModel.Options[i], value = viewModel.OptionVals[i] });
        }
        return task;
    }

    public static ObservableCollection<M9ATaskViewModel> ToTaskVMCollection(M9AConfig config)
    {
        ObservableCollection<M9ATaskViewModel> ans = new();
        foreach (var item in config.Tasks)
        {
            ans.Add(ToViewModel(item));
        }
        return ans;
    }

    public static M9ATaskViewModel ToViewModel(M9AConfigObject.Task task)
    {
        M9ATaskViewModel ans = new() { Name = task.name };
        foreach (var item in task.option)
        {
            ans.Options.Add(item.name);
            ans.OptionVals.Add(item.value);
        }
        return ans;
    }

    public M9AConfigObject.Task ToMAATask()
    {
        var res = new M9AConfigObject.Task { name = Name };
        for (int i = 0; i < Options.Count; i++)
        {
            var option = new M9AConfigObject.Option() { name = Options[i], value = OptionVals[i], };
            res.option.Add(option);
        }
        return res;
    }
}