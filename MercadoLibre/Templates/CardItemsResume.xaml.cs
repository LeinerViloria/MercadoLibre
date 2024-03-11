using MercadoLibre.Models;
using System.ComponentModel;
using MercadoLibre.Utils;

namespace MercadoLibre.Templates;

public partial class CardItemsResume : ContentView, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private string TitleValue { get; set; }
    public string Title { 
        get { return TitleValue; } set 
        {
            if(TitleValue != value) 
            {
                TitleValue = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    public string JsonName { get; set; }

    public List<ProductItem> Items { get; set; }
    public CardItemsResume()
	{
		InitializeComponent();

		BindingContext = this;
	}

    protected override void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async Task LoadData()
    {
        Items = await Utils.Utils.ReadJson<List<ProductItem>>($"{JsonName}.json");
    }
}