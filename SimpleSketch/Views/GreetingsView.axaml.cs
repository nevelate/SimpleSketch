using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;

namespace SimpleSketch.Views;

public partial class GreetingsView : UserControl
{
    public GreetingsView()
    {
        InitializeComponent();
    }

    private void OpenFile(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var storage = TopLevel.GetTopLevel(this).StorageProvider;
        var files = storage.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions()
        {
            AllowMultiple = false,
            Title = "Open existing project",
        });
    }
}