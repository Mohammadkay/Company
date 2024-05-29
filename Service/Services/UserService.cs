using Domain.Common;
using Domain.Models;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.enums;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        public UserService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public async Task<IResponseResult<User>> AddAsync(User model)
        {
            try
            {
                await _repositoryUnitOfWork.Users.Value.AddAsync(model);
                return new ResponseResult<User>() 
                { 
                    status=ResultStatus.Success,
                    Data=model,

                };
            }
            catch(Exception ex)
            {
                return new ResponseResult<User>() {
                    status=ResultStatus.Failed,
                    Error="The Error is "+ex.Message+ "The inner Exception" + ex.InnerException, 
                };
            }
        
        }

        public async Task<IResponseResult<IEnumerable<User>>> AddRangeAsync(IEnumerable<User> model)
        {
            try
            {
               var response=await _repositoryUnitOfWork.Users.Value.AddRangeAsync(model);
                    
                return new ResponseResult<IEnumerable<User>>()
                {
                    status = ResultStatus.Success,
                    Data = response,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<User>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public IResponseResult<IEnumerable<User>> GetAll()
        {
            try
            {
                var response= _repositoryUnitOfWork.Users.Value.GetAll();
                return new ResponseResult<IEnumerable<User>>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                    TotalRecord = response.Count()
                };
            }catch(Exception ex)
            {
                return new ResponseResult<IEnumerable<User>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<User>> GetByIdAsync(long id)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Users.Value.GetAsync(id);
                return new ResponseResult<User>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }catch(Exception ex )
            {
                return new ResponseResult<User>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<User>> RemoveAsync(User model)
        {
            try
            {
                var response =await _repositoryUnitOfWork.Users.Value.RemoveAsync(model);
                return new ResponseResult<User>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<User>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<IEnumerable<User>>> RemoveRangeAsync(IEnumerable<User> model)
        {
            try
            {
                await _repositoryUnitOfWork.Users.Value.RemoveRangeAsync(model);
                return new ResponseResult<IEnumerable<User>>()
                {
                    status = ResultStatus.Success,
                    Data = model
                };

            }catch(Exception ex)
            {
                return new ResponseResult<IEnumerable<User>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<User>> UpdateAsync(User model)
        {
            try
            {
                var response =await _repositoryUnitOfWork.Users.Value.UpdateAsync(model);
                return new ResponseResult<User>()
                {
                    status = ResultStatus.Success,
                    Data = response
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<User>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }
    }
}
