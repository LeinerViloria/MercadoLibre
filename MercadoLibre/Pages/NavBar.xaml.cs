using System.Collections.ObjectModel;
using MercadoLibre.Models;

namespace MercadoLibre.Pages;

public partial class NavBar : ContentPage
{
	public ObservableCollection<Menu> Items { get; set; } = null!;
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

	public void Navigate(object Sender, SelectionChangedEventArgs e)
	{
		if (CollectionViewRef.SelectedItem is null)
			return;

		var Item = (Menu?)e.CurrentSelection.FirstOrDefault();

		if (Item!.IsSeparator)
			return;

		var Page = Utils.Utils.GetContentPage(Item?.NavigateTo ?? string.Empty);

		var KeepInPage = Page.GetType() == typeof(Home);

        App.FlyoutInstance.IsPresented = false;

		CollectionViewRef.SelectedItem = null;

        if (KeepInPage)
            return;

        _ = App.FlyoutInstance.Detail.Navigation.PushAsync(Page);
	}
}