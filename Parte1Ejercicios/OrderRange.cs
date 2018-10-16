using System;
using System.Collections.Generic;

namespace Ejercicios
{
    public class OrderRange
    {
        public int[][] build(int[] entrada)
        {
            int[][] salida = null;
            List<int> pares = new List<int>();
            List<int> impares = new List<int>();
            bool esPrimeroImpar = true;

            //Este método del framework implementa el algoritmo QuickSort
            Array.Sort(entrada);

            for (int i = 0; i < entrada.Length; i++)
            {
                int numero = entrada[i];
                if (numero % 2 == 0)
                {
                    pares.Add(numero);
                    if (i == 0)
                    {
                        esPrimeroImpar = true;
                    }
                }
                else
                {
                    impares.Add(numero);
                    if (i == 0)
                    {
                        esPrimeroImpar = false;
                    }
                }
            }

            if (esPrimeroImpar)
            {
                salida = new[] { pares.ToArray(), impares.ToArray() };
            }
            else
            {
                salida = new[] { impares.ToArray(), pares.ToArray() };
            }

            return salida;
        }
    }
}
