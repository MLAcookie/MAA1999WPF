using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using M9AWPF.JsonSerializeObject;
using M9AWPF.Model;

namespace M9AWPF.ViewModel;

public partial class TaskEditViewModel : ObservableObject
{
    public static Dictionary<string, List<string>> TaskMap2Option
    {
        get
        {
            var res = new Dictionary<string, List<string>>();
            foreach (var item in ConfigInterface.TaskTypes)
            {
                var li = new List<string>();
                foreach (var t in item.option)
                {
                    li.Add(t);
                }
                res.Add(item.name, li);
            }
            return res;
        }
    }
    public static Dictionary<string, List<string>> OptionMap2Values
    {
        get
        {
            var res = new Dictionary<string, List<string>>();
            foreach (var item in ConfigInterface.option)
            {
                res.Add(item.Key, item.Value);
            }
            return res;
        }
    }

    public static List<BoxedMAATask> AllMAATasks
    {
        get
        {
            var res = new List<BoxedMAATask>();
            foreach (var item in ConfigManager.AllMAATasks)
            {
                var boxedMAATask = BoxedMAATask.FromMAATask(item);
                res.Add(boxedMAATask);
            }
            return res;
        }
        set
        {
            var res = new List<M9AConfigObject.Task>();
            foreach (var item in value)
            {
                res.Add(item.ToMAATask());
            }
            ConfigManager.AllMAATasks = res.ToArray();
        }
    }

    [ObservableProperty]
    static List<string> allTaskTypes = ConfigInterface
        .TaskTypes.Select((m9aTask) => m9aTask.name)
        .ToList();

}
