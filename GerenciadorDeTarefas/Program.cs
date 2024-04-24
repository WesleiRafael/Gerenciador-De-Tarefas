using System;

namespace GerenciadorDeTarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("===== Gerenciador de Tarefas =====");
                Console.WriteLine("1. Adicionar Tarefa");
                Console.WriteLine("2. Atualizar Tarefa");
                Console.WriteLine("3. Excluir Tarefa");
                Console.WriteLine("4. Listar Tarefas");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                string escolha = Console.ReadKey().KeyChar.ToString(); // Obtém a tecla pressionada

                switch (escolha)
                {
                    case "1":
                        AdicionarTarefa(taskManager);
                        break;
                    case "2":
                        AtualizarTarefa(taskManager);
                        break;
                    case "3":
                        ExcluirTarefa(taskManager);
                        break;
                    case "4":
                        ListarTarefas(taskManager);
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AdicionarTarefa(TaskManager taskManager)
        {
            Console.WriteLine("===== Adicionar Tarefa =====");
            Console.Write("Título: ");
            string title = Console.ReadLine();
            Console.Write("Descrição: ");
            string description = Console.ReadLine();
            Console.Write("Status: ");
            string status = Console.ReadLine();

            Tarefa novaTarefa = new Tarefa
            {
                Title = title,
                Description = description,
                Status = status
            };

            taskManager.AddTask(novaTarefa);
            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        static void AtualizarTarefa(TaskManager taskManager)
        {
            Console.WriteLine("===== Atualizar Tarefa =====");
            Console.Write("Título da tarefa a ser atualizada: ");
            string title = Console.ReadLine();

            Tarefa tarefaExistente = taskManager.GetAllTasks().Find(t => t.Title == title);
            if (tarefaExistente != null)
            {
                Console.Write("Nova descrição: ");
                tarefaExistente.Description = Console.ReadLine();
                Console.Write("Novo status: ");
                tarefaExistente.Status = Console.ReadLine();

                taskManager.UpdateTask(title, tarefaExistente);
                Console.WriteLine("Tarefa atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada!");
            }
        }

        static void ExcluirTarefa(TaskManager taskManager)
        {
            Console.WriteLine("===== Excluir Tarefa =====");
            Console.Write("Título da tarefa a ser excluída: ");
            string title = Console.ReadLine();

            taskManager.DeleteTask(title);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }

        static void ListarTarefas(TaskManager taskManager)
        {
            Console.WriteLine("===== Lista de Tarefas =====");
            var tarefas = taskManager.GetAllTasks();
            foreach (var tarefa in tarefas)
            {
                Console.WriteLine($"Título: {tarefa.Title}");
                Console.WriteLine($"Descrição: {tarefa.Description}");
                Console.WriteLine($"Status: {tarefa.Status}");
                Console.WriteLine();
            }
        }
    }
}
