using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BotonesRelease.Models
{
    public class ContactModel
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string FavoriteColor { get; set; } = "";
        public string Purpose { get; set; } = "";
        public string Message { get; set; } = "";
        public string Language { get; set; } = "Español";

        private static string cs { get; set; } = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public int Add()
        {
            int id = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("ContactInsert", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Name", this.Name.Nullable());
                    command.Parameters.AddWithValue("@Phone", this.Phone.Nullable());
                    command.Parameters.AddWithValue("@Email", this.Email.Nullable());
                    command.Parameters.AddWithValue("@FavoriteColor", this.FavoriteColor);
                    command.Parameters.AddWithValue("@Purpose", this.Purpose);
                    command.Parameters.AddWithValue("@Message", this.Message.Nullable());
                    command.Parameters.AddWithValue("@Language", this.Language);

                    id = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return id;
        }
    }
}