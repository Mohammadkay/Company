using Domain.Common;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceUnitOfWork;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public AttachmentController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        [HttpPost]
        public async Task<IResponseResult<Attachment>> Upload([FromForm]IFormFile file,[FromForm] long? objectType , [FromForm] long? objectId)
        {
            using (_serviceUnitOfWork)
            {
            return  await _serviceUnitOfWork.Attachment.Value.Upload(file, objectType, objectId);
            }
        }
    }
}
