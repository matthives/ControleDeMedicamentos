using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class TelaRequisicaoSaida : TelaBase<RequisicaoSaida>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioPacientesEmArquivo repositorioPacientes;
    private readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;

    public TelaRequisicaoSaida(
        RepositorioRequisicaoSaidaEmArquivo repositorioRequisicao,
        RepositorioPacientesEmArquivo repositorioPacientes,
        RepositorioMedicamentoEmArquivo repositorioMedicamento
    ) : base("Requisição de Saída", repositorioRequisicao)
    {
        this.repositorioPacientes = repositorioPacientes;
        this.repositorioMedicamento = repositorioMedicamento;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Requisições de Saída");
            Console.WriteLine("---------------------------------");
        }

        List<RequisicaoSaida> registros = repositorio.SelecionarTodos();

        foreach (RequisicaoSaida r in registros)
        {
            Console.WriteLine("Id: {0} | Paciente: {1} | Data: {2}",
                r.Id, r.Pacientes.Nome, r.Data.ToShortDateString());

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                "Id", "Medicamento", "Qtd"
            );

            foreach (MedicamentoPrescrito mp in r.MedicamentosPrescritos)
            {
                Console.WriteLine(
                    "{0, -7} | {1, -20} | {2, -10}",
                    mp.Medicamento.Id, mp.Medicamento.Nome, mp.Quantidade
                );
            }

            Console.WriteLine("---------------------------------");
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override RequisicaoSaida ObterDadosCadastrais()
    {
        VisualizarPacientes();

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do paciente: ");
        int idPacientes = Convert.ToInt32(Console.ReadLine());

        Pacientes pacientes = repositorioPacientes.SelecionarPorId(idPacientes)!;

        List<MedicamentoPrescrito> medicamentosPrescritos = [];



        while (true)
        {

            VisualizarMedicamentos();

            Console.WriteLine("---------------------------------");

            Console.Write("Digite o ID do medicamento que deseja requisitar: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            if (idMedicamento == 0)

                break;

            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento)!;

            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            medicamentosPrescritos.Add(new MedicamentoPrescrito(medicamento, quantidade));
        }
        return new RequisicaoSaida(pacientes, medicamentosPrescritos);
    }

    private void VisualizarPacientes()
    {
        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -17} | {4, -14}",
            "Id", "Nome", "Telefone", "Cartão SUS", "CPF"
        );

        List<Pacientes> registros = repositorioPacientes.SelecionarTodos();

        foreach (Pacientes p in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -17} | {4, -14}",
                p.Id, p.Nome, p.Telefone, p.CartaoSUS, p.Cpf
            );
        }
    }

    private void VisualizarMedicamentos()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -10}",
            "Id", "Nome", "Fornecedor", "Descrição", "Estoque"
        );

        List<Medicamento> registros = repositorioMedicamento.SelecionarTodos();

        foreach (Medicamento m in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -10}",
                m.Id, m.Nome, m.Fornecedor.Nome, m.Descricao, m.QuantidadeEmEstoque
            );
        }
    }

    protected override bool ExistemDependenciasAtivasDoRegistro(int idRegistro)
    {
        return false;
    }
}
