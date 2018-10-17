using System.Text;

namespace Ejercicio.Solucion
{
    public class ChangeString
    {
        private string abecedario = "abcdefghijklmnñopqrstuvwxyz";

        public string build(string entrada)
        {
            StringBuilder salida = new StringBuilder();

            foreach (char letra in entrada)
            {
                int indice = this.abecedario.IndexOf(char.ToLower(letra));

                if (indice > -1)
                {
                    if (indice < this.abecedario.Length - 1)
                    {
                        indice++;
                    }
                    else
                    {
                        indice = 0;
                    }

                    char caracter = this.abecedario[indice];

                    if (char.IsUpper(letra))
                    {
                        caracter = char.ToUpper(caracter);
                    }

                    salida.Append(caracter);
                }
                else
                {
                    salida.Append(letra);
                }
            }

            return salida.ToString();
        }
    }
}
