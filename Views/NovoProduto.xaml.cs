using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
            DateTime dataConvertida;

            DateTime.TryParseExact(
                txt_data.Text,
                "dd/MM/yyyy",
                null,
                System.Globalization.DateTimeStyles.None,
                out dataConvertida
            );
            Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text),
                Data = dataConvertida
            };

			await App.Db.Insert(p);
			await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
			await Navigation.PopAsync();

		} catch(Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
        } // Fecha try-catch
    } // Fecha ToolbarItem_Clicked
} // Fecha classe NovoProduto