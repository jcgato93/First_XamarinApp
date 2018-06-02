using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Services
{
    public static class CursosService
    {
        public static string UriClient = ConfiguracionGlobal.host;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Models.Cursos> ObtenerCursos()
        {
            try
            {
               
                var client = new RestClient(UriClient);
                // client.Authenticator = new HttpBasicAuthenticator(username, password);

                var request = new RestRequest("proyectoPI/api/Cursos", Method.POST);

                request.RequestFormat = DataFormat.Json;

                // adds to POST or URL querystring based on Method                
                //request.AddParameter("application/json", json, ParameterType.RequestBody);



                // easily add HTTP Headers
                request.AddHeader("Content-Type", "application/json");


                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content; // raw content as string

                JObject result = JObject.Parse(content);


                if ((int)result["statuscode"] == 200)
                {

                    var cursos = JsonConvert.DeserializeObject<List<Models.Cursos>>(result["cursos"].ToString());
                    return cursos;
                }
                else
                {
                    return null;
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
