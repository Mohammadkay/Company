using Domain.Common;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceUnitOfWork;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public OrderController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet]
        public IResponseResult<IEnumerable<Order>> GetAll()
        {
            using (_serviceUnitOfWork)
            {
                return _serviceUnitOfWork.Orders.Value.GetAll();
            }
        }
        [HttpGet("Id")]
        public async Task<IResponseResult<Order>> GetById(long Id)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Orders.Value.GetByIdAsync(Id);
            }
        }
        [HttpDelete("Id")]
        public async Task<IResponseResult<Order>> Remove(int  Id)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Orders.Value.RemoveAsync(new Order() { Id = Id });
            }
        }
        [HttpPut]
        public async Task<IResponseResult<Order>> Update(Order entity)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Orders.Value.UpdateAsync(entity);
            }
        }
        [HttpPost]
        public async Task<IResponseResult<Order>> Add(Order entity)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.Orders.Value.AddAsync(entity);
            }
        }
    }
}
