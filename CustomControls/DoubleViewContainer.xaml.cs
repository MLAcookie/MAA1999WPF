using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;

namespace M9AWPF.CustomControls;

public partial class DoubleViewContainer : UserControl
{
    #region ViewTrue_propdp
    public UserControl ViewTrue
    {
        get { return (UserControl)GetValue(ViewTrueProperty); }
        set { SetValue(ViewTrueProperty, value); }
    }

    public static readonly DependencyProperty ViewTrueProperty = DependencyProperty.Register(
        "ViewTrue",
        typeof(UserControl),
        typeof(DoubleViewContainer),
        null
    );
    #endregion

    #region ViewFalse_propdp
    public UserControl ViewFalse
    {
        get { return (UserControl)GetValue(ViewFalseProperty); }
        set { SetValue(ViewFalseProperty, value); }
    }

    public static readonly DependencyProperty ViewFalseProperty = DependencyProperty.Register(
        "ViewFalse",
        typeof(UserControl),
        typeof(DoubleViewContainer),
        null
    );
    #endregion

    #region IsViewTrue_propdp
    public bool? IsViewTrue
    {
        get { return (bool?)GetValue(IsViewTrueProperty); }
        set
        {
            SetValue(IsViewTrueProperty, value);
        }
    }

    public static readonly DependencyProperty IsViewTrueProperty = DependencyProperty.Register(
        "IsViewTrue",
        typeof(bool?),
        typeof(DoubleViewContainer),
        null
    );
    #endregion

    public DoubleViewContainer()
    {
        InitializeComponent();
    }
}
