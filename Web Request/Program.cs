using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // URL untuk mengambil data universitas di Indonesia
            string apiUrl = "http://universities.hipolabs.com/search?country=Indonesia";

            // Membuat request ke URL dengan metode GET
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8"; 

            // Mendapatkan respon dari server
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // Memeriksa status kode dari respon
                Console.WriteLine("HTTP Status Code: " + response.StatusCode);

                // Membaca respon dari server
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        // Membaca seluruh konten dari respon server
                        string jsonResponse = reader.ReadToEnd();

                        // Parsing respon JSON menggunakan Newtonsoft.Json
                        JArray parsedData = JArray.Parse(jsonResponse);

                        // Menampilkan data hasil parsing
                        Console.WriteLine(parsedData.ToString());
                    }
                }
            }
        }
        catch (WebException webEx)
        {
            Console.WriteLine("WebException occurred: " + webEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        // Menjaga agar jendela konsol tetap terbuka setelah eksekusi
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}
