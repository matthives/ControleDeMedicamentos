using ControleDeMedicamentos.WebApp.Compartilhado;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

public class TelaRequisicaoEntrada : TelaBase<RequisicaoEntrada>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;
    private readonly RepositorioFuncionarios repositorioFuncionario;

    public TelaRequisicaoEntrada(
        RepositorioRequisicaoEntradaEmArquivo repositorioRequisicao,
        RepositorioMedicamentoEmArquivo repositorioMedicamento,
        RepositorioFuncionarios repositorioFuncionarios
    ) : base("Requisição de Entrada", repositorioRequisicao)
    {
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFuncionario = repositorioFuncionarios;
    }

    protected override bool ExistemDependenciasAtivasDoRegistro(int idRegistro)
    {
        return false;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Requisições de Entrada");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -15}",
            "Id", "Medicamento", "Qtd", "Data"
        );

        List<RequisicaoEntrada> registros = repositorio.SelecionarTodos();

        foreach (RequisicaoEntrada r in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -15}",
                r.Id, r.Medicamento.Nome, r.Quantidade, r.Data.ToShortDateString()
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override RequisicaoEntrada ObterDadosCadastrais()
    {
        VisualizarMedicamentos();

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do medicamento que deseja requisitar: ");
        int idMedicamento = Convert.ToInt32(Console.ReadLine());
        Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento)!;

        Console.WriteLine("---------------------------------");

        Console.Write("Digite a quantidade de medicamento que deseja requisitar: ");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        VisualizarFuncionarios();

        Console.Write("Digite o ID do funcionário requisitante: ");
        int idFuncionario = Convert.ToInt32(Console.ReadLine());
        Funcionarios funcionarios = repositorioFuncionario.SelecionarPorId(idFuncionario)!;

        return new RequisicaoEntrada(medicamento, quantidade, funcionarios);
    }

    private void VisualizarMedicamentos()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -20}",
            "Id", "Nome", "Fornecedor", "Descrição"
        );

        List<Medicamento> registros = repositorioMedicamento.SelecionarTodos();

        foreach (Medicamento m in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -20}",
                m.Id, m.Nome, m.Fornecedor.Nome, m.Descricao
            );
        }
    }

    private void VisualizarFuncionarios()
    {
        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -14}",
            "Id", "Nome", "Telefone", "CPF"
        );

        List<Funcionarios> registros = repositorioFuncionario.SelecionarTodos();

        foreach (Funcionarios f in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -14}",
                f.Id, f.Nome, f.Telefone, f.Cpf
            );
        }
    }
}
