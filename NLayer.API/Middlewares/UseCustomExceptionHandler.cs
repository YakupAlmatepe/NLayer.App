using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    //exception fırlatmak için clas ve metotlarımız Static olmalı
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)//ıapplicationbuilder için yazacağımız exception 
        {//kendi exceptionumuzu kullanmak için yaptığımız işlem
            app.UseExceptionHandler(config =>
            {
                //Run ile amaç sonlandırmak daha ileriye gitmeden sonlanmak 
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    //hata tiplerini belirtiyoruz
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundExcepiton => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;


                    var response = CustomeResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);


                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
    }
}