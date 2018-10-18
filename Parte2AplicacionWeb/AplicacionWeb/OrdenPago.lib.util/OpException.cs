using System;

namespace OrdenPago.lib.util
{
    public class OpException: ApplicationException
    {
        public string tipo { get; private set; }
        public OpException(string message) : base(message)
        {
            this.tipo = tipoException.Validacion;
        }
        public OpException(Exception excepcion) : base(excepcion.Message + " stack: " +excepcion.StackTrace)
        {
            this.tipo = tipoException.ErrorSistema;
        }
    }

    public static class tipoException
    {
        public const string TimeOut = "TimeOut";
        public const string Validacion = "Validacion";
        public const string ErrorSistema = "Error de sistema";
    }

   
}
