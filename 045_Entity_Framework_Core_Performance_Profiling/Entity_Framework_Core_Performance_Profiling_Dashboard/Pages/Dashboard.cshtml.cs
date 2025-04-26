using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace Entity_Framework_Core_Performance_Profiling_Dashboard.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly string _connectionString = "Your SQL Server Connection String Here";
        private readonly string _databaseName = "Profiling_DB";
        public string DatabaseStatus { get; set; }
        public List<string> OperationUpdates { get; set; }

        public DashboardModel()
        {
            OperationUpdates = new List<string>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            DatabaseStatus = await CheckDatabaseStatusAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostCheckDbStatusAsync()
        {
            OperationUpdates.Clear();  // Clear previous updates
            DatabaseStatus = await CheckDatabaseStatusAsync();
            return Partial("_DashboardUpdates", this); // Return partial view to update the status dynamically
        }

        private async Task<string> CheckDatabaseStatusAsync()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                var command = new SqlCommand($"SELECT DB_ID('{_databaseName}')", connection);
                var result = await command.ExecuteScalarAsync();

                if (result == DBNull.Value)
                {
                    OperationUpdates.Add("Database does not exist. Attempting to create...");
                    bool created = await CreateDatabaseAsync(connection);
                    if (created)
                    {
                        OperationUpdates.Add("Database created successfully.");
                        return "Database 'Profiling_DB' was created successfully.";
                    }
                    else
                    {
                        return "Failed to create the database.";
                    }
                }
                else
                {
                    return "Database 'Profiling_DB' already exists.";
                }
            }
            catch (Exception ex)
            {
                OperationUpdates.Add($"Error: {ex.Message}");
                return "Error occurred while checking the database status.";
            }
        }

        private async Task<bool> CreateDatabaseAsync(SqlConnection connection)
        {
            try
            {
                var createDbCommand = new SqlCommand($"CREATE DATABASE {_databaseName}", connection);
                await createDbCommand.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                OperationUpdates.Add($"Error creating database: {ex.Message}");
                return false;
            }
        }
    }
}
