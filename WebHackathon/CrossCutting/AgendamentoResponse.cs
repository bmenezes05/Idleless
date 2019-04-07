using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHackathon.CrossCutting
{
    public class AgendamentoResponse : ResponseBase
    {
        public string jsonCalendar { get; set; }
    }

    public class AgendamentoInsertResponse : ResponseBase
    {
        public string id { get; set; }
    }
}