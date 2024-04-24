using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace GerenciadorDeTarefas
{
    public class TaskManager
    {
        private List<Tarefa> tasks; // Corrigindo para usar a classe Tarefa
        private string filePath;

        public TaskManager()
        {
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filePath = Path.Combine(directory, "tasks.json");
            tasks = new List<Tarefa>(); // Corrigindo para usar a classe Tarefa
            LoadTasks();
        }

        public void AddTask(Tarefa task) // Corrigindo para usar a classe Tarefa
        {
            tasks.Add(task);
            SaveTasks();
        }

        public void UpdateTask(string title, Tarefa updatedTask) // Corrigindo para usar a classe Tarefa
        {
            Tarefa existingTask = tasks.Find(t => t.Title == title);
            if (existingTask != null)
            {
                existingTask.Description = updatedTask.Description;
                existingTask.Status = updatedTask.Status;
                SaveTasks();
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada!");
            }
        }

        public void DeleteTask(string title)
        {
            Tarefa taskToRemove = tasks.Find(t => t.Title == title);
            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
                SaveTasks();
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada!");
            }
        }

        public List<Tarefa> GetAllTasks()
        {
            return tasks;
        }

        // Este método precisa ser corrigido para se adequar à estrutura da classe Tarefa
        public List<Tarefa> FilterAndSortTasks(string statusFilter = null, DateTime? startDate = null, DateTime? endDate = null, string sortBy = "Title")
        {
            IEnumerable<Tarefa> filteredTasks = tasks;

            // Filtrar por status
            if (statusFilter != null)
            {
                filteredTasks = filteredTasks.Where(t => t.Status == statusFilter);
            }

            // Filtrar por datas de início e fim, se fornecidas
            if (startDate != null)
            {
                filteredTasks = filteredTasks.Where(t => t.StartDate >= startDate);
            }

            if (endDate != null)
            {
                filteredTasks = filteredTasks.Where(t => t.EndDate <= endDate);
            }

            // Ordenar
            switch (sortBy)
            {
                case "Title":
                    filteredTasks = filteredTasks.OrderBy(t => t.Title);
                    break;
                case "Description":
                    filteredTasks = filteredTasks.OrderBy(t => t.Description);
                    break;
                case "Status":
                    filteredTasks = filteredTasks.OrderBy(t => t.Status);
                    break;
                // Adicione mais casos conforme necessário
                default:
                    break;
            }

            return filteredTasks.ToList();
        }


        private void SaveTasks()
        {
            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(filePath, json);
        }

        private void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                tasks = JsonSerializer.Deserialize<List<Tarefa>>(json); // Corrigindo para usar a classe Tarefa
            }
        }
    }
}
