using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SukiUI;
using SukiUI.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SimpleSketch.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public IAvaloniaReadOnlyList<SukiColorTheme> Themes { get; }

        private readonly SukiTheme _theme;

        public MainWindowViewModel()
        {
            _theme = SukiTheme.GetInstance();
            Themes = _theme.ColorThemes;
        }

        [RelayCommand]
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        [RelayCommand]
        private void ToggleBaseTheme() => _theme.SwitchBaseTheme();

        public void ChangeTheme(SukiColorTheme theme) => _theme.ChangeColorTheme(theme);
    }
}
