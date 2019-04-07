using System;
using System.Net;
using System.Web.Mvc;
using WebHackathon.CrossCutting;
using WebHackathon.Helper;

namespace WebHackathon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InscreverAtividade()
        {            
            return View();
        }

        public AgendamentoResponse getAgendamentos()
        {
            AgendamentoResponse response = new AgendamentoResponse();

            try
            {
                MyHttp myHttp = new MyHttp("https:\\hackathonbtpapi.azurewebsites.net\\");
                var result = myHttp.Get(@"api\getAgendamentos");
                MyFile.saveJson(result.Result);
                response.ResultCode = (int)HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.ResultCode = (int)HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}