using ManageVM.Api.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManageVM.Api.Core.Interfaces
{
    public interface IVMRepository
    {

        Task<List<VM>> GetAll();
        Task<ActionResult<VM>> GetId(int id);
        Task<int> Put(int id, VM vm);
        Task<int> Post(VM vm);
        Task<int> Delete(int id);
    }
}