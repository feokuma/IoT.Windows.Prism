using IoT.Windows.Prism.Services;
using Prism.Windows.Mvvm;
using System;
using System.IO;
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
            StartLedMatrix();
            //StartMatrixCommand = new DelegateCommand(StartLedMatrix());
        }

        private async Task StartLedMatrix()
        {
            //return async () =>
            {
                var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/StoreLogo.png"));

                var inputStream = await file.OpenSequentialReadAsync();

                var binaryReader = new BinaryReader(inputStream.AsStreamForRead());

                var buffer = new byte[14];
                binaryReader.Read(buffer, 0, 14);
                
                var ledMatrix = new LedMatrix();
                await ledMatrix.InitializeAsync(64);
                //ledMatrix.Clean();
                //ledMatrix.Write(0, 100, 00, 0);
                //ledMatrix.Write(8, 0, 100, 0);
                //ledMatrix.Write(16, 0, 0, 100);
                //ledMatrix.RefreshLeds();
                Random random = new Random();
                while (true)
                {
                    ledMatrix.Clean();
                    ledMatrix.Write(random.Next(0, 63), (byte)random.Next(0, 50), (byte)random.Next(0, 50), (byte)random.Next(0, 50));
                    ledMatrix.Write(random.Next(0, 63), (byte)random.Next(0, 50), (byte)random.Next(0, 50), (byte)random.Next(0, 50));
                    ledMatrix.Write(random.Next(0, 63), (byte)random.Next(0, 50), (byte)random.Next(0, 50), (byte)random.Next(0, 50));
                    ledMatrix.Write(random.Next(0, 63), (byte)random.Next(0, 50), (byte)random.Next(0, 50), (byte)random.Next(0, 50));
                    ledMatrix.RefreshLeds();
                    Thread.Sleep(1);
                }
            }
        }
    }
}
