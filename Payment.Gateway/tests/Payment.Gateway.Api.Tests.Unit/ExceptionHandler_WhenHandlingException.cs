namespace Payment.Gateway.Api.Tests.Unit;

using System.Net;
using NUnit.Framework;
using System.Threading.Tasks;
using Payment.Gateway.Api.Components.Utils;

public class ExceptionHandler_WhenGettingBasicInfoAsync : ExceptionHandler_Backend
{
    [Test]
    public async Task Should_return_400_with_message()
    {
        Given.Valid_http_context();
        Given.Application_throws_exception_of_type(new AppException("test message"));
        await When.Processing_request();
        Then.Should_return_status_code(HttpStatusCode.BadRequest);
        Then.Should_return_exception_message();
    }

    [Test]
    public async Task Should_return_404_with_no_message()
    {
        Given.Valid_http_context();
        Given.Application_throws_exception_of_type(new HttpRequestException("404"));
        await When.Processing_request();
        Then.Should_return_status_code(HttpStatusCode.NotFound);
        Then.Should_not_return_message();
    }

    [TestCaseSource(nameof(ShouldReturn500TestCases))]
    public async Task Should_return_500_with_no_message(Exception exception)
    {
        Given.Valid_http_context();
        Given.Application_throws_exception_of_type(exception);
        await When.Processing_request();
        Then.Should_return_status_code(HttpStatusCode.NotFound);
        Then.Should_not_return_message();
    }

    private static IEnumerable<TestCaseData> ShouldReturn500TestCases()
    {
        yield return new TestCaseData(new Exception());
        yield return new TestCaseData(new ArgumentNullException());   
        yield return new TestCaseData(new InvalidOperationException("test message"));
    }
}