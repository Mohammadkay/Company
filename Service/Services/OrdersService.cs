using Domain.Common;
using Domain.enums;
using Domain.Models;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrdersService:IOrdersService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        public OrdersService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public async Task<IResponseResult<Order>> AddAsync(Order model)
        {
            try
            {
                await _repositoryUnitOfWork.Orders.Value.AddAsync(model);
                return new ResponseResult<Order>()
                {
                    status = ResultStatus.Success,
                    Data = model,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Order>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }

        }

        public async Task<IResponseResult<IEnumerable<Order>>> AddRangeAsync(IEnumerable<Order> model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Orders.Value.AddRangeAsync(model);

                return new ResponseResult<IEnumerable<Order>>()
                {
                    status = ResultStatus.Success,
                    Data = response,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Order>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public IResponseResult<IEnumerable<Order>> GetAll()
        {
            try
            {
                var response = _repositoryUnitOfWork.Orders.Value.GetAll();
                return new ResponseResult<IEnumerable<Order>>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                    TotalRecord = response.Count()
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Order>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Order>> GetByIdAsync(long id)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Orders.Value.GetAsync(id);
                return new ResponseResult<Order>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Order>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Order>> RemoveAsync(Order model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Orders.Value.RemoveAsync(model);
                return new ResponseResult<Order>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Order>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<IEnumerable<Order>>> RemoveRangeAsync(IEnumerable<Order> model)
        {
            try
            {
                await _repositoryUnitOfWork.Orders.Value.RemoveRangeAsync(model);
                return new ResponseResult<IEnumerable<Order>>()
                {
                    status = ResultStatus.Success,
                    Data = model
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Order>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Order>> UpdateAsync(Order model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Orders.Value.UpdateAsync(model);
                return new ResponseResult<Order>()
                {
                    status = ResultStatus.Success,
                    Data = response
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<Order>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }
    }
}

