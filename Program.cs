using System;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;


namespace dolar
{

    class Program
    {
        //Conexión SQLSERVER
        //string cadena = "Data Source=192.168.0.151,1590;Initial Catalog=ERP;Persist Security Info=True;User ID=HEREDIA;Password=HEREDIA";
        string cadena = "Data Source=RRIOS;Initial Catalog=ERP;Integrated Security=True";
        public SqlConnection conectarbd = new SqlConnection();
        

        //Metodo para conectar bdd
        public Program()
        {
            conectarbd.ConnectionString = cadena;
        }

        public void abrir()
        {

            //Protegemos la consulta
            try
            {
                conectarbd.Open();
                Console.WriteLine("Conexión abierta");
            }catch(Exception ex)
            {
                Console.WriteLine("Error al abrir la BD " + ex.Message);
            }
        }
        public void cerrar()
        {
            conectarbd.Close();
            Console.WriteLine("cerrada");
        }

       // public static int Insertar()
        //{

        //}



        public

        static void Main(string[] args)
        {
            Program conexion = new Program();
            conexion.abrir();
            string url = "https://api.sbif.cl/api-sbifv3/recursos_api/dolar?apikey=12d009750d2c7b8ca61690e62c95a76715b0a4ca&formato=json";
            string urlEuro = "https://api.sbif.cl/api-sbifv3/recursos_api/euro?apikey=12d009750d2c7b8ca61690e62c95a76715b0a4ca&formato=json";
            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);
            var jsonEuro = new WebClient().DownloadString(urlEuro);
            dynamic Euro = JsonConvert.DeserializeObject(jsonEuro);
            var KOMO = "US$";
            var TIMO = "E";
            var NOKOMO = "DOLAR AMERICANO";
            var VAMOCOM = "1";


            //Imprime el dato completo del dolar 
            var val = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)m).First).First).First).First).First).Value;
            Console.WriteLine("Valor dolar: " + val);

            var fech = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)m).First).First).First).Last).First).Value;

            //Imprime el dato fecha del valor del dolar en formato "año-mes-día"
            Console.WriteLine("Fecha valor Dolar: " + fech);

            //Imprime el dato completo del Euro
            var valEuro = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)Euro).First).First).First).First).First).Value;
            Console.WriteLine("Valor Euro: " + valEuro);

            //Imprime el dato fecha del valor del euro en formato "año-mes-día"
            var fechEuro = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)Euro).First).First).First).Last).Last).Value;
            Console.WriteLine("Fecha valor Euro: "+ fechEuro);



            conexion.cerrar();
          



            //Recorre todo el arreglo json deserializado
          /*  foreach (var item in m)
            {
                //Obtiene e imprime la fecha aislada del día que se toma el dato en formato "año-mes-día"
                Console.WriteLine(((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)item).First).First).Last).First);


                //Obtiene e imprime el valor del dolar aislado de otros datos con respecto a la fecha obtenida anteriormente
                Console.WriteLine(((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JProperty)item).Value).First).First).First);
            }*/

            


    }
    }
}



    
