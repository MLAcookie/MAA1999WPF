using System.Windows;

namespace M9AWPF.CustomControls;

public class BindingBoolProxy : Freezable
{
    protected override Freezable CreateInstanceCore()
    {
        return new BindingBoolProxy();
    }

    public bool Data
    {
        get { return (bool)GetValue(DataProperty); }
        set { SetValue(DataProperty, value); }
    }

    public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
        "Data",
        typeof(bool),
        typeof(BindingBoolProxy),
        new PropertyMetadata(false)
    );
}
