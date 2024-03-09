using System.Collections.ObjectModel;

namespace MercadoLibre.Pages;

public partial class Home : ContentPage
{
	public ObservableCollection<string> CarouselItems { get; set; } = null!;

    public Home()
	{
		InitializeComponent();

		_ = LoadData();

		BindingContext = this;
	}

	public async Task LoadData()
	{
		var Data = await Utils.Utils.ReadJson<List<string>>("CarrouselItems");
		CarouselItems = new ObservableCollection<string>(Data);
	}
}