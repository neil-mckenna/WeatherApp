// database stuff
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using WeatherAppGroupProject.MVVM.Models;
using WeatherAppGroupProject.Utilities;


namespace WeatherAppGroupProject.MVVM.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        // fields
        private static Random _random = new Random();   // used for random generation
        private WeatherDataModel _weatherDataModel = new(); // data container
        private ObservableCollection<WeatherMeasurementsModel> _measurements;

        private string _connectionStatus;
        public string ConnectionStatus
        {
            get => _connectionStatus;
            set
            {
                if (_connectionStatus != value)
                {
                    _connectionStatus = value;
                    Debug.WriteLine($"Connection Status Changed: {value}");
                    OnPropertyChanged(nameof(ConnectionStatus));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

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

            TestDatabaseConnectionAsync();

        }

        // Database connection check
        private async void TestDatabaseConnectionAsync()
        {
            try
            {
                bool isConnected = await AppConfig.TestConnectionAsync();

                if (isConnected)
                {
                    ConnectionStatus = "Connected to Database";
                    Debug.WriteLine("✅ DATABASE CONNECTION SUCCESSFUL");
                    // Show success dialog

                }
                else
                {
                    ConnectionStatus = "Failed to Connect";
                    Debug.WriteLine("❌ DATABASE CONNECTION FAILED");

                }
            }
            catch (Exception ex)
            {
                ConnectionStatus = $"Error: {ex.Message}";
                Debug.WriteLine($"❌ DATABASE CONNECTION FAILED WITH EXCEPTION: {ex.Message} {ex}");

            }

            Debug.WriteLine($"Connection Status: {ConnectionStatus}");


        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}
