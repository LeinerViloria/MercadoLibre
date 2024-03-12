using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MercadoLibre.Pages;
public partial class MyFavorites : ContentPage, INotifyPropertyChanged
{
    public ObservableCollection<Favorite> Favorites { get; set; }

    public MyFavorites()
    {
        InitializeComponent();

        Favorites = new ObservableCollection<Favorite>();


        BindingContext = this;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Filtrar la lista de favoritos
    }
}

public class Favorite
{
    public string Name { get; set; }
    public string Price { get; set; }
    public string Image { get; set; }
}