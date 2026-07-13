using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;

public class TelaFuncionarios : TelaBase<Funcionarios>, ITelaOpcoes, ITelaCrud
{
    public TelaFuncionarios(RepositorioFuncionarios repositorio) : base("Funcionarios", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Funcionários");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -17}",
            "Id", "Nome", "Telefone", "CPF"
        );

        List<Funcionarios> registros = repositorio.SelecionarTodos();

        foreach (Funcionarios f in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -17}",
                f.Id, f.Nome, f.Telefone, f.Cpf
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Funcionarios ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do funcionário: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do funcionário: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o CPF do funcionário: ");
        string cpf = Console.ReadLine() ?? string.Empty;

        return new Funcionarios(nome, telefone, cpf);
    }

    protected override bool ExisteRegistroComInformacoesExclusivas(Funcionarios entidade, int? idIgnorado = null)
    {
        List<Funcionarios> registros = repositorio.SelecionarTodos();

        foreach (Funcionarios f in registros)
        {
            if (f.Id != idIgnorado && f.Cpf == entidade.Cpf)
            {
                Console.WriteLine("---------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Já existe um funcionário cadastrado com o CPF informado.");
                Console.ResetColor();
                Console.WriteLine("---------------------------------");
                return true;
            }
        }

        return false;
    }
}
