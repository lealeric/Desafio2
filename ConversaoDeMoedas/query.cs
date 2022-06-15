using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoDeMoedas
{
    /// <summary>
    /// Classe auxiliar para manipulação do JSON.
    /// </summary>
    public class query
    {
        /// <summary>
        /// Propriedade referente à moeda original.
        /// </summary>
        public String from { get; set; }

        /// <summary>
        /// Propriedade referente à moeda destino.
        /// </summary>
        public String to { get; set; }

        /// <summary>
        /// Propriedade referente ao valor a converter.
        /// </summary>
        public double amount { get; set; }
    }
}
