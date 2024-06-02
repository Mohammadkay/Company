using Domain.Common;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceUnitOfWork;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public UserController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet]
        public IResponseResult<IEnumerable<User>> GetAll()
        {
            using (_serviceUnitOfWork)
            {
                return _serviceUnitOfWork.Users.Value.GetAll();
            }
        }
        [HttpGet("Id")]
        public async Task<IResponseResult<User>> GetById(long Id)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Users.Value.GetByIdAsync(Id);
            }
        }
        [HttpDelete("Id")]
        public async Task<IResponseResult<User>> Remove(int  Id)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Users.Value.RemoveAsync(new User() { Id=Id});
            }
        }
        [HttpPut]
        public async Task<IResponseResult<User>> Update(User entity)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Users.Value.UpdateAsync(entity);
            }
        }
        [HttpPost]
        public async Task<IResponseResult<User>> Add(User entity)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Users.Value.AddAsync(entity);
            }
        }
    }
}
