using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IService<Model>
    {
        Task<IResponseResult<Model>> AddAsync(Model model);
        Task<IResponseResult<IEnumerable<Model>>> AddRangeAsync(IEnumerable<Model> model);
        Task<IResponseResult<IEnumerable<Model>>> RemoveRangeAsync(IEnumerable<Model> model);

        Task<IResponseResult<Model>> UpdateAsync(Model model);
        Task<IResponseResult<Model>> RemoveAsync(Model model);
        Task<IResponseResult<Model>> GetByIdAsync(long id);
        IResponseResult<IEnumerable<Model>> GetAll();

    }
}
