using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M9AWPF.Model;

namespace M9AWPF.ViewModel;

public partial class TaskEditViewModel : ObservableObject
{
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

    #region ObservableProperties

    [ObservableProperty]
    private static List<string> allTaskTypes = ConfigInterface
        .TaskTypes.Select((m9aTask) => m9aTask.name)
        .ToList();

    [ObservableProperty]
    private static ObservableCollection<string> configFiles = new(M9AConfigManager.ConfigNames);

    [ObservableProperty]
    private int configFileIndex = -1;

    partial void OnConfigFileIndexChanged(int value)
    {
        CurrentConfig?.SaveConfig();
        CurrentConfig = M9AConfigViewModel.GetVMFromConfigName(ConfigFiles[value]);
    }

    [ObservableProperty]
    private M9AConfigViewModel? currentConfig;

    #endregion ObservableProperties

    #region PublicMethods

    public void AddTask(string TypeName, List<string>? options = null, List<string>? values = null)
    {
        if (CurrentConfig is null || TypeName == "")
        {
            return;
        }
        M9ATaskViewModel task = new() { Name = TypeName };
        if (options is not null)
        {
            task.Options = options;
            task.OptionVals = values;
        }
        CurrentConfig.AddTask(task);
    }

    #endregion PublicMethods

    #region Commands

    [RelayCommand]
    public void NewConfig(string newConfigName)
    {
        if (newConfigName == "")
        {
            return;
        }
        CurrentConfig?.SaveConfig();
        M9AConfigViewModel temp = M9AConfigViewModel.NewConfig(newConfigName);
        ConfigFiles.Add(temp.M9aConfig.ConfigName);
        ConfigFileIndex = ConfigFiles.Count - 1;
        CurrentConfig = temp;
    }

    [RelayCommand]
    private void DeleteConfig(int index)
    {
        if (index >= 0)
        {
            CurrentConfig?.DeleteConfig();
            ConfigFiles.RemoveAt(index);
        }
    }

    #endregion Commands
}