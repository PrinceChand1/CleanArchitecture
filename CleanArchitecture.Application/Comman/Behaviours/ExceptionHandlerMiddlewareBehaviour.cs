using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Domain.Entities.ErrorLogEntities;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories;
using CleanArchitecture.Shared.SharedResoures;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace CleanArchitecture.Application.Comman.Behaviours;
public class ExceptionHandlerMiddlewareBehaviour(RequestDelegate _requestDelegate)
{
    private IUnitOfWork _unitOfWork = null!;

    public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        try
        {
            await HandleExceptionAsync(context);
            await _requestDelegate(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception = null)
    {
        string errorMessage = exception.Message;
        try
        {
            var method = context.Request.Method;
            var operation = method switch
            {
                "GET" => "read",
                "POST" => "add",
                "PUT" => "update",
                "DELETE" => "delete",
                _ => "unknown"
            };

            ErrorLog ErrorlogObj = new()
            {
                Userid = 0,
                Method = method,
                Operation = operation,
                Path = context.Request.Path,
                InnerException = Convert.ToString(exception.InnerException),
                ErrorMessage = Convert.ToString(exception.Message),
                StackTrace = exception.StackTrace ?? "N/A",
                Date = DateTime.Now,
            };
            await _unitOfWork.ErrorLogRepository.AddAsync(ErrorlogObj);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            ResultDto<object> Res = new ResultDto<object>();
            if (ex.Message == SharedResoure.ErrorHandlingError)
            {
                Res.Success = false;
                Res.ErrorCode = 401;
                Res.Error = SharedResoure.SessionExpired;
            }
            else
            {
                Res.Success = false;
                Res.Error = ex.Message;
                Res.ErrorCode = 500;
            }
            var result = JsonConvert.SerializeObject(Res, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(Res);
        }
    }
}