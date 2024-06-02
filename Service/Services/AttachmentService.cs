using Domain.Common;
using Domain.enums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Repository.Common;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AttachmentService : IAttachmentService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public AttachmentService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork=repositoryUnitOfWork;
        }
        public async Task<IResponseResult<Attachment>> AddAsync(Attachment model)
        {
            try
            {
                await _repositoryUnitOfWork.Attachments.Value.AddAsync(model);
                return new ResponseResult<Attachment>()
                {
                    status = ResultStatus.Success,
                    Data = model,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Attachment>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }

        }

        public async Task<IResponseResult<IEnumerable<Attachment>>> AddRangeAsync(IEnumerable<Attachment> model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Attachments.Value.AddRangeAsync(model);

                return new ResponseResult<IEnumerable<Attachment>>()
                {
                    status = ResultStatus.Success,
                    Data = response,

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Attachment>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public IResponseResult<IEnumerable<Attachment>> GetAll()
        {
            try
            {
                var response = _repositoryUnitOfWork.Attachments.Value.GetAll();
                return new ResponseResult<IEnumerable<Attachment>>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                    TotalRecord = response.Count()
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Attachment>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Attachment>> GetByIdAsync(long id)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Attachments.Value.GetAsync(id);
                return new ResponseResult<Attachment>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Attachment>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Attachment>> RemoveAsync(Attachment model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Attachments.Value.RemoveAsync(model);
                return new ResponseResult<Attachment>()
                {
                    status = ResultStatus.Success,
                    Data = response,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Attachment>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<IEnumerable<Attachment>>> RemoveRangeAsync(IEnumerable<Attachment> model)
        {
            try
            {
                await _repositoryUnitOfWork.Attachments.Value.RemoveRangeAsync(model);
                return new ResponseResult<IEnumerable<Attachment>>()
                {
                    status = ResultStatus.Success,
                    Data = model
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<Attachment>>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }

        public async Task<IResponseResult<Attachment>> UpdateAsync(Attachment model)
        {
            try
            {
                var response = await _repositoryUnitOfWork.Attachments.Value.UpdateAsync(model);
                return new ResponseResult<Attachment>()
                {
                    status = ResultStatus.Success,
                    Data = response
                };

            }
            catch (Exception ex)
            {
                return new ResponseResult<Attachment>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };
            }
        }
        public async Task<IResponseResult<Attachment>> Upload(IFormFile file, long? objectType,  long? objectId)
        {
            try
            {
                var path = Path.Combine(SharedSettinges.FilePath, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                Attachment entity = new Attachment()
                {
                    AttachmentPath=path,
                    ObjectId=objectId,
                    ObjectType=objectType
                };
                var response=await _repositoryUnitOfWork.Attachments.Value.AddAsync(entity);
                return new ResponseResult<Attachment>()
                {
                    status = ResultStatus.Success,
                    Data = response

                };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Attachment>()
                {
                    status = ResultStatus.Failed,
                    Error = "The Error is " + ex.Message + "The inner Exception" + ex.InnerException,
                };

            }

        }
    
    }
}

