using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas
    {
        public class Tarefa
        {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; } // Data de início da tarefa
        public DateTime EndDate { get; set; } // Data de término da tarefa

        public Tarefa()
        {
            // Inicialize as datas como a data atual por padrão
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }
    }
}