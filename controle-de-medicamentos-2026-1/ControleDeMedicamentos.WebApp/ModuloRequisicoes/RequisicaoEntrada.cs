using ControleDeMedicamentos.WebApp.Compartilhado;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

public class RequisicaoEntrada : EntidadeBase
{
    public Medicamento Medicamento { get; set; } = null!;
    public Funcionarios Funcionarios { get; set; } = null!;
    public int Quantidade { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;

    public RequisicaoEntrada() { }

    public RequisicaoEntrada(Medicamento medicamento, int quantidade, Funcionarios funcionario) : this()
    {
        Medicamento = medicamento;
        Quantidade = quantidade;
        Funcionarios = funcionario;

        medicamento.RegistrarRequisicao(this);
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Medicamento == null)
            erros.Add("O campo \"Medicamento\" deve ser preenchido.");

        if (Funcionarios == null)
            erros.Add("O campo \"Funcionário\" deve ser preenchido.");

        if (Quantidade <= 0)
            erros.Add("A \"Quantidade\" deve ser maior que zero.");

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        RequisicaoEntrada requisicaoAtualizada = (RequisicaoEntrada)entidadeAtualizada;

        Medicamento = requisicaoAtualizada.Medicamento;
        Quantidade = requisicaoAtualizada.Quantidade;
        Funcionarios = requisicaoAtualizada.Funcionarios;
    }
}
