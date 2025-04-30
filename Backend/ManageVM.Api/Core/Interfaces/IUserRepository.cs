using ManageVM.Api.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManageVM.Api.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        User GetUser(User user);
        Task<ActionResult<User>> GetId(int id);
    }
}
