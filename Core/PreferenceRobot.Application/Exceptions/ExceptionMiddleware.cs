﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex);
			}
        }

		private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
		{
			int statusCode = GetStatusCode(exception);
			httpContext.Response.ContentType= "application/json";
			httpContext.Response.StatusCode = statusCode;

			if (exception.GetType() == typeof(ValidationException))
				return httpContext.Response.WriteAsync(new ExceptionModel
				{
                    Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage),
					StatusCode = StatusCodes.Status400BadRequest
				}.ToString());
           
            List<string> errors = new()
			{
				$"Error Message: {exception.Message}"
			};

            _logger.LogError(exception.ToString());

            return httpContext.Response.WriteAsync(new ExceptionModel
			{
				Errors=errors,
				StatusCode=statusCode
			}.ToString());
		}

		private static int GetStatusCode(Exception exception) =>
			exception switch
			{
				BadRequestException => StatusCodes.Status400BadRequest,
				NotFoundException => StatusCodes.Status400BadRequest,
				ValidationException =>StatusCodes.Status422UnprocessableEntity,
				_ => StatusCodes.Status500InternalServerError
			};
       
    }
}
