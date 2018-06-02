using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Services
{
    public static class ClasesService
    {
        public static string UriClient = ConfiguracionGlobal.host;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Models.Clases> ObtenerClases(long cursosId)
        {
            try
            {

                var client = new RestClient(UriClient);
                // client.Authenticator = new HttpBasicAuthenticator(username, password);
                Models.Cursos user = new Models.Cursos { CursoId=cursosId };

                var json = JsonConvert.SerializeObject(user);

                var request = new RestRequest("proyectoPI/api/Clases", Method.POST);

                request.RequestFormat = DataFormat.Json;

                // adds to POST or URL querystring based on Method                
                request.AddParameter("application/json", json, ParameterType.RequestBody);



                // easily add HTTP Headers
                request.AddHeader("Content-Type", "application/json");


                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content; // raw content as string

                JObject result = JObject.Parse(content);


                if ((int)result["statuscode"] == 200)
                {

                    var clases = JsonConvert.DeserializeObject<List<Models.Clases>>(result["clases"].ToString());
                    return clases;
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
