using Avalonia.Controls;
using Avalonia.Interactivity;
using SimpleSketch.ViewModels;
using SukiUI.Controls;
using SukiUI.Dialogs;
using SukiUI.Models;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

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

        private void ShowCreditsDialog(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DialogManager.CreateDialog()
                .WithContent(new CreditsView())
                .Dismiss().ByClickingBackground()
                .TryShow();
        }        

        private void ThemeMenuItem_OnClick(object? sender, RoutedEventArgs e)
        {
            if (DataContext is not MainWindowViewModel vm) return;
            if (e.Source is not MenuItem mItem) return;
            if (mItem.DataContext is not SukiColorTheme cTheme) return;
            vm.ChangeTheme(cTheme);
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