using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M9AWPF.JsonSerializeObject;
using M9AWPF.Model;

namespace M9AWPF.ViewModel;

/// <summary>
/// 封装的MAA Task
/// </summary>
public class M9ATaskViewModel
{
    public static M9AConfigObject.Task ConvertToTask(M9ATaskViewModel viewModel)
    {
        M9AConfigObject.Task task = new();
        for (int i = 0; i < viewModel.Options.Count; i++)
        {
            task.option.Add(new() { name = viewModel.Options[i], value = viewModel.OptionVals[i] });
        }
        return task;
    }

    public static M9ATaskViewModel ConvertToViewModel(M9AConfigObject.Task task)
    {
        M9ATaskViewModel res = new() { Name = task.name };
        foreach (var item in task.option)
        {
            res.Options.Add(item.name);
            res.OptionVals.Add(item.value);
        }
        return res;
    }

    public static List<M9ATaskViewModel> GetTaskVMFromConfig(M9AConfig config)
    {
        List<M9ATaskViewModel> ans = new();
        foreach (var item in config.Tasks)
        {
            ans.Add(ConvertToViewModel(item));
        }
        return ans;
    }

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
}
