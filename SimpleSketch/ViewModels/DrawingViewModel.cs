using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSketch.ViewModels
{
    public partial class DrawingViewModel : ViewModelBase
    {
        [ObservableProperty]
        private PropertiesViewModel? properties = new();
    }
}
