
using Infrastructure.ToDoRiz;
using Domain.Entities.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.RepoInterface;

namespace Infrastructure.RepoImplementation;

public class TasksRepo : ITasksRepo
{
    #region ctor
    private readonly ToDoRizDb _context;

    public TasksRepo(ToDoRizDb Context)
    {
        _context = Context;
    }
    #endregion
    public async Task CreateTask(Tasks task)
    {
        
        await _context.AddAsync(task);
        await _context.SaveChangesAsync();  
    }
    public async Task DeleteTask(Tasks task)
    {
        _context.Remove(task);
        await _context.SaveChangesAsync();
    }

    public async Task<Tasks> FindTaskById(int taskId)
    {
        return await _context.Tasks.FirstOrDefaultAsync(p => p.Id == taskId);
    }

    public List<Tasks> GetListOfTasks()
    {
        return _context.Tasks.ToList();
    }

    public async Task UpdateTask(Tasks task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }
}
