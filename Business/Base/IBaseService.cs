using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base
{
    public interface IBaseService<TEntityGetDTO,TEntityCreateDTO,TEntityUpdateDTO>
    {
        Task<List<TEntityGetDTO>> GetAll();

        Task<TEntityGetDTO> Get(int? id);

        Task Create(TEntityCreateDTO entity);

        Task Update(int id,TEntityUpdateDTO entity);

        Task Delete(int? id);
    }
}
