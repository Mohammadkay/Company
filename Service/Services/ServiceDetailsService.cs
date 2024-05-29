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
    public class ServiceDetailsService : IServiceDetailsService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        public ServiceDetailsService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public async Task<IResponseResult<Servicedetail>> AddAsync(Servicedetail model)
        {
            try
            {
                await _repositoryUnitOfWork.ServiceDetails.Value.AddAsync(model);
                return new ResponseResult<Servicedetail>()
                {
                    status = ResultStatus.Success,
                    Data = model,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Servicedetail>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }

        }

        public async Task<IResponseResult<IEnumerable<Servicedetail>>> AddRangeAsync(IEnumerable<Servicedetail> model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.ServiceDetails.Value.AddRangeAsync(model);

                return new ResponseResult<IEnumerable<Servicedetail>>()
                {
                    status = ResultStatus.Success,
                    Data = response,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Servicedetail>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public IResponseResult<IEnumerable<Servicedetail>> GetAll()
        {
            try
            {
                var response = _repositoryUnitOfWork.ServiceDetails.Value.GetAll();
                return new ResponseResult<IEnumerable<Servicedetail>>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                    TotalRecord = response.Count()
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Servicedetail>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Servicedetail>> GetByIdAsync(long id)
        {
            try
            {
                var response = await _repositoryUnitOfWork.ServiceDetails.Value.GetAsync(id);
                return new ResponseResult<Servicedetail>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Servicedetail>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Servicedetail>> RemoveAsync(Servicedetail model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.ServiceDetails.Value.RemoveAsync(model);
                return new ResponseResult<Servicedetail>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Servicedetail>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<IEnumerable<Servicedetail>>> RemoveRangeAsync(IEnumerable<Servicedetail> model)
        {
            try
            {
                await _repositoryUnitOfWork.ServiceDetails.Value.RemoveRangeAsync(model);
                return new ResponseResult<IEnumerable<Servicedetail>>()
                {
                    status = ResultStatus.Success,
                    Data = model
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Servicedetail>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Servicedetail>> UpdateAsync(Servicedetail model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.ServiceDetails.Value.UpdateAsync(model);
                return new ResponseResult<Servicedetail>()
                {
                    status = ResultStatus.Success,
                    Data = response
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<Servicedetail>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }
    }
}

