using ManageVM.Api.Core.Entities;

namespace ManageVM.Api.Core.Interfaces
{
    public interface IAuthService
    {
        public bool ValidateLogin(User userModel);
        string GenerateToken(DateTime fechaActual, User user, TimeSpan tiempoValidez);

        bool ValidateToken(string key, string issuer, string token);
    }
}
