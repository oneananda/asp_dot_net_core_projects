using Login_Portal_WebApp.Models;
using Newtonsoft.Json;

namespace Login_Portal_WebApp.App_Code
{
    public class AuthService
    {
        private readonly string _dataFilePath;
        public AuthService(IWebHostEnvironment env)
        {
            _dataFilePath = Path.Combine(env.ContentRootPath, "Data", "users.json");
        }
        private List<User> LoadUsers()
        {
            var json = System.IO.File.ReadAllText(_dataFilePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
        public (bool IsValid, string Message) ValidateUser(string username, string password, string requiredRole = null)
        {
            var users = LoadUsers();
            var user = users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                if (!string.IsNullOrEmpty(requiredRole))
                {
                    if (user.Role == requiredRole)
                        return (true, $"Access granted. Role: {user.Role}");
                    else
                        return (false, $"Access denied. Your role: {user.Role}, required: {requiredRole}");
                }
                return (true, $"Login successful. Role: {user.Role}");
            }

            return (false, "Invalid username or password.");
        }
    }
}
