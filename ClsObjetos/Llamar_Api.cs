using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClsObjetos
{
    public class Llamar_Api
    {
        //public static string host = $"http://170.247.130.33/WebApi-Servicios/api/";

        //url publicada local 
        //public static string host = $"http://10.10.213.73/api/";

        public static string host = $"http://localhost:5155/api/";


        //public static string host = $"https://localhost:44375/api/";


        public static string GetItem(string url)
        {
            // string url = $"" + Control;
            string responseBody = "";
            var request = (HttpWebRequest)WebRequest.Create(host + url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return responseBody;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return responseBody;
        }

        public static string GetItems(string url, string data)
        {
            string responseBody = "";
            var request = (HttpWebRequest)WebRequest.Create(host + url);
            string json = $"" + data;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return responseBody;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return responseBody;
        }

        public static string PutItem(string url, string data)
        {
            string responseBody = "";
            var request = (HttpWebRequest)WebRequest.Create(host + url);
            string json = $"" + data;
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return responseBody;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            //Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return responseBody;
        }

        public static string PostItem(string url, string data)
        {
            string responseBody = "";
            var request = (HttpWebRequest)WebRequest.Create(host + url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return responseBody;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            //Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                responseBody = ex.ToString();
            }
            return responseBody;
        }

        private static string GetPost(string url, string data)
        {
            string result = "";
            WebRequest oRequest = WebRequest.Create(host + url);
            oRequest.Method = "Post";
            oRequest.ContentType = "application/json; chartse4t=UTO-8";

            using (var oSW = new StreamWriter(oRequest.GetRequestStream()))
            {
                oSW.Write(data);
                oSW.Flush();
                oSW.Close();
            }
            try
            {
                WebResponse oResponse = oRequest.GetResponse();
                using (var oSR = new StreamReader(oResponse.GetResponseStream()))
                {
                    result = oSR.ReadToEnd().Trim();
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return result;
        }

        public static string DeleteItem(string url, string data)
        {
            string responseBody = "";
            var request = (HttpWebRequest)WebRequest.Create(host + url);
            string json = $"" + data;
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return responseBody;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            //Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return responseBody;
        }
    }
}
