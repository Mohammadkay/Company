using Domain.Common;
using Domain.enums;
using Domain.Models;
using Repository.UnitOfWork;
using Service.Common;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Service:IServices
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        public Service(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public async Task<IResponseResult<CpService>> AddAsync(CpService model)
        {
            try
            {
                await _repositoryUnitOfWork.Services.Value.AddAsync(model);
                return new ResponseResult<CpService>()
                {
                    status = ResultStatus.Success,
                    Data = model,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<CpService>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }

        }

        public async Task<IResponseResult<IEnumerable<CpService>>> AddRangeAsync(IEnumerable<CpService> model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Services.Value.AddRangeAsync(model);

                return new ResponseResult<IEnumerable<CpService>>()
                {
                    status = ResultStatus.Success,
                    Data = response,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<CpService>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public IResponseResult<IEnumerable<CpService>> GetAll()
        {
            try
            {
                var response = _repositoryUnitOfWork.Services.Value.GetAll();
                return new ResponseResult<IEnumerable<CpService>>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                    TotalRecord = response.Count()
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<CpService>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<CpService>> GetByIdAsync(long id)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Services.Value.GetAsync(id);
                return new ResponseResult<CpService>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<CpService>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<CpService>> RemoveAsync(CpService model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Services.Value.RemoveAsync(model);
                return new ResponseResult<CpService>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<CpService>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<IEnumerable<CpService>>> RemoveRangeAsync(IEnumerable<CpService> model)
        {
            try
            {
                await _repositoryUnitOfWork.Services.Value.RemoveRangeAsync(model);
                return new ResponseResult<IEnumerable<CpService>>()
                {
                    status = ResultStatus.Success,
                    Data = model
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<CpService>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<CpService>> UpdateAsync(CpService model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Services.Value.UpdateAsync(model);
                return new ResponseResult<CpService>()
                {
                    status = ResultStatus.Success,
                    Data = response
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<CpService>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }
    }
}
