using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace rdogsAPI
{
    struct Dogs {
    public string message;
    public string status;
            }
    class Program
    {
        static void Main(string[] args)
        {
            var url = $"https://dog.ceo/api/breeds/image/random";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                var randomDog = JsonConvert.DeserializeObject<Dogs>(result);
                Console.WriteLine(randomDog.message);
            }

        }
    }
}
