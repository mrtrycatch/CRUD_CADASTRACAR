using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastracar.DATA.Models;
using Cadastracar.DATA.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Cadastracar.WEB.Controllers
{
    public class FuncionarioController : Controller
    {
        private FuncionarioService oFuncionarioService = new FuncionarioService();

        public IActionResult Index()
        {

            if (TempData["errorMsg"] != null)
            {
                ViewBag.MsgError = TempData["errorMsg"].ToString();
            }

            

            List<Funcionario> oListFuncionario = oFuncionarioService.RpFuncionario.SelecionarTodos();
            return View(oListFuncionario);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Funcionario model)
        {

            try
            {
                oFuncionarioService.RpFuncionario.Incluir(model);
            }
            catch (Exception Ex)
            {

                if (Ex.InnerException is SqlException SqlEx)
                {

                    if (SqlEx.Number == 2627)
                    {
                        if (oFuncionarioService.RpFuncionario.SelecionarByCPF(model.Cpf) != null)
                        {
                            ViewBag.MsgError = "Não foi possível incluir este funcionário. Já existe um funcionário com o CPF informado.";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.MsgError = "Ocorreu um erro durante a exclusão da categoria";
                    }


                }

            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            try
            {
                Funcionario oFuncionario = oFuncionarioService.RpFuncionario.SelecionarPk(id);
                return View(oFuncionario);
            }
            catch (Exception Ex)
            {

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Funcionario model)
        {
            try
            {
                oFuncionarioService.RpFuncionario.Alterar(model);
            }
            catch (Exception Ex)
            {

                if (Ex.InnerException is SqlException SqlEx)
                {

                    if (SqlEx.Number == 2627)
                    {
                        if (oFuncionarioService.RpFuncionario.SelecionarByCPF(model.Cpf) != null)
                        {
                            ViewBag.MsgError = "Não foi possível alterar o CPF do funcionário. Já existe um funcionário com o CPF informado.";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.MsgError = "Ocorreu um erro durante a exclusão da categoria";
                    }


                }

            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            try
            {
                Funcionario oFuncionario = oFuncionarioService.RpFuncionario.SelecionarPk(id);
                return View(oFuncionario);
            }
            catch (Exception Ex)
            {

            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            try
            {
                oFuncionarioService.RpFuncionario.Excluir(id);
            }
            catch (Exception Ex)
            {

                if (Ex.InnerException is SqlException SqlEx)
                {

                    if (SqlEx.Number == 547)
                    {
                        TempData["errorMsg"] = "Não foi possível excluir este funcionário. Ele é responsável por um ou mais veículos.";
                    }
                    else
                    {
                        TempData["errorMsg"] = "Ocorreu um erro durante a exclusão da categoria";
                    }


                }

            }

            return RedirectToAction("Index");
        }

        
    }
}
