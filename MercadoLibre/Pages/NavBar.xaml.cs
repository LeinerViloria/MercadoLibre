using System.Collections.ObjectModel;
using MercadoLibre.Models;
using MercadoLibre.Utils;

namespace MercadoLibre.Pages;

public partial class NavBar : ContentPage
{
	public ObservableCollection<Menu> Items { get; set; }
	public NavBar()
	{
		InitializeComponent();

		_ = LoadData();

		BindingContext = this;
	}

	private async Task LoadData()
	{
        var Data = await Utils.Utils.ReadJson<List<Menu>>("MenuItems");
		Items = new ObservableCollection<Menu>(Data);
	}
}