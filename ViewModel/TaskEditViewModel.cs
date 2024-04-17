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

    #region Commands
    [RelayCommand]
    void NewConfig(string newConfigName) { }

    [RelayCommand]
    void DeleteConfig(int index) { }
    #endregion


}
