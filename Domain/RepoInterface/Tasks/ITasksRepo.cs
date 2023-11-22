using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Tasks;
namespace Domain.RepoInterface;
    public interface ITasksRepo
    {
        Task CreateTask(Tasks task);
        List<Tasks> GetListOfTasks();
        Task DeleteTask(Tasks task);
    }

