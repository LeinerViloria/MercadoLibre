namespace MercadoLibre
{
    public partial class App : Application
    {
        internal static FlyoutPage FlyoutInstance { get; set; } = null!;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
