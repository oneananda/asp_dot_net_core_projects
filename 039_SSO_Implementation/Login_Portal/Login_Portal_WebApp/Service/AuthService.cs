using Login_Portal_WebApp.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Login_Portal_WebApp.App_Code
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
        public (bool IsValid, string Role, string Message, string Token) ValidateUser(string username, string password, string requiredRole = null)
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

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Audience"],
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
