using System;

using IoT.Windows.Prism.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using IoT.Windows.Prism.Services;
using System.Threading;

namespace IoT.Windows.Prism.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
