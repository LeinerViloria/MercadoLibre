using MercadoLibre.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MercadoLibre.Templates;

public partial class CardItemsResume : ContentView, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private string TitleValue {  get; set; }
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

    public static readonly BindableProperty ItemsProperty =
    BindableProperty.Create(nameof(Items), typeof(List<ProductItem>), typeof(CardItemsResume));

    public List<ProductItem> Items
    {
        get { return (List<ProductItem>)GetValue(ItemsProperty); }
        set {
            SetValue(ItemsProperty, value);
            OnPropertyChanged(nameof(Items));
        }
    }
    public CardItemsResume()
	{
		InitializeComponent();

		BindingContext = this;
	}

    protected override void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}