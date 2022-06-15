using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoDeMoedas
{
    /// <summary>
    /// Interface de interação com o usuário.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Inicia o menu de interação com o usuário.
        /// </summary>
        public static void Run()
        {
            while (true)
            {
                String moedaOriginal, moedaConvertida = "", stringValorOriginal;
                double valorOriginal;

                do
                {
                    Console.Write("Moeda Original: ");
                    moedaOriginal = Console.ReadLine();
                    if (moedaOriginal == "") break;

                    Console.Write("Moeda Destino: ");
                    moedaConvertida = Console.ReadLine();
                } while (!ValidacaoDadosEntrada.validaMoedas(moedaOriginal, moedaConvertida));
                
                if (moedaOriginal == "") break;

                do
                {
                    Console.Write("Valor a converter: ");
                    stringValorOriginal = Console.ReadLine().Replace(",",".");
                } while (!ValidacaoDadosEntrada.validaValor(stringValorOriginal));

                valorOriginal = double.Parse(stringValorOriginal);
                Conversao.converteValor(valorOriginal, moedaOriginal, moedaConvertida);
            }

            Console.WriteLine("Aplicação encerrada.");
        }
    }
}
