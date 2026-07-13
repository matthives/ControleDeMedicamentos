using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class RequisicaoSaida : EntidadeBase
{
    public Medicamento Medicamento { get; set; } = null!;
    public int Quantidade { get; set; }
    public Pacientes Pacientes { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;


    public RequisicaoSaida() { }

    public RequisicaoSaida(Medicamento medicamento, Pacientes pacientes, int quantidade) : this()
    {
        Medicamento = medicamento;
        Pacientes = pacientes;
        Quantidade = quantidade;

        medicamento.RegistrarRequisicaoSaida(this);
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Medicamento == null)
            erros.Add("O campo \"Medicamento\" deve ser preenchido.");

        if (Pacientes == null)
            erros.Add("O campo \"Paciente\" deve ser preenchido.");

        if (Quantidade <= 0)
            erros.Add("A \"Quantidade\" deve ser maior que zero.");

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        RequisicaoSaida requisicaoAtualizada = (RequisicaoSaida)entidadeAtualizada;

        Medicamento = requisicaoAtualizada.Medicamento;
        Quantidade = requisicaoAtualizada.Quantidade;
        Pacientes = requisicaoAtualizada.Pacientes;
    }
}
