using Back_prueba.Comun;
using Back_prueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_prueba.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Sucursal092023Controller : ControllerBase
    {
        private readonly TestDbContext _context;
        public Sucursal092023Controller(TestDbContext context)
        {
            _context = context;
        }

        [Route("CreateSucursal")]
        [HttpPost]
        [ActionName("CreateSucursal")]        
        public IActionResult CreateSucursal([FromBody] Models.Sucursal092023 sucursal_obj)
        {
            Utilitarios util = new Utilitarios();
            util.ConvertirPropiedadesAMayusculas(sucursal_obj);
            _context.Sucursal092023s.Add(sucursal_obj);
            _context.SaveChanges();
            return Ok();
        }

        [Route("EditSucursal")]
        [HttpPost]
        [ActionName("EditSucursal")]       
        public IActionResult EditSucursal([FromBody] Models.Sucursal092023 sucursal_obj)
        {
            Models.Sucursal092023 tToedit = _context.Sucursal092023s.Where(t => t.Codigo == sucursal_obj.Codigo).FirstOrDefault();
            if (tToedit == null) { return BadRequest("Sucursal no existe"); }

            tToedit.Descripcion = sucursal_obj.Descripcion;
            tToedit.Direccion = sucursal_obj.Direccion;
            tToedit.EsBorrado = sucursal_obj.EsBorrado;
            tToedit.Descripcion = sucursal_obj.Descripcion;
            tToedit.FechaModificacion = DateTime.Now;
            tToedit.CodigoMoneda = sucursal_obj.CodigoMoneda;
            tToedit.Identificacion = sucursal_obj.  Identificacion;

            _context.Sucursal092023s.Update(tToedit);
            _context.SaveChanges();
            return Ok();
        }

        [Route("GetSucursal")]
        [HttpGet]
        [ActionName("GetSucursal")]        
        public async Task<IActionResult> GetSucursal()
        {
            //return Ok(await _context.Sucursal092023s.Where(t => t.EsBorrado == false).ToListAsync());
            var sucursales = await _context.Sucursal092023s
            .Where(t => t.EsBorrado == false)
            .Select(sucursal => new
            {
                sucursal.Codigo,
                sucursal.Descripcion,
                sucursal.Direccion,
                sucursal.Identificacion,
                sucursal.FechaCreacion,
                sucursal.CodigoMoneda,
                sucursal.EsBorrado,
                sucursal.FechaModificacion,
                MonedaNombre = sucursal.CodigoMonedaNavigation != null ? sucursal.CodigoMonedaNavigation.Descripcion : null
            })
            .ToListAsync();

            return Ok(sucursales);
        }

        [Route("GetMoneda")]
        [HttpGet]
        [ActionName("GetMoneda")]        
        public async Task<IActionResult> GetMoneda()
        {
            return Ok(await _context.Moneda092023s.ToListAsync());
        }
    }
}
