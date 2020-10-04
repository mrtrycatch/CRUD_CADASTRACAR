using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastracar.DATA.Models;
using Cadastracar.DATA.Repositories;
using Cadastracar.DATA.Services;
using Cadastracar.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Cadastracar.WEB.Controllers
{
    public class VeiculoController : Controller
    {
        private VeiculoService oVeiculoService = new VeiculoService();
        public IActionResult Index()
        {
            List<VwVeiculo> oListVwVeiculos = oVeiculoService.RpVeiculo.SelecionarTodosVw();
            return View(oListVwVeiculos);
        }

        public IActionResult Create()
        {
            ViewBag.oListCategoria = oVeiculoService.RpCategoria.SelecionarTodos();
            ViewBag.oListFuncionario = oVeiculoService.RpFuncionario.SelecionarTodos();

            return View();
        }

        [HttpPost]
        public IActionResult Create(VeiculoViewModel model)
        {

            ViewBag.oListCategoria = oVeiculoService.RpCategoria.SelecionarTodos();
            ViewBag.oListFuncionario = oVeiculoService.RpFuncionario.SelecionarTodos();

            Veiculo oVeiculo = model.oVeiculo;


            if (!ViewData.ModelState.IsValid)
            {
                return View();
            }


            try
            {
                oVeiculoService.RpVeiculo.Incluir(oVeiculo);
            }
            catch (Exception Ex)
            {

                if (Ex.InnerException is SqlException SqlEx)
                {

                    if (SqlEx.Number == 2627)
                    {
                        if (oVeiculoService.RpVeiculo.SelecionarByPlaca(oVeiculo.VcoPlaca) != null)
                        {
                            ViewBag.MsgError = "Esta placa já foi cadastrada anteriormente para outro veículo. Favor, cadastrar com outra placa.";
                            return View();
                        }

                        if (oVeiculoService.RpVeiculo.SelecionarByFrota(oVeiculo.VcoFrota) != null)
                        {
                            ViewBag.MsgError = "Esta frota já foi cadastrada anteriormente para outro veículo. Favor, cadastrar com outra frota.";
                            return View();
                        }
                    }
                    else if(SqlEx.Number == 547)
                    {
                        if (oVeiculo.VcoAnoFabricacao > DateTime.Now.Year)
                        {
                            ViewBag.MsgError = "O ano de fabricação não pode ser depois do ano atual.";
                            return View();
                        }

                        if (oVeiculo.VcoDataAquisicao > DateTime.Now)
                        {
                            ViewBag.MsgError = "A data de aquisição não pode ser depois da data atual.";
                            return View();
                        }

                        if (oVeiculo.VcoPlaca.Length != 8)
                        {
                            ViewBag.MsgError = "Não foi possível cadastrar o veículo. A placa não contém dígitos suficiente.";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.MsgError = "Ocorreu um erro durante a exclusão da categoria";
                        return View();
                    }


                }

            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            ViewBag.oListCategoria = oVeiculoService.RpCategoria.SelecionarTodos();
            ViewBag.oListFuncionario = oVeiculoService.RpFuncionario.SelecionarTodos();

            Veiculo oVeiculo = oVeiculoService.RpVeiculo.SelecionarPk(id);

            VeiculoViewModel oVeiculoViewModel = new VeiculoViewModel();
            oVeiculoViewModel.oVeiculo = oVeiculo;
            oVeiculoViewModel.oCategoria = oVeiculoService.RpCategoria.SelecionarPk(oVeiculo.VcoCodCategoria);
            oVeiculoViewModel.oFuncionario = oVeiculoService.RpFuncionario.SelecionarPk(oVeiculo.VcoCodFuncResponsavel);
            

            return View(oVeiculoViewModel);
        }

        [HttpPost]
        public IActionResult Edit(VeiculoViewModel model)
        {

            ViewBag.oListCategoria = oVeiculoService.RpCategoria.SelecionarTodos();
            ViewBag.oListFuncionario = oVeiculoService.RpFuncionario.SelecionarTodos();

            Veiculo oVeiculo = model.oVeiculo;

            

            try
            {
                oVeiculoService.RpVeiculo.Alterar(oVeiculo);
            }
            catch (Exception Ex)
            {
                if (Ex.InnerException is SqlException SqlEx)
                {

                    if (SqlEx.Number == 2627)
                    {
                        List<Veiculo> oListVeiculoPlaca = (from p in oVeiculoService.RpVeiculo.SelecionarTodos() where p.VcoPlaca == oVeiculo.VcoPlaca && p.VcoCodigo != oVeiculo.VcoCodigo select p).ToList();
                        List<Veiculo> oListVeiculoFrota = (from p in oVeiculoService.RpVeiculo.SelecionarTodos() where p.VcoFrota == oVeiculo.VcoFrota && p.VcoCodigo != oVeiculo.VcoCodigo select p).ToList();

                        if (oListVeiculoPlaca.Count > 0)
                        {
                            ViewBag.MsgError = "Esta placa já foi cadastrada anteriormente para outro veículo. Favor, alterar com outra placa.";
                            return View();
                        }

                        if (oListVeiculoFrota.Count > 0)
                        {
                            ViewBag.MsgError = "Esta frota já foi cadastrada anteriormente para outro veículo. Favor, alterar com outra frota.";
                            return View();
                        }
                    }
                    else if (SqlEx.Number == 547)
                    {
                        if (oVeiculo.VcoAnoFabricacao > DateTime.Now.Year)
                        {
                            ViewBag.MsgError = "O ano de fabricação não pode ser depois do ano atual.";
                            return View();
                        }

                        if (oVeiculo.VcoDataAquisicao > DateTime.Now)
                        {
                            ViewBag.MsgError = "A data de aquisição não pode ser depois da data atual.";
                            return View();
                        }

                        if (oVeiculo.VcoPlaca.Length != 8)
                        {
                            ViewBag.MsgError = "Não foi possível alterar o veículo. A placa não contém dígitos suficiente.";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.MsgError = "Ocorreu um erro durante a exclusão da categoria";
                        return View();
                    }


                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Veiculo oVeiculo = oVeiculoService.RpVeiculo.SelecionarPk(id);
            Categoria oCategoria = oVeiculoService.RpCategoria.SelecionarPk(oVeiculo.VcoCodCategoria);
            Funcionario oFuncionario = oVeiculoService.RpFuncionario.SelecionarPk(oVeiculo.VcoCodFuncResponsavel);

            VeiculoViewModel oVeiculoViewModel = new VeiculoViewModel();
            oVeiculoViewModel.oCategoria = oCategoria;
            oVeiculoViewModel.oFuncionario = oFuncionario;
            oVeiculoViewModel.oVeiculo = oVeiculo;

            return View(oVeiculoViewModel);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                oVeiculoService.RpVeiculo.Excluir(id);
            }
            catch (Exception Ex)
            {
                
            }
            return RedirectToAction("Index");
        }

    }
}
