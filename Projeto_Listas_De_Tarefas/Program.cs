using Projeto_Listas_De_Tarefas.Controlador;
using Projeto_Listas_De_Tarefas.Modelos;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            MostrarMenu();

            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1": GerenciadorDeTarefas.Listar(); break;
                case "2": GerenciadorDeTarefas.Adicionar(); break;
                case "3": GerenciadorDeTarefas.MarcarComoConcluida(); break;
                case "4": GerenciadorDeTarefas.RemoverConcluidas(); break;
                case "5": GerenciadorDeTarefas.EditarDescricao(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida."); break;
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("Gerenciador de Tarefas");
        Console.WriteLine("1. Listar Tarefas");
        Console.WriteLine("2. Adicionar Tarefa");
        Console.WriteLine("3. Marcar como Concluída");
        Console.WriteLine("4. Remover Tarefas Concluídas");
        Console.WriteLine("5. Editar Descrição de Tarefa");
        Console.WriteLine("0. Sair");
        Console.Write("Escolha uma opção: ");
    }
}

