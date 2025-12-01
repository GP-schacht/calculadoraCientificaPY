using System;
using System.Linq;
using System.Web.Http;

namespace CalculadoraAPI.Controllers
{
    [RoutePrefix("api/calculos")]
    public class CalculosController : ApiController
    {
        private readonly Contexto _context = new Contexto();


        [HttpGet]
        [Route("testconexion")]
        public IHttpActionResult TestConexion()
        {
            try
            {
                using (var context = new Contexto())
                {
                    bool existe = context.Database.Exists();
                    int registros = context.OperacionesLog.Count();     
                    return Ok(new { ConexionValida = existe, Registros = registros });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        // GET: api/calculos
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTodos()
        {
            var operaciones = _context.OperacionesLog.ToList();
            return Ok(operaciones);
        }

        // GET: api/calculos/sumas
        [HttpGet]
        [Route("sumas")]
        public IHttpActionResult GetSumas()
        {
            var sumas = _context.OperacionesLog.Where(o => o.TipoOperacion == "Suma").ToList();
            return Ok(sumas);
        }

        // GET: api/calculos/restas
        [HttpGet]
        [Route("restas")]
        public IHttpActionResult GetRestas()
        {
            var restas = _context.OperacionesLog.Where(o => o.TipoOperacion == "Resta").ToList();
            return Ok(restas);
        }

        // GET: api/calculos/multiplicaciones
        [HttpGet]
        [Route("multiplicaciones")]
        public IHttpActionResult GetMultiplicaciones()
        {
            var multiplicaciones = _context.OperacionesLog.Where(o => o.TipoOperacion == "Multiplicación").ToList();
            return Ok(multiplicaciones);
        }

        // GET: api/calculos/divisiones
        [HttpGet]
        [Route("divisiones")]
        public IHttpActionResult GetDivisiones()
        {
            var divisiones = _context.OperacionesLog.Where(o => o.TipoOperacion == "División").ToList();
            return Ok(divisiones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
