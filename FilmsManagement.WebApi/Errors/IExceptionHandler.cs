using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FilmsManagement.WebApi.Errors
{
    public interface IExceptionHandler
    {
        Task HandleException(HttpContext context);
    }
}
