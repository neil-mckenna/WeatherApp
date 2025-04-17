namespace WeatherAppGroupProject.MVVM.Models
{

    // this is the measurements for teh weather data, properties 
    public class WeatherMeasurementsModel
    {
        // a nullable timestamp
        public DateTime? Time { get; set; }

        // tempaerature in celcuis
        public double Temperature { get; set; }

        // humidty 1- 100 percent
        public int Humidity { get; set; }

        // wind speed in meters per second
        public double WindSpeed { get; set; }

        // wind direction in 360 degress, this can be converted later on to a cardinal systems N, E, S, W
        public int WindDirection { get; set; }


    }
}
