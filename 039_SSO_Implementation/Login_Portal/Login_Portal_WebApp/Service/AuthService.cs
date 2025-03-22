using Login_Portal_WebApp.Models;
using Newtonsoft.Json;

namespace Login_Portal_WebApp.App_Code
{
    public class AuthService
    {
        private readonly string _dataFilePath;
        public AuthService(IWebHostEnvironment env)
        {
            _dataFilePath = Path.Combine(env.ContentRootPath, "App_Data", "users.json");
        }
        private List<User> LoadUsers()
        {
            var json = System.IO.File.ReadAllText(_dataFilePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
        public (bool IsValid, string Role, string Message) ValidateUser(string username, string password, string requiredRole = null)
        {
            var users = LoadUsers();
            var user = users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                if (!string.IsNullOrEmpty(requiredRole))
                {
                    if (user.Role == requiredRole)
                        return (true, user.Role, $"Access granted. Role: {user.Role}");
                    else
                        return (false, user.Role, $"Access denied. Your role: {user.Role}, required: {requiredRole}");
                }
                return (true, user.Role, $"Login successful. Role: {user.Role}");
            }

            return (false, user.Role, "Invalid username or password.");
        }
    }
}
