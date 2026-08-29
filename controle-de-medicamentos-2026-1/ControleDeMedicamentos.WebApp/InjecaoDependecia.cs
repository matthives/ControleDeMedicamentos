using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.WebApp.ModuloFornecedores;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.ModuloPacientes;
using ControleDeMedicamentos.WebApp.ModuloRequisicoes;

public static class InjecaoDependecia
{
    public static void AddInfraestruturaEmJson(this IServiceCollection services)
    {
        services.AddScoped(_ =>
        {
            ContextoJson contexto = new ContextoJson();

            contexto.Carregar();

            return contexto;
        });

        services.AddScoped<RepositorioMedicamentoEmArquivo>();
        services.AddScoped<RepositorioFornecedorEmArquivo>();
        services.AddScoped<RepositorioFuncionarios>();
        services.AddScoped<RepositorioPacientesEmArquivo>();
        services.AddScoped<RepositorioRequisicaoEntradaEmArquivo>();
        services.AddScoped<RepositorioRequisicaoSaidaEmArquivo>();
    }
}
