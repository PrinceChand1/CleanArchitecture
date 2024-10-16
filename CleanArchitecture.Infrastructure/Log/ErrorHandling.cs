//using CleanArchitecture.Domain.Repositories;
//using Microsoft.AspNetCore.Http;
//using System.Net;

//namespace CleanArchitecture.Infrastructure.Log;
//public class ErrorHandling(RequestDelegate _requestDelegate)
//{
//    private IUnitOfWork unitOfWork = null!;
//    public async Task InvokeAsync(HttpContext context, IUnitOfWork _unitOfWork)
//    {
//        unitOfWork = _unitOfWork;
//        try
//        {
//            await _requestDelegate(context);
//        }
//        catch (Exception ex)
//        {
//            await HandleExceptionAsync(context, ex);
//        }
//    }

//    private async Task HandleExceptionAsync(HttpContext context, Exception exceptione)
//    {
//        string errorMessage = exceptione.Message;
//        try
//        {
//            ErrorLog ErrorlogObj = new()
//            {
//                Path = context.Request.Path,
//                InnerException = Convert.ToString(exception.InnerException),
//                ErrorMessage = Convert.ToString(exception.Message),
//                StackTrace = exception.StackTrace ?? "N/A",
//                Date = DateTime.Now,
//            };
//            await unitOfWork.ErrorLogs.AddAsync(ErrorlogObj);
//            await unitOfWork.CompleteAsync();
//        }
//        catch (Exception)
//        {
//            Result<Object> Res = new Result<object>();
//            if (Message == SharedResources.ErrorHandlingError)
//            {
//                Res.Success = false;
//                Res.ErrorCode = 401;
//                Res.Error = SharedResources.SessionExpired;
//            }
//            else
//            {
//                Res.Success = false;
//                Res.Error = Message;
//                Res.ErrorCode = 500;
//                Res.Error = exception.Message;

//            }
//            //if(context.Response.Body.== "Authontication")
//            var result = JsonConvert.SerializeObject(Res, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//            await context.Response.WriteAsJsonAsync(Res);
//        }
//    }
//}
