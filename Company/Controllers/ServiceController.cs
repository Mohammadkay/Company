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
        public IResponseResult<IEnumerable<Domain.Models.Service>> GetAll()
        {
            using (_serviceUnitOfWork)
            {
                return _serviceUnitOfWork.Services.Value.GetAll();
            }
        }
        [HttpGet("Id")]
        public async Task<IResponseResult<Domain.Models.Service>> GetById(long Id)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Services.Value.GetByIdAsync(Id);
            }
        }
        [HttpDelete("Id")]
        public async Task<IResponseResult<Domain.Models.Service>> Remove(long Id)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Services.Value.RemoveAsync(new Domain.Models.Service() { Id = Id });
            }
        }
        [HttpPut]
        public async Task<IResponseResult<Domain.Models.Service>> Update(Domain.Models.Service entity)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Services.Value.UpdateAsync(entity);
            }
        }
        [HttpPost]
        public async Task<IResponseResult<Domain.Models.Service>> Add(Domain.Models.Service entity)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Services.Value.AddAsync(entity);
            }
        }
    }
}
