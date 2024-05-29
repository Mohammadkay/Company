using Domain.Common;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceUnitOfWork;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDetailsController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public ServiceDetailsController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet]
        public IResponseResult<IEnumerable<Servicedetail>> GetAll()
        {
            using (_serviceUnitOfWork)
            {
                return _serviceUnitOfWork.ServicesDetails.Value.GetAll();
            }
        }
        [HttpGet("Id")]
        public async Task<IResponseResult<Servicedetail>> GetById(long Id)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.ServicesDetails.Value.GetByIdAsync(Id);
            }
        }
        [HttpDelete("Id")]
        public async Task<IResponseResult<Servicedetail>> Remove(long Id)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.ServicesDetails.Value.RemoveAsync(new Servicedetail() { Id = Id });
            }
        }
        [HttpPut]
        public async Task<IResponseResult<Servicedetail>> Update(Servicedetail entity)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.ServicesDetails.Value.UpdateAsync(entity);
            }
        }
        [HttpPost]
        public async Task<IResponseResult<Servicedetail>> Add(Servicedetail entity)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.ServicesDetails.Value.AddAsync(entity);
            }
        }
    }
}
