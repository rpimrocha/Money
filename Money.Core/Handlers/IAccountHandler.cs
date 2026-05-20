using Money.Core.Requests.Account;
using Money.Core.Responses;

namespace Money.Core.Handlers
{
    public interface IAccountHandler
    {
        Task<Response<string>> LoginAsync(LoginRequest request);
        Task<Response<string>> RegistroAsync(RegistroRequest request);
        Task LogoutAsync();
    }
}
