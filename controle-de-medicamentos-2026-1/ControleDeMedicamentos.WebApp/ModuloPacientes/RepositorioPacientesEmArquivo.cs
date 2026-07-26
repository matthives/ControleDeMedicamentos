using ControleDeMedicamentos.WebApp.Compartilhado;
using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;

namespace ControleDeMedicamentos.WebApp.ModuloPacientes;

public class RepositorioPacientesEmArquivo : RepositorioBaseEmArquivo<Pacientes>
{
    public RepositorioPacientesEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Pacientes> ObterRegistros()
    {
        return contexto.Pacientes;
    }
}
