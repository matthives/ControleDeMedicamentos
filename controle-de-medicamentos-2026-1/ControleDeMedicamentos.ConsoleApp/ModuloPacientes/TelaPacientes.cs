using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPacientes;

public class TelaPacientes : TelaBase<Pacientes>, ITelaOpcoes, ITelaCrud
{
    public TelaPacientes(RepositorioPacientesEmArquivo repositorio) : base("Pacientes", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Pacientes");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -17} | {4, -14} ",
            "Id", "Nome", "Telefone", "Cartão do SUS", "CPF"
        );

        List<Pacientes> registros = repositorio.SelecionarTodos();

        foreach (Pacientes f in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -17} | {4, -14} ",
                f.Id, f.Nome, f.Telefone, f.CartaoSUS, f.Cpf
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Pacientes ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do paciente: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do paciente: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o cartão do SUS do paciente: ");
        string cartaoSUS = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o CPF do paciente: ");
        string cpf = Console.ReadLine() ?? string.Empty;

        return new Pacientes(nome, telefone, cartaoSUS, cpf);
    }

    protected override bool ExisteRegistroComInformacoesExclusivas(Pacientes entidade, int? idIgnorado = null)
    {
        List<Pacientes> registros = repositorio.SelecionarTodos();

        foreach (Pacientes f in registros)
        {
            if (f.Id != idIgnorado && f.Cpf == entidade.Cpf)
            {
                Console.WriteLine("---------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Já existe um paciente cadastrado com o CPF informado.");
                Console.ResetColor();
                Console.WriteLine("---------------------------------");
                return true;
            }
        }

        return false;
    }
}
