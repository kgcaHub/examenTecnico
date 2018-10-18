using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrdenPago.lib.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrdenPago.web.api
{
    public class OpAtributoException :ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext contexto)
        {
            contexto.ExceptionHandled = true;
            contexto.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            OpException _eXcepcion = null;

            if (contexto.Exception.GetType() == typeof(OpException))
            {
                _eXcepcion = (OpException)contexto.Exception;
            }
            else
            {
                _eXcepcion = new OpException(contexto.Exception);
            }

            JsonResult _resultado = new JsonResult(new
            {
                tipo = _eXcepcion.tipo,
                mensajeUsuario = _eXcepcion.Message
            });
            contexto.Result = _resultado;
        }
    }
}
