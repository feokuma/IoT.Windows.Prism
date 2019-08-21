using Windows.UI;

namespace IoT.Windows.Prism.Services
{
    public interface ILedMatrix
    {
        bool Write(int pixel, byte red, byte green, byte blue);
        bool Write(int pixel, Color color);
        bool Clean();
        void RefreshLeds();
    }
}
