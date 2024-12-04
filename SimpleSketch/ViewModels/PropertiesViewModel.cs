using Avalonia.Layout;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel;

#pragma warning disable CS0657

namespace SimpleSketch.ViewModels;

public partial class PropertiesViewModel : ObservableObject
{
    [ObservableProperty]
    [property: Category("Position"), DisplayName("X")]
    private double? x = 0;

    [ObservableProperty]
    [property: Category("Position"), DisplayName("Y")]
    private double? y = 0;

    [ObservableProperty] 
    [property: Category("Measurements"), DisplayName("Width")]
    private double? width = 0;

    [ObservableProperty] 
    [property: Category("Measurements"), DisplayName("Height")]
    private double? height = 0;
}


#pragma warning enable CS0657
