using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPacientes;

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
