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
        [OpAtributoException]
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
        [OpAtributoException]
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
        [OpAtributoException]
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
        [OpAtributoException]
        public ActionResult<List<lib.vm.Banco>> Listar()
        {
            List<lib.vm.Banco> _resultado = new List<lib.vm.Banco>();
            using (lib.bn.Banco _bnBanco = new lib.bn.Banco())
            {
                _resultado = _bnBanco.Listar();
            }

            return _resultado;
        }

        [HttpGet]
        [Route("banco/obtener/{id}")]
        [OpAtributoException]
        public ActionResult<lib.vm.Banco> Obtener(Guid id)
        {
            lib.vm.Banco _resultado = new lib.vm.Banco();
            using (lib.bn.Banco _bnBanco = new lib.bn.Banco())
            {
                _resultado = _bnBanco.Obtener(id);
            }
            return _resultado;
        }
    }
}
