using Avalonia.Controls;
using SukiUI.Controls;
using SukiUI.Dialogs;
using System;
using System.Diagnostics;

namespace SimpleSketch.Views
{
    public partial class MainWindow : SukiWindow
    {
        public static ISukiDialogManager DialogManager = new SukiDialogManager();

        public MainWindow()
        {
            InitializeComponent();
            DialogHost.Manager = DialogManager;
        }

        private void ShowAboutDialog(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DialogManager.CreateDialog()
                .WithTitle(Assets.Resources.About)
                .WithContent("SimpleSketch ver 0.0.1 by nevelate")
                .Dismiss().ByClickingBackground()
                .TryShow();

        }

        private void ShowKeyboardShortcutsDialog(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DialogManager.CreateDialog()
                .WithContent(new ShortcutsView())
                .Dismiss().ByClickingBackground()
                .TryShow();
        }

        private void ShowContacts(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DialogManager.CreateDialog()
                .WithContent(new ContactsView())
                .Dismiss().ByClickingBackground()
                .TryShow();
        }

        private void ShowRestartDialog(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;

            var culture = menuItem.Header switch
            {
                "English" => "en-us",
                "Русский" => "ru-RU",
                "O'zbekcha" => "uz-Latn-UZ",
                _ => "en-us"
            };

            DialogManager.CreateDialog()
                .OfType(Avalonia.Controls.Notifications.NotificationType.Information)
                .WithTitle("Restart?")
                .WithContent("To change app language need to restart app. Restart now?")
                .WithActionButton("Yes", _ => Restart(culture), true)
                .WithActionButton("Cancel", _ => { }, true)
                .TryShow();
        }

        private void Restart(string arguments)
        {
            Process.Start(Process.GetCurrentProcess().MainModule.FileName, arguments);
            Environment.Exit(0);
        }

        private void Exit(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Close();
        }
    }
}