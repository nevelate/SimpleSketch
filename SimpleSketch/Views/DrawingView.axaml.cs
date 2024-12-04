using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SimpleSketch.ViewModels;

namespace SimpleSketch.Views;

public partial class DrawingView : UserControl
{
    public DrawingView()
    {
        InitializeComponent();

        DataContext = new DrawingViewModel();
    }
}