using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHackathon.CrossCutting
{
    public class AgendamentoRequest 
    {
        public string pessoaID { get; set; }
        public string modalidadeID { get; set; }
        public string dataAgendamentoInicio { get; set; }
        public string dataAgendamentoFim { get; set; }
        public string descricao { get; set; }
        public string detalhe { get; set; }
    }

}