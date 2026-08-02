using ControleDeMedicamentos.WebApp.Compartilhado

using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using Microsoft.AspNetCore.Mvc;


Public sealed class FuncionarioController : Controller
{
    private readonly RepositorioFuncionarios repositorioFuncionarios

    public FuncionarioController()
    {
        ContextoJson contexto
    }


    [HttpGet]

    public ActionResult Listar()
    {
        List<Funcionario> funcionarios
    }


}
