using IoT.Windows.Prism.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;

namespace IoT.Windows.Prism.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand StartMatrixCommand { get; set; }

        public MainViewModel()
        {
            StartMatrixCommand = new DelegateCommand(StartLedMatrix());
        }

        private Action StartLedMatrix()
        {
            return async () =>
            {
                var gif = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/jake.gif"));

                var ledMatrix = new LedMatrix();
                await ledMatrix.InitializeAsync(64);
                Random random = new Random();
                while (true)
                {
                    ledMatrix.Write(random.Next(0, 63), (byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
                    ledMatrix.Write(random.Next(0, 63), (byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
                    ledMatrix.Write(random.Next(0, 63), (byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
                    ledMatrix.Write(random.Next(0, 63), (byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
                    ledMatrix.RefreshLeds();
                    Thread.Sleep(1);
                }
            };
        }
    }
}
