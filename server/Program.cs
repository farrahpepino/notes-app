using System;
using System.Data.SqlClient;

namespace DBConnection
{
    class Program{
        static void Main(string[] args){
            using(var client = new SqlConnection("connectionString")){
                client.Open();
                SqlCommand cmd = new SqlCommand("SELECT SOMETHING")
            }
        }
    }
}