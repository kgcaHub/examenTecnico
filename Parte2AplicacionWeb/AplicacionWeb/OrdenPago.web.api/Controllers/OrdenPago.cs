using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdenPago.web.api.Controllers
{
    [ApiController]
    public class OrdenPago : Controller
    {
        [HttpPost]
        [Route("ordenPago/registrar")]
        [OpAtributoException]
        public void Registrar(lib.vm.OrdenPago ordenPago)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.OrdenPago _bnOrdenPago = new lib.bn.OrdenPago(_usuario))
            {
                _bnOrdenPago.Registrar(ordenPago);
            }
        }

        [HttpPost]
        [Route("ordenPago/actualizar")]
        [OpAtributoException]
        public void Actualizar(lib.vm.OrdenPago ordenPago)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.OrdenPago _bnOrdenPago = new lib.bn.OrdenPago(_usuario))
            {
                _bnOrdenPago.Actualizar(ordenPago);
            }
        }

        [HttpPost]
        [Route("ordenPago/eliminar")]
        [OpAtributoException]
        public void Eliminar(Guid id)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.OrdenPago _ordenPago = new lib.bn.OrdenPago(_usuario))
            {
                _ordenPago.Eliminar(id);
            }
        }

        [HttpGet]
        [Route("ordenPago/listar/{sucursal}")]
        [OpAtributoException]
        public ActionResult<List<lib.vm.OrdenPago>> Listar(Guid sucursal)
        {
            List<lib.vm.OrdenPago> _resultado = new List<lib.vm.OrdenPago>();
            using (lib.bn.OrdenPago _bnOrdenPago = new lib.bn.OrdenPago())
            {
                _resultado = _bnOrdenPago.Listar(sucursal);
            }
            return _resultado;
        }

        [HttpGet]
        [Route("ordenPago/obtener/{id}")]
        [OpAtributoException]
        public ActionResult<lib.vm.OrdenPago> Obtener(Guid id)
        {
            lib.vm.OrdenPago _resultado = new lib.vm.OrdenPago();
            using (lib.bn.OrdenPago _bnBanco = new lib.bn.OrdenPago())
            {
                _resultado = _bnBanco.Obtener(id);
            }
            return _resultado;
        }

        [HttpGet]
        [Route("ordenPago/filtrar/{nombreSucursal}/{moneda}")]
        [OpAtributoException]
        public ActionResult<IEnumerable<lib.vm.OrdenPago>> filtrar(string nombreSucursal, string moneda)
        {
            List<lib.vm.OrdenPago> _resultado = new List<lib.vm.OrdenPago>();
            using (lib.bn.OrdenPago _bnOrdenPago = new lib.bn.OrdenPago())
            {
                _resultado = _bnOrdenPago.Filtrar(nombreSucursal, moneda);
            }
            return new JsonResult(_resultado);
        }
    }
}
