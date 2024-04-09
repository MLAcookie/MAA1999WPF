using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9AWPF.ViewModel;
public partial class SettingViewModel : ObservableObject
{
    #region ObservableProperties
    [ObservableProperty]
    string adbPath = string.Empty;

    [ObservableProperty]
    string adbPort = string.Empty;

    [ObservableProperty]
    List<string> allClientTypes = ["official", "bilibili"];

    [ObservableProperty]
    int clientTypeIndex = 0;

    [ObservableProperty]
    string httpProxy = string.Empty;
    #endregion
}
