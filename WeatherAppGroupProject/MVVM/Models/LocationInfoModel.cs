namespace WeatherAppGroupProject.MVVM.Models
{

    // a generic data model for handling site data corresponding to teh sampple weather data
    public class LocationInfoModel
    {
        public double Latitude { get; set; } = 0.0;
        public double Longitude { get; set; } = 0.0;

        public int Elevation { get; set; } = 0;
        public int UtcOffset { get; set; } = 0;

        public string Timezone { get; set; } = "GMT";


    }
}
