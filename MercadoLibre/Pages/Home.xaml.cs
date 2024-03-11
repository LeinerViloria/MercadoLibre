using MercadoLibre.Models;
using Syncfusion.Maui.Carousel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MercadoLibre.Pages;

public partial class Home : ContentPage
{
    public ObservableCollection<string> CarouselItems { get; set; } = null!;
	public ObservableCollection<CategoryItem> CategoryItems { get; set; } = null!;

    public Home()
	{
		InitializeComponent();

		_ = LoadData();

		BindingContext = this;
	}

    public async Task LoadData()
	{
		var AddsData = await Utils.Utils.ReadJson<List<string>>("CarrouselItems");
		var CategoryItems = await Utils.Utils.ReadJson<List<CategoryItem>>("CategoryHomeItems");

		CarouselItems = new ObservableCollection<string>(AddsData);
		this.CategoryItems = new ObservableCollection<CategoryItem>(CategoryItems);
    }

}