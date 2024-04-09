using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M9AWPF.CustomControls;

/// <summary>
/// 提供一个带标签的Combobox的模板
/// </summary>
public partial class OptionTemplate : ComboBox, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    string optionName = "";
    List<string> optionValues = new();

    public string OptionName
    {
        get { return optionName; }
        set
        {
            optionName = value;
            OnPropertyChanged();
        }
    }
    public List<string> OptionValues
    {
        get { return optionValues; }
        set
        {
            optionValues = value;
            OnPropertyChanged();
        }
    }

    public OptionTemplate(string optionName, List<string> optionValues)
    {
        InitializeComponent();
        OptionName = optionName;
        OptionValues = optionValues;
    }
}
