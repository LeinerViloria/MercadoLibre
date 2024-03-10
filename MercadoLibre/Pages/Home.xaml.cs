using MercadoLibre.Models;
using Syncfusion.Maui.Carousel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MercadoLibre.Pages;

public partial class Home : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public ObservableCollection<string> CarouselItems { get; set; } = null!;
	public ObservableCollection<CategoryItem> CategoryItems { get; set; } = null!;

	private List<ProductItem> LastProductsSeenValues { get; set; } = null!;

    public List<ProductItem> LastProductsSeen
	{
		get => LastProductsSeenValues;
		set
		{
			if(LastProductsSeenValues != value)
			{
				LastProductsSeenValues = value;
				OnPropertyChanged(nameof(LastProductsSeen));
			}
		}
	}

    public Home()
	{
		InitializeComponent();

		_ = LoadData();

		BindingContext = this;
	}

    protected override void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public async Task LoadData()
	{
		var AddsData = await Utils.Utils.ReadJson<List<string>>("CarrouselItems");
		var CategoryItems = await Utils.Utils.ReadJson<List<CategoryItem>>("CategoryHomeItems");

		CarouselItems = new ObservableCollection<string>(AddsData);
		this.CategoryItems = new ObservableCollection<CategoryItem>(CategoryItems);

		_ = LoadProductsInfo();
	}

	public async Task LoadProductsInfo()
	{
        LastProductsSeen = await Utils.Utils.ReadJson<List<ProductItem>>("LastProductsSeen");
    }
}