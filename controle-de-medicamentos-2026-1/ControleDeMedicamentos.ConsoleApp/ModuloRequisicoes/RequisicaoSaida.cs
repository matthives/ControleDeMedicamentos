using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class RequisicaoSaida : EntidadeBase
{
    public Pacientes Pacientes { get; set; } = null!;
    public List<MedicamentoPrescrito> MedicamentosPrescritos { get; set; } = [];
    public DateTime Data { get; set; } = DateTime.Now;

    public RequisicaoSaida() { }

    public RequisicaoSaida(Pacientes pacientes, List<MedicamentoPrescrito> medicamentosPrescritos) : this()
    {
        Pacientes = pacientes;
        MedicamentosPrescritos = medicamentosPrescritos;

        foreach (MedicamentoPrescrito mp in MedicamentosPrescritos)
            mp.Medicamento.RegistrarRequisicaoSaida(this);
    }
    public int ObterQuantidade(Medicamento medicamento)
    {
        foreach (MedicamentoPrescrito mp in MedicamentosPrescritos)
        {
            if (mp.Medicamento.Id == medicamento.Id)
                return mp.Quantidade;
        }

        return 0;
    }
    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Pacientes == null)
            erros.Add("O campo \"Paciente\" deve ser preenchido.");

        if (MedicamentosPrescritos.Count == 0)
            erros.Add("É necessário selecionar ao menos um medicamento.");

        foreach (MedicamentoPrescrito mp in MedicamentosPrescritos)
        {
            if (mp.Medicamento == null)
            {
                erros.Add("O campo \"Medicamento\" deve ser preenchido.");
            }
            else
            {
                if (mp.Quantidade <= 0)
                    erros.Add($"A \"Quantidade\" do medicamento \"{mp.Medicamento.Nome}\" deve ser maior que zero.");

                if (mp.Medicamento.QuantidadeEmEstoque < 0)
                    erros.Add($"Não há estoque suficiente para o medicamento \"{mp.Medicamento.Nome}\".");
            }
        }

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        RequisicaoSaida requisicaoAtualizada = (RequisicaoSaida)entidadeAtualizada;

        Pacientes = requisicaoAtualizada.Pacientes;
        MedicamentosPrescritos = requisicaoAtualizada.MedicamentosPrescritos;
    }
}
