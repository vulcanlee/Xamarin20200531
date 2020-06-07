using Xamarin.Forms;

namespace XFQR.Views
{
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        private void ZXingDefaultOverlay_FlashButtonClicked(object sender, System.EventArgs e)
        {
            ZXingScannerView.ToggleTorch();
        }
    }
}
