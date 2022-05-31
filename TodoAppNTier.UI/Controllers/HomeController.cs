using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoAppNTier.Business.Interfaces;
using TodoAppNTier.Dtos.WorkDtos;

namespace TodoAppNTier.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;

        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task<IActionResult> Index()
        {
            var workList = await _workService.GetAll();
            return View(workList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
            await _workService.Create(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dto = await _workService.GetById(id);
            return View(new WorkUpdateDto
            {
                Definition = dto.Definition,
                Id = dto.Id,
                IsCompleted = dto.IsCompleted
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            await _workService.Update(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _workService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
