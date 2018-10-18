using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdenPago.web.api.Controllers
{
    [ApiController]
    public class BancoController : ControllerBase
    {
        [HttpPost]
        [Route("banco/registrar")]
        public void Registrar(lib.vm.Banco banco)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.Banco _bnBanco = new lib.bn.Banco(_usuario))
            {
                _bnBanco.Registrar(banco);
            }
        }

        [HttpPost]
        [Route("banco/actualizar")]
        public void Actualizar(lib.vm.Banco banco)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.Banco _bnBanco = new lib.bn.Banco(_usuario))
            {
                _bnBanco.Actualizar(banco);
            }
        }

        [HttpPost]
        [Route("banco/eliminar")]
        public void Eliminar(Guid id)
        {
            string _usuario = "kcarhuas";
            using (lib.bn.Banco _bnBanco = new lib.bn.Banco(_usuario))
            {
                _bnBanco.Eliminar(id);
            }
        }

        [HttpGet]
        [Route("banco/listar")]
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
        [Route("banco/obtener/{id}")]
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
    }
}
