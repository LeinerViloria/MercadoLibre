namespace MercadoLibre
{
    public partial class App : Application
    {
        internal static FlyoutPage? FlyoutInstance { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
