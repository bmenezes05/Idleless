using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
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

        public async Task<AgendamentoResponse> getAgendamentos(bool navio, bool atividade)
        {
            AgendamentoResponse response = new AgendamentoResponse();

            try
            {
                MyHttp myHttp = new MyHttp();
                var result = await myHttp.Get(@"https://hackathonbtpapi.azurewebsites.net/api/", string.Concat("Agendamento/ObterPorPessoaId/", "1"));
                MyFile.saveJson(result);
                response.ResultCode = (int)HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.ResultCode = (int)HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public ActionResult getQRCode()
        {
            JsonResult result = new JsonResult();

            var bitmap = GerarQRCode(200, 200, "https://stackoverflow.com");

            byte[] imageByteData = ImageToByte2(bitmap);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            result.Data = imageDataURL;
            return result;
        }

        private byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private Bitmap GerarQRCode(int width, int height, string text)
        {
            try
            {
                var bw = new ZXing.BarcodeWriter();
                var encOptions = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 };
                bw.Options = encOptions;
                bw.Format = ZXing.BarcodeFormat.QR_CODE;
                var resultado = new Bitmap(bw.Write(text));
                return resultado;
            }
            catch
            {
                throw;
            }
        }
    }
}