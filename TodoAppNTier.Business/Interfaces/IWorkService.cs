using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Dtos.WorkDtos;

namespace TodoAppNTier.Business.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAll();
        Task<WorkListDto> GetById(int id);
        Task Create(WorkCreateDto dto);
        Task Update(WorkUpdateDto dto);
        Task Remove(int id);
    }
}
