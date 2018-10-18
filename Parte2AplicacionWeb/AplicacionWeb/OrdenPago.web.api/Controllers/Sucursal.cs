using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdenPago.web.api.Controllers
{
    [ApiController]
    public class Sucursal : Controller
    {
        [HttpPost]
        [Route("sucursal/registrar")]
        [OpAtributoException]
        public void Registrar(lib.vm.Sucursal sucursal)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.Sucursal _bnSucursal = new lib.bn.Sucursal(_usuario))
            {
                _bnSucursal.Registrar(sucursal);
            }
        }

        [HttpPost]
        [Route("sucursal/actualizar")]
        [OpAtributoException]
        public void Actualizar(lib.vm.Sucursal sucursal)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.Sucursal _bnSucursal = new lib.bn.Sucursal(_usuario))
            {
                _bnSucursal.Actualizar(sucursal);
            }
        }

        [HttpPost]
        [Route("sucursal/eliminar")]
        [OpAtributoException]
        public void Eliminar(Guid id)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.Sucursal _bnBanco = new lib.bn.Sucursal(_usuario))
            {
                _bnBanco.Eliminar(id);
            }
        }

        [HttpGet]
        [Route("sucursal/listar/{banco}")]
        [OpAtributoException]
        public ActionResult<List<lib.vm.Sucursal>> Listar(Guid banco)
        {
            List<lib.vm.Sucursal> _resultado = new List<lib.vm.Sucursal>();
            using (lib.bn.Sucursal _bnSucursal = new lib.bn.Sucursal())
            {
                _resultado = _bnSucursal.Listar(banco);
            }
            return _resultado;
        }

        [HttpGet]
        [Route("sucursal/obtener/{id}")]
        [OpAtributoException]
        public ActionResult<lib.vm.Sucursal> Obtener(Guid id)
        {
            lib.vm.Sucursal _resultado = new lib.vm.Sucursal();
            using (lib.bn.Sucursal _bnSucursal = new lib.bn.Sucursal())
            {
                _resultado = _bnSucursal.Obtener(id);
            }
            return _resultado;
        }

        [HttpGet]
        [Route("sucursal/filtrar/{nombreBanco}")]
        [OpAtributoException]
        public ActionResult<List<lib.vm.Sucursal>> filtrar(string nombreBanco)
        {
            List<lib.vm.Sucursal> _resultado = new List<lib.vm.Sucursal>();
            using (lib.bn.Sucursal _bnSucursal = new lib.bn.Sucursal())
            {
                _resultado = _bnSucursal.Filtrar(nombreBanco);
            }
            return _resultado;
        }
    }
}
