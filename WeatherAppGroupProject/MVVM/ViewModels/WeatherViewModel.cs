using System.Collections.ObjectModel;
using System.Diagnostics;
using WeatherAppGroupProject.MVVM.Models;

namespace WeatherAppGroupProject.MVVM.ViewModels
{
    public class WeatherViewModel
    {
        // fields
        private static Random _random = new Random();   // used for random generation
        private WeatherDataModel _weatherDataModel = new(); // data container
        private ObservableCollection<WeatherMeasurementsModel> _measurements;

        // weather data property 
        public WeatherDataModel WeatherData
        {
            get => _weatherDataModel;

            set
            {
                // null check and new instance creation
                _weatherDataModel = value ?? new WeatherDataModel();
            }
        }

        // a read only measurements propety
        public ObservableCollection<WeatherMeasurementsModel> Measurements
            => _weatherDataModel.Measurements;


        // constrcutor
        public WeatherViewModel()
        {
            // initialise
            _measurements = new ObservableCollection<WeatherMeasurementsModel>();

            // setup the weather with defaults
            _weatherDataModel = new WeatherDataModel
            {
                Location = new LocationInfoModel(),
                Measurements = new ObservableCollection<WeatherMeasurementsModel>(_measurements)
            };


            // Generate 10 random weather measurments
            for (int i = 0; i < 10; i++)
            {
                Measurements.Add(new WeatherMeasurementsModel
                {
                    Time = DateTime.Now.AddHours(-i),
                    Temperature = Math.Round(15 + _random.NextDouble() * 15, 1), // 15-30°C
                    Humidity = _random.Next(40, 90),                             // 40-90%
                    WindSpeed = Math.Round(1 + _random.NextDouble() * 10, 1),    // 1-11 m/s
                    WindDirection = _random.Next(0, 360)                         // 0-360°
                });
            }



            Debug.WriteLine("VIEW MODEL initialsed");
            Measurements.CollectionChanged += (s, e) => Debug.WriteLine($"Collection changed: {Measurements.Count}");


        }

    }
}
