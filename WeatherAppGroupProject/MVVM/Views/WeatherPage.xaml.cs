namespace WeatherAppGroupProject.MVVM.Views;

public partial class WeatherPage : ContentPage
{
    private Page _currentPage;

    public WeatherPage()
    {
        InitializeComponent();


        // no longer needed as I used the the binding context for teh viewmodel
        // directly in teh top of teh relevant WeatherPage.xaml file 

        //BindingContext = new WeatherViewModel();


    }







}