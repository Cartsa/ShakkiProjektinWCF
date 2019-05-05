using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace ShakkiProjektinWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Tallennus(string ValkoinenNimimerkki, string MustaNimimerkki, int Vuorot, string Voittaja)
        {
            SqlConnection yhteys = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\carol\\source\\repos\\ShakkiProjektinWCF\\ShakkiProjektinWCF\\App_Data\\ShakkiPelit.mdf;Integrated Security=True");
            SqlCommand Tallenna = new SqlCommand("INSERT INTO Tilastot(ValkoinenPelaaja,MustaPelaaja,Vuoroja_pelattu,Voittaja) VALUES (@ValkoinenNimimerkki,@MustaNimimerkki,@Vuorot,@Voittaja)", yhteys);
            Tallenna.Parameters.AddWithValue("@ValkoinenNimimerkki",ValkoinenNimimerkki);
            Tallenna.Parameters.AddWithValue("@MustaNimimerkki", MustaNimimerkki);
            Tallenna.Parameters.AddWithValue("@Vuorot", Vuorot);
            Tallenna.Parameters.AddWithValue("@Voittaja", Voittaja);
            try
            {
                yhteys.Open();
                Tallenna.ExecuteNonQuery();
                yhteys.Close();
                return "Toimi";
            }catch(Exception e)
            {
                yhteys.Close();
                return "Ei toimi: " + e;
            }
        }

      
    }
}
