using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MangoproxyHttpExample
{
    public static class Program
    {
        private const string Username = "aa580e768465da258943e-zone-custom";
        private const string Password = "aa580e768465da258943e";
        private const string MangoproxyDns = "http://43.153.237.55:2334";
        private const string UrlToGet = "http://ip-api.com/json";

        public static async Task Main()
        {
            using var httpClient = new HttpClient(new HttpClientHandler
            {
                Proxy = new WebProxy
                {
                    Address = new Uri(MangoproxyDns),
                    Credentials = new NetworkCredential(Username, Password),
                }
            });

            using var responseMessage = await httpClient.GetAsync(UrlToGet);
            var contentString = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine("Response:" + Environment.NewLine + contentString);
            Console.ReadKey(true);
        }
    }
}
