using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using GerenciadorDeTarefas;

namespace TestandoProjeto
{
    [TestClass]
    public class TaskManagerTests
    {
        TaskManager taskManager;

        [TestInitialize]
        public void Setup()
        {
            taskManager = new TaskManager();
        }

        [TestMethod]
        public void AdicionarTarefa_DeveAdicionarTarefaCorretamente()
        {
            // Arrange
            Tarefa tarefa = new Tarefa
            {
                Title = "Tarefa 1",
                Description = "Descrição da Tarefa 1",
                Status = "Em andamento"
            };

            // Act
            taskManager.AddTask(tarefa);

            // Assert
            List<Tarefa> tarefas = taskManager.GetAllTasks();
            Assert.IsTrue(tarefas.Contains(tarefa));
        }

        [TestMethod]
        public void AtualizarTarefa_DeveAtualizarTarefaCorretamente()
        {
            // Arrange
            Tarefa tarefa = new Tarefa
            {
                Title = "Tarefa 1",
                Description = "Descrição da Tarefa 1",
                Status = "Em andamento"
            };
            taskManager.AddTask(tarefa);

            // Act
            Tarefa tarefaAtualizada = new Tarefa
            {
                Title = "Tarefa 1",
                Description = "Nova descrição da Tarefa 1",
                Status = "Concluída"
            };
            taskManager.UpdateTask("Tarefa 1", tarefaAtualizada);

            // Assert
            List<Tarefa> tarefas = taskManager.GetAllTasks();
            Tarefa tarefaObtida = tarefas.Find(t => t.Title == "Tarefa 1");
            Assert.AreEqual(tarefaAtualizada.Description, tarefaObtida.Description);
            Assert.AreEqual(tarefaAtualizada.Status, tarefaObtida.Status);
        }

        [TestMethod]
        public void ExcluirTarefa_DeveExcluirTarefaCorretamente()
        {
            // Arrange
            Tarefa tarefa = new Tarefa
            {
                Title = "Tarefa 1",
                Description = "Descrição da Tarefa 1",
                Status = "Em andamento"
            };
            taskManager.AddTask(tarefa);

            // Act
            taskManager.DeleteTask("Tarefa 1");

            // Assert
            List<Tarefa> tarefas = taskManager.GetAllTasks();
            Assert.IsFalse(tarefas.Contains(tarefa));
        }

        [TestMethod]
        public void FiltrarEClassificarTarefas_DeveFiltrarEClassificarTarefasCorretamente()
        {
            // Arrange
            Tarefa tarefa1 = new Tarefa
            {
                Title = "Tarefa 1",
                Description = "Descrição da Tarefa 1",
                Status = "Em andamento"
            };
            taskManager.AddTask(tarefa1);

            Tarefa tarefa2 = new Tarefa
            {
                Title = "Tarefa 2",
                Description = "Descrição da Tarefa 2",
                Status = "Concluída"
            };
            taskManager.AddTask(tarefa2);

            Tarefa tarefa3 = new Tarefa
            {
                Title = "Tarefa 3",
                Description = "Descrição da Tarefa 3",
                Status = "Em andamento"
            };
            taskManager.AddTask(tarefa3);

            // Act
            List<Tarefa> tarefasFiltradas = taskManager.FilterAndSortTasks(statusFilter: "Em andamento", sortBy: "Title");

            // Assert
            Assert.AreEqual(2, tarefasFiltradas.Count);
            Assert.AreEqual("Tarefa 1", tarefasFiltradas[0].Title);
            Assert.AreEqual("Tarefa 3", tarefasFiltradas[1].Title);
        }
    }
}
