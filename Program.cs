using _7DaysOfCode.Controllers;
using _7DaysOfCode.Models;
using _7DaysOfCode.Services;

MascoteController mascotes = new MascoteController();

string opcao;
bool exibirMenu = true;

while (exibirMenu)
{

    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Visualizar Mascotes");
    Console.WriteLine("2 - Buscar Habilidades");
    Console.WriteLine("3 - Limpar console");
    Console.WriteLine("4 - Encerrar");

    opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            mascotes.VisualizarMascotes();
            break;
        case "2":
            mascotes.VisualizarHabilidades();
            break;
        case "3":
            Console.Clear();
            break;
        case "4":
            Console.WriteLine("Encerrar");
            exibirMenu = false;
            break;
        default:
            Console.WriteLine("Opção não entendida");
            break;
    }
}

