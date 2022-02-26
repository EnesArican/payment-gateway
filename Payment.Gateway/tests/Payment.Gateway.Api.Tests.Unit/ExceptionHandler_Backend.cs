namespace Payment.Gateway.Api.Tests.Unit;

using Moq;
using System.Net;
using NUnit.Framework;
using FluentAssertions;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Payment.Gateway.Api.Components.Dtos;
using Payment.Gateway.Api.Controllers.Middleware;

public abstract class ExceptionHandler_Backend
{
    protected Mock<RequestDelegate> _mockRequestDelegate;
    protected Mock<ILogger<ExceptionHandlingMiddleware>> _mockLogger;

    public DataContext Data;
    protected ExceptionHandlingMiddleware Cut;

    [SetUp]
    public void Setup()
    {
        _mockRequestDelegate = new Mock<RequestDelegate>();
        _mockLogger = new Mock<ILogger<ExceptionHandlingMiddleware>>();

        Data = new DataContext();

        Cut = new ExceptionHandlingMiddleware(_mockRequestDelegate.Object, _mockLogger.Object);
    }

    protected ExceptionHandler_Backend Given => this;
    protected ExceptionHandler_Backend When => this;
    public ExceptionHandler_Backend Then => this;


    //GIVEN//
    public void Valid_http_context() 
    { 
        Data.Context = new DefaultHttpContext();
        Data.Context.Response.Body = new MemoryStream();
    }

    public void Application_throws_exception_of_type<T>(T exception)
        where T : Exception
    {
        Data.ExceptionMsg = exception.Message;

        _mockRequestDelegate
            .Setup(f => f(Data.Context))
            .ThrowsAsync(exception);
    }


    //WHEN//
    public Task Processing_request() =>
        Cut.InvokeAsync(Data.Context);


    //THEN//
    public void Should_return_status_code(HttpStatusCode code)
    {
        Data.Context.Response.StatusCode = (int)code;
    }

    public void Should_not_return_message()
    {
        Data.Context.Response.Body.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(Data.Context.Response.Body);

        reader.BaseStream.Length.Should().Be(0);
    }

    public void Should_return_exception_message()
    {
        Data.Context.Response.Body.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(Data.Context.Response.Body);
        var response = JsonSerializer.Deserialize<ErrorResponse>(reader.ReadToEnd());
        
        response.Message.Should().Be(Data.ExceptionMsg);
    }


    //DATA//
    public class DataContext
    {
        public string ExceptionMsg { get; set; }
        public HttpContext Context { get; set; }
    }
}