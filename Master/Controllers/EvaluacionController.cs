using EvalCore.Data;
using EvalCore.Interface;
using EvalCore.Models;
using EvalCore.Models.ViewModels;
using EvalCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalCore.Controllers
{
    public class EvaluacionController : Controller
    {
        //Implementacion de interfaces
        private readonly ApplicationDbContext _context; // acceso a base de datos
        private readonly IFuncionarioRepository _funcionariosRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IDireccionRepository _direccionRepository;
        private readonly IEvaluacionInterface _evaluacionInterface;


        //Inyeccion de depepencias de capa repositorio
        public EvaluacionController(ApplicationDbContext context,
            IFuncionarioRepository funcionariosRepository,
            ICargoRepository cargoRepository,
            IDireccionRepository direccionRepository,
            IEvaluacionInterface evaluacionInterface
            )
        {
            _context = context;
            _funcionariosRepository = funcionariosRepository;
            _cargoRepository = cargoRepository;
            _direccionRepository = direccionRepository;
            _evaluacionInterface = evaluacionInterface;
        }


        // GET: EvaluacionController
        public ActionResult Index()
        {
            //Cargar catalogos 


            return View();
        }

        // GET: EvaluacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EvaluacionController/Create
        public async Task<ActionResult> Create()
        {


            #region Inicializar valores
            //Inicializar fechas para periodo, En - Jn {1er periodo}, Jl - Dc {2do periodo}
            int fcActual = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            var firstDay = ""; var lastDay = "";
            if (fcActual <= 6)
            {
                firstDay = new DateTime(year, 1, 1).ToString("dd/MM/yyyy");
                lastDay = new DateTime(year, 6, 30).ToString("dd/MM/yyyy");

            }
            else if (fcActual >= 7)
            {
                firstDay = new DateTime(year, 7, 1).ToString("dd/MM/yyyy");
                lastDay = new DateTime(year, 12, 31).ToString("dd/MM/yyyy");
            }



            #endregion

            #region Catalogos 

            var cargolist = await _cargoRepository.GetAll();
            var dirclist = await _direccionRepository.GetAll();
            var Deptolist = await _direccionRepository.GetAllDepartaments();

            var questionslist = await _funcionariosRepository.GetAllQuestions();
            var funclist = await _funcionariosRepository.GetAll();



            ViewBag.Listofcarg = cargolist;
            ViewBag.Listofdirec = dirclist;
            ViewBag.Listofdepto = Deptolist;

            //ViewBag.Listofqst = questionslist;
            ViewBag.Listoffunc = funclist;

            //Consulta periodo estatus activo 
            var PrdQuery = _context.Evaluacion.Where(x => x.Estado == true).Select(p => new { p.KeyEval, p.Periodoinicial, p.Periodofinal }).ToList();
            ViewBag.Prd = PrdQuery;
            //asignar dias a cajas de texto solo ilustrativo
            foreach (var it in PrdQuery)
            {
                ViewBag.firstDay = it.Periodoinicial.Value.ToShortDateString();
                ViewBag.lastDay = it.Periodofinal.Value.ToShortDateString();
            }

            //
            //Preguntas
            ViewBag.Q1 = questionslist.Where(x => x.Keypond == 1);
            ViewBag.Q2 = questionslist.Where(x => x.Keypond == 2);
            ViewBag.Q3 = questionslist.Where(x => x.Keypond == 3);
            ViewBag.Q4 = questionslist.Where(x => x.Keypond == 4);

            #endregion

            return View();
        }

        [HttpPost]
        public ActionResult Calculate(IFormCollection collection)
        {
            int cbx = Convert.ToInt32(collection["CarId"].ToString());

            StringBuilder sbInterest = new StringBuilder();
            sbInterest.Append("<b>Cargo :</b> " + cbx);
            return Content(sbInterest.ToString());
        }

        // POST: EvaluacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            int dtpproy = 0;
            int[] PregArray = new int[25];
            List<Detallepregunta> Lst = new List<Detallepregunta>();
            try
            {

                Evaluacion ev = new Evaluacion();
                Evaluaciodetalle edv = new Evaluaciodetalle();
                Detallepregunta dtp = new Detallepregunta();

                //collection obtiene los valores del formulario por medio de la propiedad HTML  { name="XXX" }

                //campos Tab1

                #region Captura de valores

                //KeyPeriodo
                int keyprd = Convert.ToInt32(collection["Prdcbx"].ToString());

                int tpfun = Convert.ToInt32(collection["tipofun"].ToString());
                int func = Convert.ToInt32(collection["Fnccbx"].ToString());
                string Fchactual = collection["fcactual"].ToString();
                int cargo = Convert.ToInt32(collection["cbxcrg1"].ToString());

                int direc = Convert.ToInt32(collection["Dircbx"].ToString());
                //validar si es nulo Dptocbx
                if (collection["Dptocbx"] == "Dptocbx")
                {
                    dtpproy = Convert.ToInt32(collection["Dptocbx"].ToString());
                }
                else
                {
                    dtpproy = 0;
                }


                string fcIni = collection["startime"].ToString();
                string fcFin = collection["endtime"].ToString();

                int eval = Convert.ToInt32(collection["Evlcbx"].ToString());
                int crgeval = Convert.ToInt32(collection["cbxcrg2"].ToString());

                int ttq1 = Convert.ToInt32(collection["ttq1"].ToString());
                int ttq2 = Convert.ToInt32(collection["ttq2"].ToString());
                int ttq3 = Convert.ToInt32(collection["ttq3"].ToString());
                int ttq4 = Convert.ToInt32(collection["ttq4"].ToString());

                string ttpond = collection["txtPond"].ToString();
                int ttqfinal = Convert.ToInt32(collection["ttqfinal"].ToString());

                //preguntas texto
                string fztxt = collection["fztxt"].ToString();
                string debtxt = collection["debtxt"].ToString();
                string comtxt = collection["comtxt"].ToString();
                string captxt = collection["captxt"].ToString();
                //--Fin pregunas texto
                #endregion


                #region Guardar Evaluacion 
                // Se dejo de utilizar ya que ahora se carga por un combo el campo Evaluacion cuando sea true, pero se retoma el ID por medio de {keyprd}

                //--Save Evaluaciones
                //ev.Periodoinicial = Convert.ToDateTime(fcIni);
                //ev.Periodofinal = Convert.ToDateTime(fcFin);
                //ev.Fecha = Convert.ToDateTime(Fchactual);
                //ev.Usuario = "RRHH_TEST";
                //_evaluacionInterface.InsertarEvaluacion(ev);
                //_context.SaveChanges();
                //int idevl = ev.KeyEval;//ultimo ID
                //---
                #endregion

                #region Guardar Detalle Evaluacion

                //--Save Evaluacion Detalle
                //se cambia idevl por keyprd ya que este viene de tbl.evaluacion
                //y asi solamente se insertara en DetalleEvalucion y DetallePreguntas
                edv.Fkeva = keyprd;
                edv.Fktipoeva = tpfun;
                edv.Blq1 = ttq1;
                edv.Blq2 = ttq2;
                edv.Blq3 = ttq3;
                edv.Blq4 = ttq4;
                edv.Bltotal = ttqfinal;
                edv.Pntescala = ttpond;
                edv.FunId = func;
                edv.CarId = cargo;
                edv.DirId = direc;
                edv.Rtfort = fztxt;
                edv.Rtdeb = debtxt;
                edv.Rtcomp = comtxt;
                edv.Rtcapc = captxt;
                edv.Fkfunceval = eval;
                _evaluacionInterface.InsertarEvaluacionDetalle(edv);
                _context.SaveChanges();
                int idEvdt = edv.KeyEvdt;
                //-- End

                #endregion

                //--Fin campos Tab1

                #region preguntas cbx

                //preguntas cbx
                int cb1Q1 = Convert.ToInt32(collection["cb1Q1"].ToString());
                int cb1Q2 = Convert.ToInt32(collection["cb1Q2"].ToString());
                int cb1Q3 = Convert.ToInt32(collection["cb1Q3"].ToString());
                int cb1Q4 = Convert.ToInt32(collection["cb1Q4"].ToString());
                int cb1Q5 = Convert.ToInt32(collection["cb1Q5"].ToString());
                int cb1Q6 = Convert.ToInt32(collection["cb1Q6"].ToString());
                int cb1Q7 = Convert.ToInt32(collection["cb1Q7"].ToString());
                int cb1Q8 = Convert.ToInt32(collection["cb1Q8"].ToString());

                PregArray[0] = cb1Q1;
                PregArray[1] = cb1Q2;
                PregArray[2] = cb1Q3;
                PregArray[3] = cb1Q4;
                PregArray[4] = cb1Q5;
                PregArray[5] = cb1Q6;
                PregArray[6] = cb1Q7;
                PregArray[7] = cb1Q8;

                int cb2Q9 = Convert.ToInt32(collection["cb2Q9"].ToString());
                int cb2Q10 = Convert.ToInt32(collection["cb2Q10"].ToString());
                int cb2Q11 = Convert.ToInt32(collection["cb2Q11"].ToString());
                int cb2Q12 = Convert.ToInt32(collection["cb2Q12"].ToString());

                PregArray[8] = cb2Q9;
                PregArray[9] = cb2Q10;
                PregArray[10] = cb2Q11;
                PregArray[11] = cb2Q12;

                int cb3Q13 = Convert.ToInt32(collection["cb3Q13"].ToString());
                int cb3Q14 = Convert.ToInt32(collection["cb3Q14"].ToString());
                int cb3Q15 = Convert.ToInt32(collection["cb3Q15"].ToString());
                int cb3Q16 = Convert.ToInt32(collection["cb3Q16"].ToString());
                int cb3Q17 = Convert.ToInt32(collection["cb3Q17"].ToString());
                int cb3Q18 = Convert.ToInt32(collection["cb3Q18"].ToString());
                int cb3Q19 = Convert.ToInt32(collection["cb3Q19"].ToString());

                PregArray[12] = cb3Q13;
                PregArray[13] = cb3Q14;
                PregArray[14] = cb3Q15;
                PregArray[15] = cb3Q16;
                PregArray[16] = cb3Q17;
                PregArray[17] = cb3Q18;
                PregArray[18] = cb3Q19;

                int cb4Q20 = Convert.ToInt32(collection["cb4Q20"].ToString());
                int cb4Q21 = Convert.ToInt32(collection["cb4Q21"].ToString());
                int cb4Q22 = Convert.ToInt32(collection["cb4Q22"].ToString());
                int cb4Q23 = Convert.ToInt32(collection["cb4Q23"].ToString());
                int cb4Q24 = Convert.ToInt32(collection["cb4Q24"].ToString());
                int cb4Q25 = Convert.ToInt32(collection["cb4Q25"].ToString());

                PregArray[19] = cb4Q20;
                PregArray[20] = cb4Q21;
                PregArray[21] = cb4Q22;
                PregArray[22] = cb4Q23;
                PregArray[23] = cb4Q24;
                PregArray[24] = cb4Q25;

                //--Fin preguntas CBX
                #endregion

                #region Guardar preguntas
                //---> se guardan preguntas para posterior ser mostradas y asi identificar que respondio cada persona
                for (int i = 0; i < PregArray.Length; i++)
                {
                    var ent = new Detallepregunta();
                    ent.Fkdtevalua = idEvdt;
                    ent.FkPreguntaId = i + 1;
                    ent.Puntpregunta = PregArray[i];
                    Lst.Add(ent);
                }
                _evaluacionInterface.SaveDetallePregunta(Lst);

                #endregion



         

                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: EvaluacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EvaluacionController/Edit/5
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

        // GET: EvaluacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EvaluacionController/Delete/5
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
