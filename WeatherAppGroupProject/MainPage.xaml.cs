using WeatherAppGroupProject.MVVM.Views;

namespace WeatherAppGroupProject
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        // custom button click event to go to weather page
        private async void NavigationToWeatherPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeatherPage());
        }
    }

}
