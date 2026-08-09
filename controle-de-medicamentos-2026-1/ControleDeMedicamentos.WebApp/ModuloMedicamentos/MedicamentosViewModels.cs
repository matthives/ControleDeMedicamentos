using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentos.WebApp.ModuloMedicamentos;

public record ListarMedicamentosViewModel(int Id, string Nome, string Descricao, string Fornecedor, string QuantidadeEmEstoque);

public record CadastrarMedicamentosViewModel(
    string Nome,
    string Descricao,
    string FornecedorId
);

public record EditarMedicamentosViewModel(
    int Id,
    string Nome,
    string Descricao,
    string FornecedorId
);

public record ExcluirMedicamentosViewModel(
    int Id,
    string Nome
);
