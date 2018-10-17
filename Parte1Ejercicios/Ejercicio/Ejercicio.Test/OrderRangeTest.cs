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
        /// Prueba con el valor de entrada y los valores esperados ingresados directamente
        /// </summary>
        [TestMethod]
        public void Escenario1()
        {
            this._Entrada = new int[] { 2, 1, 4, 5 };
            this._Salida = new int[2][] { new int[] {1,5}, new int[] { 2,4} };
            this.EjecutarPrueba();
        }

        /// <summary>
        /// Prueba para verificar que no se ordene siempre los impares primero sino el número menor
        /// </summary>
        [TestMethod]
        public void Escenario2()
        {
            this._Entrada = new int[] { 4, 2, 9, 3, 6 };
            this._Salida = new int[2][] { new int[] { 2, 4, 6 }, new int[] { 3, 9 }};
            this.EjecutarPrueba();
        }

        /// <summary>
        /// Prueba con el valor de entrada y los valores esperados ingresados directamente
        /// </summary>
        [TestMethod]
        public void Escenario3()
        {
            this._Entrada = new int[] { 58, 60, 55, 48, 57, 73 };
            this._Salida = new int[][] { new int[] { 48, 58, 60 }, new int[] { 55, 57, 73 } };
            this.EjecutarPrueba();
        }

        private void EjecutarPrueba()
        {
            OrderRange _orderRange = new OrderRange();

            int[][] _salida = _orderRange.build(this._Entrada);

            for (int i = 0; i < this._Salida.Length; i++)
            {
                CollectionAssert.AreEqual(this._Salida[i], _salida[i]);
            }
        }
    }
}
