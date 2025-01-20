using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

using DomainTaskStatus = TaskManagement.Domain.Entities.TaskStatus;

namespace TaskManagement.API.Controllers
{
    /// <summary>
    /// Controlador para la gestión de tareas.
    /// Proporciona endpoints para crear, obtener, actualizar y eliminar tareas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        /// <summary>
        /// Constructor del controlador de tareas.
        /// </summary>
        /// <param name="taskService">Servicio de gestión de tareas.</param>
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Obtiene todas las tareas disponibles.
        /// </summary>
        /// <returns>Lista de tareas disponibles.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        /// <summary>
        /// Agrega una nueva tarea.
        /// </summary>
        /// <param name="task">Objeto de la tarea a agregar.</param>
        /// <returns>La tarea agregada.</returns>
        /// <remarks>
        /// **Valores permitidos en el campo `status`:**  
        /// - `0` → pendiente  
        /// - `1` → en progreso  
        /// - `2` → completada  
        /// </remarks>
        [HttpPost("add")]
        public async Task<IActionResult> AddTask([FromBody] TaskItem task)
        {
            if ((int)task.Status < 0 || (int)task.Status > 2)
                return BadRequest("El campo 'status' solo puede tener los valores: 0 (Pendiente), 1 (En Progreso) o 2 (Completada).");

            await _taskService.AddTaskAsync(task);
            return Ok(task);
        }

        /// <summary>
        /// Obtiene las tareas según su estado.
        /// </summary>
        /// <param name="status">Estado de la tarea (Ejemplo: "pendiente", "en progreso", "completada").</param>
        /// <returns>Lista de tareas con el estado especificado.</returns>
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetTasksByStatus(string status)
        {
            switch (status.ToLower())
            {
                case "pendiente":
                    status = "Pendiente";
                    break;
                case "en progreso":
                    status = "EnProgreso";
                    break;
                case "completada":
                    status = "Completada";
                    break;
                default:
                    return BadRequest($"Estado '{status}' no válido. Usa: pendiente, en progreso o completada.");
            }

            if (!Enum.TryParse(status, out DomainTaskStatus enumStatus))
                return BadRequest($"Estado '{status}' no válido.");

            var tasks = await _taskService.GetTasksByStatusAsync(enumStatus);
            return Ok(tasks);
        }

        /// <summary>
        /// Obtiene una tarea específica por su ID.
        /// </summary>
        /// <param name="id">ID de la tarea.</param>
        /// <returns>La tarea encontrada o un mensaje de error si no se encuentra.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(string id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound(new { Message = $"Tarea con ID {id} no encontrada." });

            return Ok(task);
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="id">ID de la tarea a actualizar.</param>
        /// <param name="updatedTask">Objeto con los nuevos datos de la tarea.</param>
        /// <returns>Mensaje de confirmación de actualización.</returns>
        /// <remarks>
        /// **Valores permitidos en el campo `status`:**  
        /// - `0` → pendiente  
        /// - `1` → en progreso  
        /// - `2` → completada  
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(string id, [FromBody] TaskItem updatedTask)
        {
            if ((int)updatedTask.Status < 0 || (int)updatedTask.Status > 2)
                return BadRequest("El campo 'status' solo puede tener los valores: 0 (Pendiente), 1 (En Progreso) o 2 (Completada).");

            await _taskService.UpdateTaskAsync(id, updatedTask);
            return Ok(new { Message = $"Tarea con ID {id} actualizada exitosamente." });
        }

        /// <summary>
        /// Elimina una tarea por su ID.
        /// </summary>
        /// <param name="id">ID de la tarea a eliminar.</param>
        /// <returns>Mensaje de confirmación de eliminación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(string id)
        {
            await _taskService.DeleteTaskAsync(id);
            return Ok(new { Message = $"Tarea con ID {id} eliminada exitosamente." });
        }
    }
}
