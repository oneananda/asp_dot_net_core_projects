# 🔐 ASP.NET MVC SSO with JWT Authentication

This project demonstrates how to implement **Single Sign-On (SSO)** using **JWT (JSON Web Token)** in **ASP.NET MVC**. It consists of two parts:

- **Token Provider** – Issues a JWT token after successful login.
- **SSO Client** – Receives the token and authenticates the user based on it.

---

## 🧱 Project Structure

```
/Login__Portal           --> ASP.NET MVC app that issues JWT tokens
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

