﻿using System.Collections.Generic;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M9AWPF.View;

namespace M9AWPF.ViewModel;

public partial class NavigationViewModel : ObservableObject
{
    static Dictionary<string, UserControl> UCTable =
        new()
        {
            { "Home", new HomeView() },
            { "TaskEdit", new TaskEditView() },
            { "Timer", new TimerEditView() },
            { "Setting", new SettingView() },
        };

    [ObservableProperty]
    UserControl currentPage = UCTable["Home"];

    [RelayCommand]
    void ChangePage(string pageName)
    {
        CurrentPage = UCTable[pageName];
    }
}
