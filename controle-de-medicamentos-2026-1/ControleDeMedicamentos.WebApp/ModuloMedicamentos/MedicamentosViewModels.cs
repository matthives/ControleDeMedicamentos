using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentos.WebApp.ModuloMedicamentos;

public record FornecedorMedicamentoViewModel(
    int Id,
    string Nome
);

public record ListarMedicamentosViewModel(
    int Id,
    string Nome,
    string Descricao,
    string Fornecedor,
    int QuantidadeEmEstoque
);

public record CadastrarMedicamentosViewModel(
    string Nome,
    string Descricao,
    int FornecedorId
)
{
    public List<FornecedorMedicamentoViewModel> Fornecedores { get; init; } = [];
}

public record EditarMedicamentosViewModel(
    int Id,
    string Nome,
    string Descricao,
    int FornecedorId
)
{
    public List<FornecedorMedicamentoViewModel> Fornecedores { get; init; } = [];
}
