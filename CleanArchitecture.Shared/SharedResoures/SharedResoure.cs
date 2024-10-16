﻿namespace CleanArchitecture.Shared.SharedResoures;
public class SharedResoure
{
    public const string BaseRoutes = "api/v{v:apiVersion}/[controller]/[action]";
    public const string IdRoutes = "{id}";
    public static string[] AllowOrigin = { "http://localhost:4200", "https://espacefann.azurewebsites.net" };
    public const string Bearer = "Bearer";
    public const string JWT = "JWT";
    public const string GroupNameFormat = "'v'VVV";
    public const string Authorization = "Authorization";
    public const string jwtTokenDescription = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"";
    public const string PolicyName = "allOrigin";
    public const string ConnectionString = "default";
    public const string AppSettings = "AppSettings";
    public const string SendEmailSettings = "SendEmailSettings";
    public const string ErrorHandlingError = "StatusCode cannot be set because the response has already started.";
    public const string SessionExpired = "Your session is expired now.Please login again.";
    public const string UnableToHandleRequest = "Unable to handle the request.";
    public const string Usernotfound = "User not found.";
    public const string IncorrectPassword = "Password is incorrect.";
    public const string UnauthorizeUser = "This end point secured with token.Plese provide the token.";
}
