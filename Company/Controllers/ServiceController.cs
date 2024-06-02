using Domain.Common;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceUnitOfWork;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public ServiceController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet]
        public IResponseResult<IEnumerable<CpService>> GetAll()
        {
            using (_serviceUnitOfWork)
            {
                return _serviceUnitOfWork.Services.Value.GetAll();
            } 
        }
        [HttpGet("Id")]
        public async Task<IResponseResult<CpService>> GetById(long Id)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Services.Value.GetByIdAsync(Id);
            }
        }
        [HttpDelete("Id")]
        public async Task<IResponseResult<CpService>> Remove(long Id)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Services.Value.RemoveAsync(new CpService() { Id = Id });
            }
        }
        [HttpPut]
        public async Task<IResponseResult<CpService>> Update(CpService entity)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Services.Value.UpdateAsync(entity);
            }
        }
        [HttpPost]
        public async Task<IResponseResult<CpService>> Add(CpService entity)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Services.Value.AddAsync(entity);
            }
        }
    }
}
