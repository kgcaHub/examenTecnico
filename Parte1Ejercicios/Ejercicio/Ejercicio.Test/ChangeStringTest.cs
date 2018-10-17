using System;
using Ejercicio.Solucion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ejercicio.Test
{
    [TestClass]
    public class ChangeStringTest
    {
        private string _Entrada;
        private string _Salida;
        
        /// <summary>
        /// Este escenario valida la funcionalidad basica
        /// </summary>
        [TestMethod]
        public void Escenario1()
        {
            this._Entrada = "123 abcd*3";
            this._Salida = "123 bcde*3";
            this.EjecutarPrueba();
        }

        /// <summary>
        /// Este escenario valida que el método funcione para mayúsculas
        /// </summary>
        [TestMethod]
        public void Escenario2()
        {
            this._Entrada = "**CaSa 52";
            this._Salida = "**DbTb 52";
            this.EjecutarPrueba();
        }

        private void EjecutarPrueba()
        {
            ChangeString _changeString = new ChangeString();
            Assert.AreEqual(this._Salida, _changeString.build(this._Entrada));
        }
    }
}
