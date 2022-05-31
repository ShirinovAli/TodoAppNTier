using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Business.Interfaces;
using TodoAppNTier.DataAccess.UnitOfWork;
using TodoAppNTier.Dtos.WorkDtos;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.Business.Services
{
    public class WorkManager : IWorkService
    {
        private readonly IUow _uow;

        public WorkManager(IUow uow)
        {
            _uow = uow;
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(new()
            {
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted
            });
            await _uow.SaveChanges();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _uow.GetRepository<Work>().GetAll();

            var workList = new List<WorkListDto>();

            if (list != null && list.Count != 0)
            {
                foreach (var work in list)
                {
                    workList.Add(new()
                    {
                        Definition = work.Definition,
                        Id = work.Id,
                        IsCompleted = work.IsCompleted
                    });
                }
            }
            return workList;
        }

        public async Task<WorkListDto> GetById(int id)
        {
            var data = await _uow.GetRepository<Work>().Get(x => x.Id == id);
            return new()
            {
                Definition = data.Definition,
                IsCompleted = data.IsCompleted
            };
        }

        public async Task Remove(int id)
        {
            _uow.GetRepository<Work>().Remove(id);
            await _uow.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto)
        {
            _uow.GetRepository<Work>().Update(new()
            {
                Definition = dto.Definition,
                Id = dto.Id,
                IsCompleted = dto.IsCompleted
            });
            await _uow.SaveChanges();
        }
    }
}
