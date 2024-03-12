using MercadoLibre.Models;
using Syncfusion.Maui.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MercadoLibre.Pages;

public partial class MyPurchases : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public List<PurchaseItem> Items { get; set; } = null!;
	public bool IsLoading { get; set; } = true;
	public bool ShowCollection => !IsLoading;
	public MyPurchases()
	{
		InitializeComponent();

        BindingContext = this;

		_ = LoadData();
	}

    protected override void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async Task LoadData()
	{
		await SetData();

        IsLoading = false;
		OnPropertyChanged(nameof(IsLoading));
		OnPropertyChanged(nameof(ShowCollection));
	}

	public void LoadMoreCommand(object Sender, EventArgs e)
	{

	}

	public async Task SetData()
	{
		var Data = await Utils.Utils.ReadJson<List<PurchaseItem>>("MyPurchases");

        await Task.Delay(3000);

        Items = Data;

		OnPropertyChanged(nameof(Items));
	}
}