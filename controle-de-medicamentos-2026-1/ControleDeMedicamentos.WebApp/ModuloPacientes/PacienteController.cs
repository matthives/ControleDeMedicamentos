using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.WebApp.ModuloPacientes;

public class PacienteController : Controller
{
    private readonly RepositorioPacientesEmArquivo repositorio;

    public PacienteController(RepositorioPacientesEmArquivo repositorio)
    {
        this.repositorio = repositorio;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarPacienteViewModel> viewModels = [];

        foreach (Pacientes p in repositorio.SelecionarTodos())
        {
            ListarPacienteViewModel viewModel = new ListarPacienteViewModel(
                p.Id,
                p.Nome,
                p.Telefone,
                p.CartaoSUS
            );

            viewModels.Add(viewModel);
        }

        return View(viewModels);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarPacienteViewModel viewModel = new CadastrarPacienteViewModel(
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarPacienteViewModel viewModel)
    {
        Pacientes pacientes = new Pacientes(
            viewModel.Nome,
            viewModel.Telefone,
            viewModel.CartaoSUS,
            viewModel.Cpf
        );

        repositorio.Cadastrar(pacientes);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(int id)
    {
        Pacientes? pacientes = repositorio.SelecionarPorId(id);

        if (pacientes == null)
            return NotFound();

        EditarPacienteViewModel viewModel = new EditarPacienteViewModel(
            id,
            pacientes.Nome,
            pacientes.Telefone,
            pacientes.CartaoSUS,
            pacientes.Cpf
        );

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Editar(EditarPacienteViewModel viewModel)
    {
        Pacientes pacienteAtualizado = new Pacientes(
            viewModel.Nome,
            viewModel.Telefone,
            viewModel.CartaoSUS,
            viewModel.Cpf
        );

        bool conseguiuEditar = repositorio.Editar(viewModel.Id, pacienteAtualizado);

        if (!conseguiuEditar)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(int id)
    {
        Pacientes? pacientes = repositorio.SelecionarPorId(id);

        if (pacientes == null)
            return NotFound();

        ExcluirPacienteViewModel viewModel = new ExcluirPacienteViewModel(
            id,
            pacientes.Nome
        );

        return View(viewModel);
    }

    [HttpPost]
    [ActionName("Excluir")]
    public ActionResult ConfirmarExclusao(int id)
    {
        bool conseguiuExcluir = repositorio.Excluir(id);

        if (!conseguiuExcluir)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }
}
