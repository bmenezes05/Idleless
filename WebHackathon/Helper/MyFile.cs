using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebHackathon.Helper
{
    public static class MyFile
    {

        public static void saveJson(string json)
        {
            try
            {
                string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Json/");
                FileStream fs = new FileStream(path + "events.json", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(json);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}