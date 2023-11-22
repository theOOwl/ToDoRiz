using Application.DTO.TasksDTOs;
using Application.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace ToDoRiz.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;
        public HomeController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _taskService.ListOfTasks();

            return View(model);
        }
        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTask(TasksDTOs tasksDTO)
        {
                await _taskService.CreateTask(tasksDTO);
                return RedirectToAction("Index", "Home");
        }
    }
}