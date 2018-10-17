using System.Collections.Generic;

namespace Ejercicio.Solucion
{
    public class MoneyParts
    {
        private int[] _Denominaciones = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000 };

        private List<List<double>> _Combinaciones = new List<List<double>>();

        public List<List<double>> build(string entrada)
        {
            int _entrada = (int)(double.Parse(entrada) * 100);

            this.AgregarCombinacion(_entrada);

            return this._Combinaciones;
        }

        private void AgregarCombinacion(int _monto, int indice = 0, List<double> combinacion = null)
        {
            int _denominacion = this._Denominaciones[indice];

            if (combinacion == null)
            {
                combinacion = new List<double>();
            }

            for (int _cantidad = _monto / _denominacion; _cantidad >= 0; _cantidad--)
            {
                int _resto = _monto - (_denominacion * _cantidad);

                List<double> _combinacion = new List<double>(combinacion);
                for (int j = 0; j < _cantidad; j++)
                {
                    _combinacion.Add((double)_denominacion / 100);
                }

                if (_resto == 0 && _monto != 0)
                {
                    this._Combinaciones.Add(_combinacion);
                }

                if (_denominacion > _monto)
                {
                    break;
                }

                this.AgregarCombinacion(_resto, indice + 1, _combinacion);
            }
        }
    }
}
