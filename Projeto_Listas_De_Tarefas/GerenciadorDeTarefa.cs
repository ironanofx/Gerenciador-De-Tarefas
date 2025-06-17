using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Listas_De_Tarefas.Modelos;

namespace Projeto_Listas_De_Tarefas 
{ 

        public static class GerenciadorDeTarefas
        {
            private static List<Tarefa> tarefas = new();
            private static int proximoId = 1;

            public static void Listar()
            {
                if (tarefas.Count == 0)
                {
                    Console.WriteLine("Nenhuma tarefa encontrada.");
                    return;
                }

                foreach (var tarefa in tarefas)
                {
                    string status = tarefa.Concluida ? "[X]" : "[ ]";
                    Console.WriteLine($"{status} {tarefa.Id} - {tarefa.Descricao}");
                }
            }

            public static void Adicionar()
            {
                Console.Write("Digite a descrição da tarefa: ");
                string descricao = Console.ReadLine();

                tarefas.Add(new Tarefa(proximoId++, descricao));
                Console.WriteLine("Tarefa adicionada com sucesso!");
            }

            public static void MarcarComoConcluida()
            {
                Console.Write("Digite o ID da tarefa a marcar como concluída: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var tarefa = tarefas.Find(t => t.Id == id);
                    if (tarefa != null)
                    {
                        tarefa.Concluida = true;
                        Console.WriteLine("Tarefa marcada como concluída!");
                    }
                    else
                    {
                        Console.WriteLine("Tarefa não encontrada.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
            }

            public static void RemoverConcluidas()
            {
                int antes = tarefas.Count;
                tarefas.RemoveAll(t => t.Concluida);
                int removidas = antes - tarefas.Count;

                Console.WriteLine($"{removidas} tarefa(s) concluída(s) removida(s)!");
                if (removidas == 0)
                {
                    Console.WriteLine("Nenhuma tarefa concluída para remover.");
                }
            }
        }
}


