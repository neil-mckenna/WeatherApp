using System.Collections.ObjectModel;

namespace WeatherAppGroupProject.MVVM.Models
{
    // this class is the parent model of LocationInfoModel and WeatherMeasurements
    // it is represenattive of the weather data.xlsl

    // so i was thinking 1 location and mutiple time measurements
    public class WeatherDataModel
    {
        // this is a reference to the other data model for detail about (latitute, longtitde , elevation and so on
        public LocationInfoModel Location { get; set; } = new();

        // this is basically a fancy UI List for the Weather Measurements withd data like
        // (time, temperature,humidity, windspeed, wind direction  
        public ObservableCollection<WeatherMeasurementsModel> Measurements { get; set; } =
            new ObservableCollection<WeatherMeasurementsModel>();



    }
}
