using Domain.Common;
using Domain.enums;
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
        public async Task<IResponseResult<Domain.Models.Service>> AddAsync(Domain.Models.Service model)
        {
            try
            {
                await _repositoryUnitOfWork.Services.Value.AddAsync(model);
                return new ResponseResult<Domain.Models.Service>()
                {
                    status = ResultStatus.Success,
                    Data = model,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Domain.Models.Service>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }

        }

        public async Task<IResponseResult<IEnumerable<Domain.Models.Service>>> AddRangeAsync(IEnumerable<Domain.Models.Service> model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Services.Value.AddRangeAsync(model);

                return new ResponseResult<IEnumerable<Domain.Models.Service>>()
                {
                    status = ResultStatus.Success,
                    Data = response,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Domain.Models.Service>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public IResponseResult<IEnumerable<Domain.Models.Service>> GetAll()
        {
            try
            {
                var response = _repositoryUnitOfWork.Services.Value.GetAll();
                return new ResponseResult<IEnumerable<Domain.Models.Service>>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                    TotalRecord = response.Count()
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Domain.Models.Service>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Domain.Models.Service>> GetByIdAsync(long id)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Services.Value.GetAsync(id);
                return new ResponseResult<Domain.Models.Service>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Domain.Models.Service>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Domain.Models.Service>> RemoveAsync(Domain.Models.Service model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Services.Value.RemoveAsync(model);
                return new ResponseResult<Domain.Models.Service>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Domain.Models.Service>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<IEnumerable<Domain.Models.Service>>> RemoveRangeAsync(IEnumerable<Domain.Models.Service> model)
        {
            try
            {
                await _repositoryUnitOfWork.Services.Value.RemoveRangeAsync(model);
                return new ResponseResult<IEnumerable<Domain.Models.Service>>()
                {
                    status = ResultStatus.Success,
                    Data = model
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Domain.Models.Service>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Domain.Models.Service>> UpdateAsync(Domain.Models.Service model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Services.Value.UpdateAsync(model);
                return new ResponseResult<Domain.Models.Service>()
                {
                    status = ResultStatus.Success,
                    Data = response
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<Domain.Models.Service>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }
    }
}
