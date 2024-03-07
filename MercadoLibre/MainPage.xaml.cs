using MercadoLibre.Pages;

namespace MercadoLibre
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new Home());
            Flyout = new NavBar();

            App.FlyoutInstance = this;
        }

    }

}
