using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Data.SqlClient;
using System.Diagnostics;



namespace WeatherAppGroupProject.Utilities
{
    public static class AppConfig
    {
        private const string ConnectionString =
            "Server=IP_ADDRESS;Database=WeatherMonitoringDB;User Id = sa; Password=NeilKaneAna!;TrustServerCertificate=True;Encrypt=True;Connect Timeout = 30";

        public static string DbConnectionString => ConnectionString;

        public static async Task<bool> TestConnectionAsync()
        {
            try
            {
                Debug.WriteLine($"\nConnection string :  {ConnectionString}");

                await using var connection = new SqlConnection(ConnectionString);


                await connection.OpenAsync();

                Debug.WriteLine("\n✅ Successfully connected to the database!");

                await ShowToastAsync("\n✅ Successfully connected to the database!", ToastDuration.Short);

                // Simple test query
                await using var command = new SqlCommand("SELECT 1", connection);
                var result = await command.ExecuteScalarAsync();

                return result?.ToString() == "1";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n❌ Failed to connect to the database.");
                Debug.WriteLine($"\nError: {ex.Message}");

                await ShowToastAsync($"\n❌ Failed to connect: {ex.Message}", ToastDuration.Long);

                return false;
            }
        }

        private static async Task ShowToastAsync(string message, ToastDuration duration)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                var toast = Toast.Make(message, duration);
                await toast.Show();
            });
        }
    }
}



