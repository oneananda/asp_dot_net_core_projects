using Database_Per_Tenant.Models;
using Newtonsoft.Json;

namespace Database_Per_Tenant.Service
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly string _dataFilePath;
        public AuthService(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _dataFilePath = Path.Combine(env.ContentRootPath, "App_Data", "users.json");
        }
        private List<User> LoadUsers()
        {
            var json = System.IO.File.ReadAllText(_dataFilePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
        public (bool IsValid, string Role, string Message) ValidateUser(string username, string password)
        {
            var users = LoadUsers();
            var user = users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                //var token = JwtManager.GenerateToken(user.UserName, user.Role);
                return (true, user.Role, $"Login successful. Role: {user.Role}");
            }
            return (false, user.Role, "Invalid username or password.");
        }
    }
}
