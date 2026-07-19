using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;
using ControleDeMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private readonly TelaFornecedor telaFornecedor;
    private readonly TelaPacientes telaPacientes;
    private readonly TelaRequisicaoSaida telaFuncionarios;
    private readonly TelaMedicamento telaMedicamento;
    private readonly TelaRequisicaoEntrada telaRequisicaoEntrada;
    private readonly TelaRequisicaoSaida telaRequisicaoSaida;


    public TelaPrincipal(ContextoJson contexto)
    {
        RepositorioFornecedorEmArquivo repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
        RepositorioPacientesEmArquivo repositorioPacientes = new RepositorioPacientesEmArquivo(contexto);
        RepositorioFuncionarios repositorioFuncionarios = new RepositorioFuncionarios(contexto);
        RepositorioMedicamentoEmArquivo repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
        RepositorioRequisicaoEntradaEmArquivo repositorioRequisicao = new RepositorioRequisicaoEntradaEmArquivo(contexto);
        RepositorioRequisicaoSaidaEmArquivo repositorioRequisicaoSaida = new RepositorioRequisicaoSaidaEmArquivo(contexto);


        telaFornecedor = new TelaFornecedor(repositorioFornecedor);
        telaPacientes = new TelaPacientes(repositorioPacientes);
        telaFuncionarios = new TelaFuncionarios(repositorioFuncionarios);
        telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);
        telaRequisicaoEntrada = new TelaRequisicaoEntrada(repositorioRequisicao, repositorioMedicamento);
        telaRequisicaoSaida = new TelaRequisicaoSaida(repositorioRequisicaoSaida, repositorioPacientes, repositorioMedicamento);

    }

    public ITelaOpcoes? ObterOpcaoMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Controle de Medicamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gestão de Fornecedores");
        Console.WriteLine("2 - Gestão de Pacientes");
        Console.WriteLine("2 - Gestão de Medicamentos");
        Console.WriteLine("2 - Gestão de Funcionários");
        Console.WriteLine("3 - Gestão de Requisições de Entrada");
        Console.WriteLine("2 - Gestão de Requisição de Saída");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return telaFornecedor;

        if (opcaoMenuPrincipal == "2")
            return telaPacientes;

        if (opcaoMenuPrincipal == "3")
            return telaMedicamento;

        if (opcaoMenuPrincipal == "4")
            return telaFuncionarios;

        if (opcaoMenuPrincipal == "5")
            return telaRequisicaoEntrada;

        if (opcaoMenuPrincipal == "6")
            return telaRequisicaoSaida;

        return null;
    }
}
