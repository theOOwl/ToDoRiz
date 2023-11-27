using Application.DTO.TasksDTOs;
using Application.Service.ServiceInterface;
using Domain.Entities.Tasks;
using Domain.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceImplementation
{
    public class TaskService : ITaskService
    {
        #region ctor
        private readonly ITasksRepo _TasksRepo;
        public TaskService(ITasksRepo TasksRepo)
        {
            _TasksRepo = TasksRepo;
        }
        #endregion
        public async Task CreateTask(TasksDTOs tasksDTOs)
        {
            //O_Mapping
            Tasks model = new Tasks()
            {
                Id = tasksDTOs.Id,
                Task = tasksDTOs.Task,
                status = tasksDTOs.status,
                Importance = tasksDTOs.Importance,
            };
                //
            await _TasksRepo.CreateTask(model);
        }

        public async Task DeleteTask(Tasks task)
        {
            await _TasksRepo.DeleteTask(task);
        }

        public async Task<Tasks> FindTaskById(int taskId)
        {
            return await _TasksRepo.FindTaskById(taskId);
        }

        public List<Tasks> ListOfTasks()
        {
            return _TasksRepo.GetListOfTasks();
        }

        public async Task UpdateTask(Tasks task)
        {
            await _TasksRepo.UpdateTask(task);
        }
    }
}
