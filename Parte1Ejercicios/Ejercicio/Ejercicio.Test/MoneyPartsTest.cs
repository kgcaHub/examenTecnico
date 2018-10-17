using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio.Solucion;
using System.Collections.Generic;

namespace Ejercicio.Test
{
    [TestClass]
    public class MoneyPartsTest
    {
        private string _Entrada;

        /// <summary>
        /// Prueba con el valor de entrada y los valores esperados ingresados directamente
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            this._Entrada = "0.1";

            List<List<double>> _combinaciones = new List<List<double>>();

            List<double> _combinacion1 = new List<double>();
            _combinacion1.Add(0.05);
            _combinacion1.Add(0.05);

            _combinaciones.Add(_combinacion1);

            List<double> _combinacion2 = new List<double>();
            _combinacion2.Add(0.1);

            _combinaciones.Add(_combinacion2);

            this.EjecutarPrueba(_combinaciones);
        }

        private void EjecutarPrueba(List<List<double>> salida)
        {
            MoneyParts _moneyParts = new MoneyParts();

            List<List<double>>  _salida = _moneyParts.build(this._Entrada);

            for (int i = 0; i < salida.Count; i++)
            {
                CollectionAssert.AreEqual(salida[i], _salida[i]);
            }
        }

        /// <summary>
        /// Prueba con valor de entrada y que la suma de los elementos de una combinacion sumen el valor de entrada
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            this._Entrada = "10.5";
            this.EjecutarPruebaSuma(10.5);
        }

        /// <summary>
        /// Prueba que no existan combinaciones repetidas
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            this._Entrada = "4.5";
            this.EjecutarPruebaRepeticion();
        }

        /// <summary>
        /// Prueba de suma de elementos y que no existan combinaciones repetidas
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            this._Entrada = "4.0";
            this.EjecutarPruebaSuma(4.0);
            this.EjecutarPruebaRepeticion();
        }

        private void EjecutarPruebaSuma(double sumaCombinacion)
        {
            MoneyParts _moneyParts = new MoneyParts();

            List<List<double>> _combinaciones = _moneyParts.build(this._Entrada);

            foreach (var _combinacion in _combinaciones)
            {
                double _sumaCombinacion = 0;

                foreach (var _denominacion in _combinacion)
                {
                    _sumaCombinacion += _denominacion;
                }

                Assert.AreEqual(sumaCombinacion, _sumaCombinacion, 0.001);
            }
        }

        private void EjecutarPruebaRepeticion()
        {
            MoneyParts _moneyParts = new MoneyParts();

            List<List<double>> _combinaciones = _moneyParts.build(this._Entrada);

            List<string> _datos = new List<string>();

            foreach (var _combinacion in _combinaciones)
            {
                double[] _combinacionArray = _combinacion.ToArray();
                Array.Sort(_combinacionArray);
                string _combinacionString = string.Join("", _combinacionArray);
                CollectionAssert.DoesNotContain(_datos, _combinacionString);
                _datos.Add(_combinacionString);
            }
        }
    }
}
