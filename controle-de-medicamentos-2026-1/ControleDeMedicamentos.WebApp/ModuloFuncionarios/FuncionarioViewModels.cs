using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentos.WebApp.ModuloFuncionarios;

public record ListarFuncionarioViewModel(int Id, string Nome, string Telefone, string Cpf);

public record CadastrarFuncionarioViewModel(
    string Nome,
    string Telefone,
    string Cpf
);

public record EditarFuncionarioViewModel(
    int Id,
    string Nome,
    string Telefone,
    string Cpf
);

public record ExcluirFuncionarioViewModel(
    int Id,
    string Nome
);
