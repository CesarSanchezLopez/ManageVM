using ManageVM.Api.Core.Entities;
using ManageVM.Api.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageVM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VMController : Controller
    {
        private readonly IVMRepository _vM; // Repository interface 
        public VMController(IVMRepository vM)
        {
            _vM = vM;
        }
        // GET: api/<VMController>  
        [HttpGet]
        //public async Task<List<VM>> Task<ActionResult<List<Core.Entities.VM>>> Get()
        public async Task<List<VM>> GetAll()
        {
            return await _vM.GetAll();
        }
        // GET api/<VMController>/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<Core.Entities.VM>> Get(int id)
        {
            var vm = await _vM.GetId(id);
            if (vm == null)
            {
                return NotFound();
            }
            return vm;
        }
        // POST api/<VMController>
        [Authorize(Roles = "Admin")]
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Core.Entities.VM>> Post([FromBody] Core.Entities.VM vm)
        {
            if (vm == null)
            {
                return BadRequest();
            }
            await _vM.Post(vm);
            return CreatedAtAction(nameof(Get), new { id = vm.Id }, vm);
        }
        // PUT api/<VMController>/5 
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Core.Entities.VM vm)
        {
            if (id != vm.Id)
            {
                return BadRequest();
            }
            //try
            //{
                await _vM.Put(id, vm);
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (await _vM.GetId(id) == null)
            //    {
            //        return NotFound();
            //    }
            //    throw;
            //}
            return NoContent();
        }
        // DELETE api/<VMController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vm = await _vM.GetId(id);
            if (vm == null)
            {
                return NotFound();
            }
            await _vM.Delete(id);
            return NoContent();
        }
      


    }
}
