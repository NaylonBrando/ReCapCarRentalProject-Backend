using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //Bütün kodlari try catchten gecirir
        //apide istekte bulundugunuzda ilgili bütün yapı buradan gecer 
        //invoke, her zaman calisan metod
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); //hata olmazsa yardır
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e); //hata olursa handle et
            }
        }
        //ilgili hata kontrolden gecilirilir
        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> errors; //hatalari topladigimiz liste
            if (e.GetType() == typeof(ValidationException))//eger hata ValidationException türündeyse
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors; //hatalar erorrse atiyoruz
                httpContext.Response.StatusCode = 400;//validasyon hatasi oldugu için: 400, bad request

                //validasyon hatalari icin
                //validationa göre bir hata nesnesi olsturdum, errordetails olarak döndürdüm
                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = 400,
                    Message = message,
                    Errors = errors
                }.ToString());

            }

            //sistemsel hatalar icin
            //hata olursa hata bilgisi olarak bunu döndür
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
