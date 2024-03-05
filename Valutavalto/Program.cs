using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Valtas;

namespace Valutavalto
{
    internal class Program
    {
        static Valutaatvaltas valtas = null;
        static async Task Main(string[] args)
        {
            List<Valutaatvaltas> valtas = new List<Valutaatvaltas>();
            await valutaatvaltas();
            Console.WriteLine("Valuta átváltás: ");
            Console.ReadLine();
        }

        private static async Task valutaatvaltas()
        {
            List<Valutaatvaltas> valtas = new List<Valutaatvaltas>();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://infojegyzet.hu/webszerkesztes/php/valuta/api/v1/arfolyam/");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}