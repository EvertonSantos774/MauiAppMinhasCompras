using MauiAppMinhasCompras.Models;
using System.Globalization;

namespace MauiAppMinhasCompras.Views;

public partial class Relatorio : ContentPage
{
    public Relatorio()
    {
        InitializeComponent();
    }

    private async void BtnBuscar_Clicked(object sender, EventArgs e)
    {
        try
        {
            DateTime dataInicio, dataFim;

            DateTime.TryParseExact(
                txt_data_inicio.Text,
                "dd/MM/yyyy",
                null,
                DateTimeStyles.None,
                out dataInicio
            );

            DateTime.TryParseExact(
                txt_data_fim.Text,
                "dd/MM/yyyy",
                null,
                DateTimeStyles.None,
                out dataFim
            );

            var lista = await App.Db.GetByPeriodo(dataInicio, dataFim);

            lista_relatorio.ItemsSource = lista;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}