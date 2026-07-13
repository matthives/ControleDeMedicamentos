using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;

public class RepositorioFuncionarios : RepositorioBaseEmArquivo<Funcionarios>
{
    public RepositorioFuncionarios(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Funcionarios> ObterRegistros()
    {
        return contexto.Funcionarios;
    }
}
