using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.DTOs;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Services
{
    public interface ITaskService
    {
        Task<TaskItem> CreateAsync(CreateTaskDto dto);
        Task<IEnumerable<TaskItem>> GetAllAsync();
    }
    public class TaskService : ITaskService
    {
        private static readonly List<TaskItem> _tasks = new();

        public Task<TaskItem> CreateAsync(CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description
            };

            _tasks.Add(task);
            return Task.FromResult(task);
        }

        public Task<IEnumerable<TaskItem>> GetAllAsync()
            => Task.FromResult(_tasks.AsEnumerable());
    }

}
