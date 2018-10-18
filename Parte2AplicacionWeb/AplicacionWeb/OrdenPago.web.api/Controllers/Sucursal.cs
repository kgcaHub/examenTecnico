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
        public void Registrar(lib.vm.Sucursal banco)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.Sucursal _bnBanco = new lib.bn.Sucursal(_usuario))
            {
                _bnBanco.Registrar(banco);
            }
        }

        [HttpPost]
        [Route("sucursal/actualizar")]
        public void Actualizar(lib.vm.Sucursal banco)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.Sucursal _bnBanco = new lib.bn.Sucursal(_usuario))
            {
                _bnBanco.Actualizar(banco);
            }
        }

        [HttpPost]
        [Route("sucursal/eliminar")]
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
        public ActionResult<List<lib.vm.Sucursal>> Listar(Guid banco)
        {
            List<lib.vm.Sucursal> _resultado = new List<lib.vm.Sucursal>();
            //using (lib.bn.Sucursal _bnSucursal = new lib.bn.Sucursal())
            //{
            //    _resultado = _bnSucursal.Listar(banco);
            //}

            for (int i = 0; i < 5; i++)
            {
                lib.vm.Sucursal _banco = new lib.vm.Sucursal();
                _banco.Id = Guid.NewGuid();
                _banco.Nombre = "Banco de la nacion angamos";
                _resultado.Add(_banco);
            }
            return _resultado;
        }

        [HttpGet]
        [Route("sucursal/obtener/{id}")]
        public ActionResult<lib.vm.Sucursal> Obtener(Guid id)
        {
            lib.vm.Sucursal _resultado = new lib.vm.Sucursal();
            //using (lib.bn.Sucursal _bnSucursal = new lib.bn.Sucursal())
            //{
            //    _resultado = _bnSucursal.Obtener(id);
            //}
            _resultado.Nombre = "Sucursal pichincha";
            _resultado.Direccion = "Avenida siempre viva 134";
            _resultado.FechaRegistro = DateTime.Now.ToString("dd/MM/yyyy");

            return _resultado;
        }

        [HttpGet]
        [Route("sucursal/filtrar/{nombreBanco}")]
        public ActionResult<List<lib.vm.Sucursal>> filtrar(string nombreBanco)
        {
            List<lib.vm.Sucursal> _resultado = new List<lib.vm.Sucursal>();
            using (lib.bn.Sucursal _bnSucursal = new lib.bn.Sucursal())
            {
                //_resultado = _bnSucursal.Filtrar(nombreBanco);
            }

            for (int i = 0; i < 5; i++)
            {
                lib.vm.Sucursal _banco = new lib.vm.Sucursal();
                _banco.Id = Guid.NewGuid();
                _banco.Nombre = "Banco de la nacion angamos";
                _resultado.Add(_banco);
            }
            return _resultado;
        }
    }
}
