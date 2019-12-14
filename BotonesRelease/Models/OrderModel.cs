using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BotonesRelease.Models
{
    public class OrderModel
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string PostalAddress { get; set; } = "";

        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Zipcode { get; set; } = "";
        public string Message { get; set; } = "";
        public string PreferredLanguage { get; set; } = "Español";
        public string PaymentMethod { get; set; } = "";

        private static string cs { get; set; } = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public int Add()
        {
            int id = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("OrderInsert", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Name", this.Name.Nullable());
                    command.Parameters.AddWithValue("@Phone", this.Phone.Nullable());
                    command.Parameters.AddWithValue("@Email", this.Email.Nullable());
                    command.Parameters.AddWithValue("@PostalAddress", this.PostalAddress);
                    command.Parameters.AddWithValue("@City", this.City);
                    command.Parameters.AddWithValue("@State", this.State);
                    command.Parameters.AddWithValue("@Zipcode", this.Zipcode);
                    command.Parameters.AddWithValue("@Message", this.Message.Nullable());
                    command.Parameters.AddWithValue("@PreferredLanguage", this.PreferredLanguage);
                    command.Parameters.AddWithValue("@PaymentMethod", this.PaymentMethod);

                    id = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return id;
        }
    }
}