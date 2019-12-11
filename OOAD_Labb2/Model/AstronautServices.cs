using System;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace OOAD_Labb2
{
    public  class AstronautServices : IAstronautServices
    {
        public async Task<SpaceInfoDTO> GetDataAsync()
        {
            var url = "http://api.open-notify.org/astros.json";

            SpaceInfoDTO spaceInfoDTO = await Task.Run(() =>
            {
                var DTO = new SpaceInfoDTO();
                try
                {
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    WebResponse response = request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    var sr = new StreamReader(responseStream);
                    var astronautsAsJson = sr.ReadToEnd();
                    DTO = JsonConvert.DeserializeObject<SpaceInfoDTO>(astronautsAsJson);
                    return DTO;
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return null;
            });

            return spaceInfoDTO;
        }
    }

}


