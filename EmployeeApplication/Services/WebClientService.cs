﻿using System.Text;

namespace EmployeeApplication.Services
{
    public class WebClientService : IWebClientService
    {
        //Related Documentation:
        //https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/web-services/rest

        public async Task<string> GetAsync(string uri)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(uri);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> PostAsync(string uri, string body, string type)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();

                var content = new StringContent(body, Encoding.UTF8, type);

                HttpResponseMessage response = await client.PostAsync(uri, content);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<string> PutAsync(string uri, string body, string type)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();

                var content = new StringContent(body, Encoding.UTF8, type);

                HttpResponseMessage response = await client.PutAsync(uri, content);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
