using MercadoLibre.Models;
using System.Collections.ObjectModel;

namespace MercadoLibre.Pages;

public partial class Notifications : ContentPage
{
	public ObservableCollection<NotificationItem> Items { get; set; } = null!;
	public Notifications()
	{
		InitializeComponent();

		_ = LoadData();

		BindingContext = this;
	}

	public async Task LoadData()
	{
		var Data = await Utils.Utils.ReadJson<List<NotificationItem>>("Notifications");
		Items = new ObservableCollection<NotificationItem>(Data);
	}

	public void ShowInfo(object Sender, SelectionChangedEventArgs e)
	{
		if (CollectionViewRef.SelectedItem is null)
			return;

		var Item = (NotificationItem?)e.CurrentSelection.First();

		_ = DisplayAlert(Item.Title, Item.Description, "Cerrar");

        CollectionViewRef.SelectedItem = null;
    }
}