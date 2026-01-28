using Microsoft.AspNetCore.Mvc;
using TaskFlow.Domain.DTOs;
using TaskFlow.Domain.Services;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());
}

}
