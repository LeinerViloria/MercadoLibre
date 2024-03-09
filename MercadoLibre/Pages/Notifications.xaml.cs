using MercadoLibre.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MercadoLibre.Pages;

public partial class Notifications : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
	private ObservableCollection<NotificationItem> _items { get; set; }
    public ObservableCollection<NotificationItem> Items {
		get { return _items; }
		set {
            if (_items != value)
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
	}
    private bool _isLoading { get; set; } = true;
	public bool IsLoading
    {
        get { return _isLoading; }
        set
        {
            if (_isLoading != value)
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
    }

    public Notifications()
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
		var Data = await Utils.Utils.ReadJson<List<NotificationItem>>("Notifications");

		await Task.Delay(2000); //2seg

		Items = new ObservableCollection<NotificationItem>(Data);

        IsLoading = false;
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