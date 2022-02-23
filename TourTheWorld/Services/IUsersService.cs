using System.Threading.Tasks;
using TourTheWorld.Models.Identity;

namespace TourTheWorld.Services
{
    public interface IUsersService
    {
        Task<SignInResultModel> LoginAsync(LoginModel model);
    }
}
