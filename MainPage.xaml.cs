using ApiEjemplo.Models;
using Newtonsoft.Json;

namespace ApiEjemplo;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void LlamarApi(object sender, EventArgs e)
    {
		string latitud = latitud.Text;
        string longitud = longitud.Text;

		using (var client = new HttpClient())
		{
			var url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon="+longitud + "&appid=4af1e82a857895326699fc8c21455c9b";

			var response = client.GetAsync(url).Result;
			if (response.IsSuccessStatusCode){
				string content = response.Content.ReadAsStringAsync().Result;			}
			var weatherData = JsonConvert.DeserializeObject<JM_Clima>(content);
			EstadoClima.Text = weatherData.weather[0].description;
		}

    }
}

