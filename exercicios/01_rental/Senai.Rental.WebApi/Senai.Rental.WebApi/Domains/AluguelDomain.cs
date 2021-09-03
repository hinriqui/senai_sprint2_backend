using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) empresa
    /// </summary>
    public class AluguelDomain
    {
        public int idAluguel { get; set; }
        public int idCliente { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
    }
}
