using Projeto_Listas_De_Tarefas;

class Program
{
    static List<Tarefa> tarefas = new List<Tarefa>();
    static int proximoId = 1;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Gerenciador de Tarefas ===");
            Console.WriteLine("1. Listar Tarefas");
            Console.WriteLine("2. Adicionar Tarefa");
            Console.WriteLine("3. Marcar como Concluída");
            Console.WriteLine("4. Remover Tarefas Concluídas");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1": ListarTarefas(); break;
                case "2": AdicionarTarefa(); break;
                case "3": MarcarComoConcluida(); break;
                case "4": RemoverTarefasConcluidas(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida."); break;
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void ListarTarefas()
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

    static void AdicionarTarefa()
    {
        Console.Write("Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine();
        tarefas.Add(new Tarefa(proximoId++, descricao));
        Console.WriteLine("Tarefa adicionada com sucesso!");
    }

    static void MarcarComoConcluida()
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

    static void RemoverTarefasConcluidas()
    {
        int countAntes = tarefas.Count;
        tarefas.RemoveAll(t => t.Concluida);
        int removidas = countAntes - tarefas.Count;
        Console.WriteLine($"{removidas} tarefa(s) concluída(s) removida(s)!");
        if (removidas == 0)
        {
            Console.WriteLine("Nenhuma tarefa concluída para remover.");
        }
    }
}

