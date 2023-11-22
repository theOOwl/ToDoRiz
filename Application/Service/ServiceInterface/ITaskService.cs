using Application.DTO.TasksDTOs;
using Domain.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceInterface
{
    public interface ITaskService
    {
        Task CreateTask(TasksDTOs task);
        List<Tasks> ListOfTasks();
        Task DeleteTask (Tasks task);
    }
}
