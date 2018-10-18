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
        public void Registrar(lib.vm.Banco banco)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.OrdenPago _bnOrdenPago = new lib.bn.OrdenPago(_usuario))
            {
                _bnOrdenPago.Registrar(banco);
            }
        }

        [HttpPost]
        [Route("ordenPago/actualizar")]
        public void Actualizar(lib.vm.Banco banco)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.OrdenPago _bnOrdenPago = new lib.bn.OrdenPago(_usuario))
            {
                _bnOrdenPago.Actualizar(banco);
            }
        }

        [HttpPost]
        [Route("ordenPago/eliminar")]
        public void Eliminar(Guid id)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.OrdenPago _ordenPago = new lib.bn.OrdenPago(_usuario))
            {
                _ordenPago.Eliminar(id);
            }
        }

        [HttpGet]
        [Route("ordenPago/listar")]
        public ActionResult<List<lib.vm.Banco>> Listar()
        {
            List<lib.vm.Banco> _resultado = new List<lib.vm.Banco>();
            //using (lib.bn.Banco _bnBanco = new lib.bn.Banco())
            //{
            //    _resultado = _bnBanco.Listar();
            //}

            for (int i = 0; i < 5; i++)
            {
                lib.vm.Banco _banco = new lib.vm.Banco();
                _banco.Id = Guid.NewGuid();
                _banco.Nombre = "Banco de la Nación";
                _resultado.Add(_banco);
            }
            return _resultado;
        }

        [HttpGet]
        [Route("ordenPago/obtener/{id}")]
        public ActionResult<lib.vm.Banco> Obtener(Guid id)
        {
            lib.vm.Banco _resultado = new lib.vm.Banco();
            //using (lib.bn.Banco _bnBanco = new lib.bn.Banco())
            //{
            //    _resultado = _bnBanco.Obtener(id);
            //}
            _resultado.Nombre = "Banco pichincha";
            _resultado.Direccion = "Avenida siempre viva 134";
            _resultado.FechaRegistro = DateTime.Now.ToString("dd/MM/yyyy");

            return _resultado;
        }

        [HttpGet]
        [Route("ordenPago/filtrar/{nombreSucursal}/{moneda}")]
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
