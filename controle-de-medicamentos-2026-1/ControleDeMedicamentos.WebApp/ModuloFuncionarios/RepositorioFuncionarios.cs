using ControleDeMedicamentos.WebApp.Compartilhado;
using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;

namespace ControleDeMedicamentos.WebApp.ModuloFuncionarios;

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
