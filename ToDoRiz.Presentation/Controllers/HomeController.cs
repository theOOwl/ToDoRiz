using Application.DTO.TasksDTOs;
using Application.Service.ServiceInterface;
using Domain.Entities.Tasks;
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
        [HttpGet]
        public async Task<IActionResult> MakeTaskDone(int taskId)
        {
            var task = await _taskService.FindTaskById(taskId);
            return View(task);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> MakeTaskDone(Tasks tasks)
        {
            await _taskService.UpdateTask(tasks);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var task = await _taskService.FindTaskById(taskId);
            return View(task);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTask(Tasks tasks)
        {
            await _taskService.DeleteTask(tasks);
            return RedirectToAction(nameof(Index));
        }
    }
}