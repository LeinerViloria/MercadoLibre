using MercadoLibre.Models;
using System.Collections.ObjectModel;

namespace MercadoLibre.Pages;

public partial class Notifications : ContentPage
{
	public ObservableCollection<NotificationItem> Items { get; set; } = null!;
	public Notifications()
	{
		InitializeComponent();

		BindingContext = this;
	}

	public void ShowInfo(object Sender, SelectionChangedEventArgs e)
	{

	}
}