using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvalCore.Interface;
using EvalCore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvalCore.Controllers
{
    public class AdminRHController : Controller
    {

        private readonly IDireccionRepository _direccionRepository;
        private readonly IAdminrhInterface _adminrhInterface;

        public AdminRHController(IDireccionRepository direccionRepository,IAdminrhInterface adminrhInterface)
        {
            _direccionRepository = direccionRepository;
            _adminrhInterface = adminrhInterface;
        }

        // GET: AdminRHController
        public async Task<ActionResult> Index()
        {
            var dirclist =  await _direccionRepository.GetAll();
            var Deptolist =  await _direccionRepository.GetAllDepartaments();

            ViewBag.Listofdirec = dirclist;
            ViewBag.Listofdepto = Deptolist;

            return View();
        }

      
        public async Task<ActionResult> GetFuncList(string DIR_ID, string Idproy) /*(string keydir, string keypry)*/
        {
            int dir = Convert.ToInt32(DIR_ID);
            int pry = Convert.ToInt32(Idproy);

            var fundept = await _adminrhInterface.Obtenerfuncionariosxdepartamento(dir,pry);

            return Ok(fundept);
        }

        public JsonResult WelcomeNote(string tt)
        {
            int statId;
            List<DeptoViewDto> Listproy = new List<DeptoViewDto>();
            var Deptolist = _direccionRepository.GetProyectos();

            if (!string.IsNullOrEmpty(tt))
            {
                statId = Convert.ToInt32(tt);
                if(statId == 35 || statId == 9)
                {
                    Listproy = (List<DeptoViewDto>)Deptolist.Where(x => x.Dirid == statId).ToList();
                }
                else
                {
                    Listproy = (List<DeptoViewDto>)Deptolist.Where(x => x.Dirid == 0).ToList();
                }
              
            }
            return Json(Listproy);
        }

     

        // GET: AdminRHController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminRHController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminRHController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminRHController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminRHController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminRHController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminRHController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
