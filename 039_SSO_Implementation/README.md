# 🔐 ASP.NET MVC SSO with JWT Authentication

This project demonstrates how to implement **Single Sign-On (SSO)** using **JWT (JSON Web Token)** in **ASP.NET MVC**. It consists of two parts:

- **Token Provider** – Issues a JWT token after successful login.
- **SSO Client** – Receives the token and authenticates the user based on it.

---

## 🧱 Project Structure

```
/Login_Portal           --> ASP.NET MVC app that issues JWT tokens
/Main_Portal_WebApp      --> ASP.NET MVC app that receives and validates the token
```

---

## 🚀 Features

- JWT token generation using `System.IdentityModel.Tokens.Jwt`
- Secure token validation with HMAC SHA256
- Role and Username stored in token claims
- Cross-app redirection with token
- Opens SSO target in a **new tab**
- Simple session-based login simulation

---

## 🔐 Technologies Used

- ASP.NET MVC 5
- JWT (`System.IdentityModel.Tokens.Jwt`)
- C#
- .NET Framework 4.7.2+
- JavaScript (`window.open()` for new-tab redirection)

---

## ⚙️ How It Works

### 1. **Login to Token Provider**

The user logs in using a simple login form.

> `/Login_Portal/Account/Login`

On successful authentication, a JWT token is generated and passed to the SSO client app:

```
string token = JwtManager.GenerateToken(username, role);
string redirectUrl = "https://sso-client-app.com/Auth/Login?token=" + HttpUtility.UrlEncode(token);
return Json(new { redirectUrl });
```

---

### 2. **Redirect in New Tab**

On the client side (browser):

```javascript
fetch('/Account/Login')
    .then(res => res.json())
    .then(data => {
        window.open(data.redirectUrl, '_blank'); // Opens SSO client in new tab
    });
```

---

### 3. **Token Validation on SSO Client**

The SSO client receives the token and validates it:

```
var principal = JwtValidator.ValidateToken(token);
Session["User"] = principal.Identity.Name;
Session["Role"] = principal.FindFirst(ClaimTypes.Role)?.Value;
```

---

## 🔐 JWT Claims Example

```
{
  "sub": "john",
  "role": "Admin",
  "exp": 1711630400
}
```

---

## 🔑 JWT Secret Key

> Ensure both apps share the **same secret key** (`HMAC SHA256`) to sign and validate the token.

```
private const string Secret = "MyVeryStrongSecretKey123!";
```

---

## 🧪 Testing

1. Run both apps in IIS Express or host on two local ports.
2. Log in at the **Token Provider**.
3. The app will open the **SSO Client** in a new tab and authenticate using the token.

---

## 📦 NuGet Packages

Install in both projects:

```
Install-Package System.IdentityModel.Tokens.Jwt
```

---

## 📜 License

This project is open source and free to use under the [MIT License](LICENSE).

---


