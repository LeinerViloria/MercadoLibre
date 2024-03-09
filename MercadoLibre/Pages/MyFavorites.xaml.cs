using MercadoLibre.Models;
using System.Collections.ObjectModel;

namespace MercadoLibre.Pages;

public partial class MyFavorites : ContentPage
{
	public ObservableCollection<NotificationItem> Items { get; set; } = null!;
	public MyFavorites()
	{
		InitializeComponent();

		BindingContext = this;
	}

    public void ShowInfo(object Sender, SelectionChangedEventArgs e)
	{

	}
}