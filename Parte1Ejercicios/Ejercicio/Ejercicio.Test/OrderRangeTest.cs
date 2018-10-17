using Ejercicio.Solucion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ejercicio.Test
{
    [TestClass]
    public class OrderRangeTest
    {
        private int[] _Entrada;
        private int[][] _Salida;

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Escenario1()
        {
            this._Entrada = new int[] { 2, 1, 4, 5 };
            this._Salida = new int[2][] { new int[] {1,5}, new int[] { 2,4} };
            this.EjecutarPrueba();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Escenario2()
        {
            this._Entrada = new int[] { 4, 2, 9, 3, 6 };
            this._Salida = new int[2][] {new int[] { 3, 9 }, new int[] { 2, 4, 6 } };
            this.EjecutarPrueba();
        }

        /// <summary>
        /// 
        /// </summary>
        //[TestMethod]
        //public void Escenario3()
        //{
        //    this._Entrada = new int[] { 2, 1, 4, 5 };
        //    this._Salida = new int[2][] { new int[] { 1, 5 }, new int[] { 2, 4 } };
        //    this.EjecutarPrueba();
        //}

        private void EjecutarPrueba()
        {
            OrderRange _orderRange = new OrderRange();
            Assert.AreEqual(this._Salida, _orderRange.build(this._Entrada));
        }
    }
}
