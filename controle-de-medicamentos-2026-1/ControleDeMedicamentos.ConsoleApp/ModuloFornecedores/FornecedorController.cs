using System.Runtime.CompilerServices;
using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace ControleDeMedicamentos.WebApp.ModuloFornecedores;

public sealed class FornecedorController
{
    private readonly RepositorioFornecedorEmArquivo repositorio;
    public FornecedorController()
    {
        ContextoJson contextoJson = new ContextoJson();

        contextoJson.Carregar();

        repositorio = new RepositorioFornecedorEmArquivo(contextoJson);
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Fornecedor> fornecedores = repositorio.SelecionarTodos();

        return View(fornecedores);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(string nome, string telefone, string cnpj)
    {
        Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);

        repositorio.Cadastrar(fornecedor);

        return RedirectToAction(nameof(Listar));
    }
}
