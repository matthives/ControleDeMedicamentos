using System.Text.RegularExpressions;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPacientes;

public class Pacientes : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CartaoDoSus { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;

    public Pacientes() { }

    public Pacientes(string nome, string telefone, string cartaoDoSus, string cpf) : this()
    {
        Nome = nome;
        Telefone = telefone;
        CartaoDoSus = cartaoDoSus;
        Cpf = cpf;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (!Regex.IsMatch(Telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$"))
            erros.Add("O campo \"Telefone\" deve estar no formato (DDD) 90000-0000.");

        if (!Regex.IsMatch(CartaoDoSus, @"^\d{3}\.?\d{3}\.?\d{3}\/?\d{3}-?\d{3}$"))
            erros.Add("O campo \"Cartao do SUS\" deve conter 15 dígitos.");

        if (!Regex.IsMatch(Cpf, @"^\d{3}\.?\d{3}\.?\d{3}\/?\d{2}$"))
            erros.Add("O campo \"CPF\" deve conter 11 dígitos.");

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Pacientes pacientesAtualizado = (Pacientes)entidadeAtualizada;

        Nome = pacientesAtualizado.Nome;
        Telefone = pacientesAtualizado.Telefone;
        CartaoDoSus = pacientesAtualizado.CartaoDoSus;
        Cpf = pacientesAtualizado.Cpf;
    }
}
