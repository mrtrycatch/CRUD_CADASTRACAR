using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastracar.DATA.Models;
using Cadastracar.DATA.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Data.SqlClient;

namespace Cadastracar.WEB.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaService oCategoriaService = new CategoriaService();

        public IActionResult Index()
        {

            if (TempData["errorMsg"] != null)
            {
                ViewBag.MsgError = TempData["errorMsg"].ToString();
            }
            

            List<Categoria> oListCategoria = oCategoriaService.RpCategoria.SelecionarTodos();
            return View(oListCategoria);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria model)
        {
            try
            {
                oCategoriaService.RpCategoria.Incluir(model);
            }
            catch (Exception Ex)
            {

            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            try
            {
                Categoria oCategoria = oCategoriaService.RpCategoria.SelecionarPk(id);
                return View(oCategoria);
            }
            catch (Exception Ex)
            {

            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Categoria model)
        {
            try
            {
                oCategoriaService.RpCategoria.Alterar(model);
            }
            catch (Exception Ex)
            {

            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            try
            {
                oCategoriaService.RpCategoria.Excluir(id);
            }
            catch (Exception Ex)
            {

                if (Ex.InnerException is SqlException SqlEx)
                {

                    if (SqlEx.Number == 547)
                    {
                        TempData["errorMsg"] = "Não foi possível excluir esta categoria. Ela já esta sendo usada para um ou mais veículos.";
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
