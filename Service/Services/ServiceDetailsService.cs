﻿using Domain.Common;
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
        public async Task<IResponseResult<ServiceDetail>> AddAsync(ServiceDetail model)
        {
            try
            {
                await _repositoryUnitOfWork.ServiceDetails.Value.AddAsync(model);
                return new ResponseResult<ServiceDetail>()
                {
                    status = ResultStatus.Success,
                    Data = model,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<ServiceDetail>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }

        }

        public async Task<IResponseResult<IEnumerable<ServiceDetail>>> AddRangeAsync(IEnumerable<ServiceDetail> model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.ServiceDetails.Value.AddRangeAsync(model);

                return new ResponseResult<IEnumerable<ServiceDetail>>()
                {
                    status = ResultStatus.Success,
                    Data = response,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<ServiceDetail>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public IResponseResult<IEnumerable<ServiceDetail>> GetAll()
        {
            try
            {
                var response = _repositoryUnitOfWork.ServiceDetails.Value.GetAll();
                return new ResponseResult<IEnumerable<ServiceDetail>>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                    TotalRecord = response.Count()
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<ServiceDetail>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<ServiceDetail>> GetByIdAsync(long id)
        {
            try
            {
                var response = await _repositoryUnitOfWork.ServiceDetails.Value.GetAsync(id);
                return new ResponseResult<ServiceDetail>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<ServiceDetail>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<ServiceDetail>> RemoveAsync(ServiceDetail model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.ServiceDetails.Value.RemoveAsync(model);
                return new ResponseResult<ServiceDetail>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<ServiceDetail>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<IEnumerable<ServiceDetail>>> RemoveRangeAsync(IEnumerable<ServiceDetail> model)
        {
            try
            {
                await _repositoryUnitOfWork.ServiceDetails.Value.RemoveRangeAsync(model);
                return new ResponseResult<IEnumerable<ServiceDetail>>()
                {
                    status = ResultStatus.Success,
                    Data = model
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<ServiceDetail>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<ServiceDetail>> UpdateAsync(ServiceDetail model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.ServiceDetails.Value.UpdateAsync(model);
                return new ResponseResult<ServiceDetail>()
                {
                    status = ResultStatus.Success,
                    Data = response
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<ServiceDetail>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }
    }
}

