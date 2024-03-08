using System.Collections.ObjectModel;
using MercadoLibre.Models;

namespace MercadoLibre.Pages;

public partial class NavBar : ContentPage
{
	public ObservableCollection<Menu> Items { get; set; }
	public NavBar()
	{
		InitializeComponent();

		Items = new ObservableCollection<Menu>(new () { new Menu() { Name = "Inicio" }, new Menu() { Name = "Inicio 2" } });

		BindingContext = this;
	}
}