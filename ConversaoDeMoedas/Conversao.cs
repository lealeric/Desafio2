using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace ConversaoDeMoedas
{
    /// <summary>
    /// Converte valores entre moedas diferentes.
    /// </summary>
    public class Conversao
    {
        public info Info { get; set; }
        public query Query { get; set; }
        public double result { get; set; }

        /// <summary>
        /// Converte e exibe um valor entre duas moedas.
        /// </summary>
        /// <param name="valorInicial">Valor original a converter.</param>
        /// <param name="moedaInicial">Moeda original a converter.</param>
        /// <param name="moedaFinal">Moeda destino após a conversão.</param>
        public static void converteValor(double valorInicial, string moedaInicial, string moedaFinal)
        {
            String url_str = String.Format("https://api.exchangerate.host/convert?from={0}&to={1}&amount={2}", moedaInicial, moedaFinal, valorInicial.ToString());
            try
            {
                HttpClient client = new();
                HttpResponseMessage response = client.GetAsync(url_str).Result;
                string resposta = response.Content.ReadAsStringAsync().Result;

                Conversao conversao = JsonConvert.DeserializeObject<Conversao>(resposta);

                Conversao.imprimeConversao(conversao);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Conversão não realizada.");
            }
            
        }

        private static void imprimeConversao(Conversao conversao)
        {
            Console.WriteLine(String.Format("\n{0} ({1}): {2}\n" +
                                            "{3} ({4}): {5}\n" +
                                            "{6}: {7:0.000000}", "Valor Original", conversao.Query.from,
                                            conversao.Query.amount.ToString("C").Replace(".", ",").PadLeft(10),
                                            "Valor Destino", conversao.Query.to,
                                            conversao.result.ToString("C").Replace(".", ",").PadLeft(11),
                                            "Taxa de Conversão",
                                            conversao.Info.rate.ToString().Replace(".", ",").PadLeft(13)) + "\n");
        }
    }
}
