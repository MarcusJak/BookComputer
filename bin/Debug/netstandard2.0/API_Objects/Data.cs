using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using static CoreFoundation.DispatchSource;
using System.Text;
using ObjCRuntime;
using MethodTimer;

namespace exjobb.API_Objects
{


    public class Data
	{
        string url = "92.32.171.214";
        string urlHem = "78.73.146.252";
        

        public Data()
		{
        }


        public async Task refreshDataAsync()
        {
            await Task.WhenAll(refreshDator(), refreshHyrning(), refreshDatorHyrning());
        }


        [Time]
        public async Task<HttpResponseMessage> getHttpFunktion(string urlLocation)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(urlLocation);
            return response;
        }

        [Time]
        public async Task<HttpResponseMessage> postHttpFunktion(string urlLocation, StringContent content)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(urlLocation, content);
            return response;
        }







        [Time]
        public async Task refreshKunder()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://"+url+":8080/api/kunders");
            string content = await response.Content.ReadAsStringAsync();
            allKunder = JsonConvert.DeserializeObject<List<Kund>>(content);
        }

        [Time]
        public async Task refreshDator()
        {

            var client = new HttpClient();
            HttpResponseMessage response = await getHttpFunktion("http://"+url+":8080/api/Datorers");
            string content = await response.Content.ReadAsStringAsync();

            allDators = JsonConvert.DeserializeObject<List<Dator>>(content);
        }


        [Time]
        public async Task refreshHyrning()
        {

            var client = new HttpClient();
            HttpResponseMessage response = await getHttpFunktion("http://"+url+":8080/api/Hyrnings");
            string content = await response.Content.ReadAsStringAsync();
            allHyrningar = JsonConvert.DeserializeObject<List<Hyrning>>(content);
        }

        [Time]
        public async Task refreshDatorHyrning()
        {

            var client = new HttpClient();
            HttpResponseMessage response = await getHttpFunktion("http://"+url+":8080/api/DatorHyrnings");
            string content = await response.Content.ReadAsStringAsync();

            allDatorHyrningar = JsonConvert.DeserializeObject<List<DatorHyrning>>(content);
        }


        [Time]
        internal string login(object userID, Entry password)
        {
            throw new NotImplementedException();
        }

        public List<Kund> allKunder { get; private set; }
        public List<Dator> allDators { get; private set; }
        public List<Hyrning> allHyrningar { get; private set; }
        public List<DatorHyrning> allDatorHyrningar { get; private set; }


        [Time]
        public async Task RemoveDataFromBooking(int removeID)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync("http://"+url+":8080/api/DatorHyrnings/"+removeID);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Objektet med ID " + removeID + " har tagits bort.");
            }
            else
            {
                Console.WriteLine("Kunde inte ta bort objektet. Felkod: " + response.StatusCode);
            }

        }

        [Time]
        public async Task PostHyrning(int datorID, int hyrningsID)
        {
            DatorHyrning tempDatorhyrning= new DatorHyrning(datorID,hyrningsID);
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(tempDatorhyrning);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                        Console.WriteLine(content);

            var response = await postHttpFunktion("http://"+url+":8080/api/DatorHyrnings", content);


        }

        [Time]
        public async Task<Hyrning> PostBooking(Kund kund,DateTime startDate, DateTime endDate)
        {

            Hyrning tempHyrning = new Hyrning(kund.kundId, startDate, endDate);
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(tempHyrning);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://"+url+":8080/api/Hyrnings", content);
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
            Hyrning responseObject = JsonConvert.DeserializeObject<Hyrning>(responseBody);
            return responseObject;
        }

        [Time]
        public async Task <Kund> checkLogInInput(string användarnamn, string password )
        {
            var client = new HttpClient();
            Console.WriteLine("http://" + url + ":8080/api/kunders?userId=" + användarnamn + "&password=" + password);
            HttpResponseMessage response = await getHttpFunktion("http://" + url + ":8080/api/kunders?userId=" + användarnamn + "&password=" + password);
            string content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
                return JsonConvert.DeserializeObject<List<Kund>>(content)[0];



        }
    }
}

