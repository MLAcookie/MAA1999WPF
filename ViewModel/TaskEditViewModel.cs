using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M9AWPF.JsonSerializeObject;
using M9AWPF.Model;

namespace M9AWPF.ViewModel;

public partial class TaskEditViewModel : ObservableObject
{
    M9AConfig currentConfig;

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

    #region ObservableProperties
    [ObservableProperty]
    static List<string> allTaskTypes = ConfigInterface
        .TaskTypes.Select((m9aTask) => m9aTask.name)
        .ToList();

    [ObservableProperty]
    static List<string> configFiles = new();

    [ObservableProperty]
    int configFileIndex;

    [ObservableProperty]
    List<M9ATaskViewModel> m9aTasks = new();
    #endregion

    public void NewConfig(string newConfigName)
    {
        if (newConfigName == "")
        {
            return;
        }
        if (currentConfig is not null)
        {
            SaveCurrentConfig();
        }
        M9AConfig temp = M9AConfigManager.NewConfig(newConfigName);
        ConfigFiles.Add(temp.ConfigName);
        M9aTasks.Clear();
        ConfigFileIndex = ConfigFiles.Count - 1;
        currentConfig = temp;
    }

    public void AddTask(string TypeName, List<string>? options = null, List<string>? values = null)
    {
        if (currentConfig is null)
        {
            return;
        }
        M9ATaskViewModel task = new() { Name = TypeName };
        if (options is not null)
        {
            task.Options = options;
            task.OptionVals = values;
        }
        M9aTasks.Add(task);
    }

    #region Commands
    [RelayCommand]
    void DeleteConfig(int index)
    {
        string temp = ConfigFiles[index];
        configFiles.RemoveAt(index);
        M9AConfigManager.DeleteConfig(temp);
    }
    #endregion

    public async void SaveCurrentConfig()
    {
        currentConfig.Tasks.Clear();
        foreach (var task in M9aTasks)
        {
            currentConfig.Tasks.Add(M9ATaskViewModel.ConvertToTask(task));
        }
        await currentConfig.SaveConfig();
    }
}
