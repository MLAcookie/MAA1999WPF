using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using M9AWPF.Model;

namespace M9AWPF.ViewModel;

public partial class M9AConfigViewModel : ObservableObject
{
    [ObservableProperty]
    private M9AConfig m9aConfig;

    [ObservableProperty]
    private ObservableCollection<M9ATaskViewModel> m9aTasks;

    #region StaticMethods

    public static M9AConfigViewModel NewConfig(string name)
    {
        M9AConfigViewModel ans = new() { M9aConfig = M9AConfigManager.NewConfig(name) };
        ans.M9aTasks = new();
        return ans;
    }

    public static M9AConfig ToM9AConfig(M9AConfigViewModel configViewModel)
    {
        foreach (var task in configViewModel.M9aTasks)
        {
            configViewModel.M9aConfig.Tasks.Add(M9ATaskViewModel.ToTask(task));
        }
        return configViewModel.M9aConfig;
    }

    public static M9AConfigViewModel ToM9AConfigVM(M9AConfig m9aConfig)
    {
        M9AConfigViewModel ans = new();
        ans.M9aConfig = m9aConfig;
        ans.M9aTasks = M9ATaskViewModel.ToTaskVMCollection(m9aConfig);
        return ans;
    }

    public static M9AConfigViewModel GetVMFromConfigName(string name)
    {
        M9AConfigViewModel ans = new();
        ans.M9aConfig = M9AConfigManager.NameToObject[name];
        ans.M9aTasks = M9ATaskViewModel.ToTaskVMCollection(ans.M9aConfig);
        return ans;
    }

    #endregion StaticMethods

    #region publicMethods

    public void AddTask(M9ATaskViewModel task)
    {
        M9aTasks.Add(task);
    }

    public void CleanTask()
    {
        M9aTasks.Clear();
    }

    public Task SaveConfig()
    {
        M9aConfig.Tasks.Clear();
        foreach (var task in M9aTasks)
        {
            M9aConfig.Tasks.Add(M9ATaskViewModel.ToTask(task));
        }
        //return Task.CompletedTask;
        return M9aConfig.SaveConfigAsync();
    }

    public void DeleteConfig()
    {
        M9AConfigManager.DeleteConfig(M9aConfig.ConfigName);
    }

    #endregion publicMethods
}