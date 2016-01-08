using Newtonsoft.Json;
using NurseAgenda3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace NurseAgenda3.DAL
{
    public class MyDataAccess
    {
        public async Task<List<Patient>> getAllPatient()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://nurseapi.azurewebsites.net/api/patients");
            string json = await response.Content.ReadAsStringAsync();
            var patientList = Newtonsoft.Json.JsonConvert.DeserializeObject<Patient[]>(json);
            /*foreach (var forecasts in forecast)
            {
                Console.WriteLine(forecasts.Nom + " " + forecasts.Prenom + "\n");
            }*/
            return patientList.ToList<Patient>();
        }

        public async Task<List<Infirmier>> getAllNurse()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://nurseapi.azurewebsites.net/api/infirmiers");
            string json = await response.Content.ReadAsStringAsync();
            var nurseList = Newtonsoft.Json.JsonConvert.DeserializeObject<Infirmier[]>(json);
            /*foreach (var forecasts in forecast)
            {
                Console.WriteLine(forecasts.Nom + " " + forecasts.Prenom + "\n");
            }*/
            return nurseList.ToList<Infirmier>();
        }

        public async void AddCare(Soin soin)
        {
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(soin);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://nurseapi.azurewebsites.net/api/soins", content);
            if (response.IsSuccessStatusCode)
            {
                await new MessageDialog("Success !").ShowAsync();
            }
            else
            {
                await new MessageDialog("Add Failed !").ShowAsync();
            }
        }
    }
}
