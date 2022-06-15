using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoDeMoedas
{
    /// <summary>
    /// Valida os dados de entrada para a conversão de moedas.
    /// </summary>
    public class ValidacaoDadosEntrada
    {
        /// <summary>
        /// Valida os parâmetros de moedas que serão convertidas.
        /// </summary>
        /// <param name="origem">Moeda original padronizada com 3 caracteres.</param>
        /// <param name="destino">Moeda destino padronizada com 3 caracteres.</param>
        /// <returns>Verdadeiro se os parâmetros forem válidos e falso caso contrário.</returns>
        public static bool validaMoedas(String origem, String destino)
        {
            if (destino == null)
            {
                Console.WriteLine("Moeda de destino não pode ser nula.\n");
                return false;
            }

            if (origem == destino)
            {
                Console.WriteLine("Moeda de destino não pode ser igual a moeda de origem.\n");
                return false;
            }

            if (origem.Length != 3)
            {
                Console.WriteLine("Moeda de origerm deve possuir 3 caracteres.\n");
                return false;
            }

            if (destino.Length != 3)
            {
                Console.WriteLine("Moeda de origerm deve possuir 3 caracteres.\n");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida o valor a ser convertido.
        /// </summary>
        /// <param name="valor">Valor maior que 0.</param>
        /// <returns>Verdadeiro se o valor for válido e falso caso contrário.</returns>
        public static bool validaValor(String valor)
        {
            Decimal valorConvertido;
            if (!(Decimal.TryParse(valor, out valorConvertido)))
            {
                Console.WriteLine("Valor a ser convertido está em formato incorreto.");
                return false;
            }
            if (valorConvertido <= 0)
            {
                Console.WriteLine("Valor a ser convertido deve ser maior que 0,00(zero).");
                return false;
            }
            
            return true;
        }
    }
}
