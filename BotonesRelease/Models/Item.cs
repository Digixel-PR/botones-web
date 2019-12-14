using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BotonesRelease.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Provider { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Price { get; set; }
        public string PictureUrl { get; set; }
        public string Material { get; set; }
        public int InStock { get; set; }
        public bool Hidden { get; set; } = false;
        public int Position { get; set; }

        private static string cs { get; set; } = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public int Add()
        {
            int id = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("AddItem", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Name", this.Name);
                    command.Parameters.AddWithValue("@Description", this.Description);
                    command.Parameters.AddWithValue("@Provider", this.Provider);
                    command.Parameters.AddWithValue("@Category", this.Category);
                    command.Parameters.AddWithValue("@Subategory", this.Subcategory);
                    command.Parameters.AddWithValue("@Cost", this.Cost);
                    command.Parameters.AddWithValue("@Price", this.Price);
                    command.Parameters.AddWithValue("@PictureUrl", this.PictureUrl);
                    command.Parameters.AddWithValue("@Material", this.Material);
                    command.Parameters.AddWithValue("@InStock", this.InStock);
                    command.Parameters.AddWithValue("@Hidden", this.Hidden);
                    command.Parameters.AddWithValue("@Position", this.Position);

                    id = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return id;
        }

        public List<Item> GetList()
        {
            List<Item> list = new List<Item>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("GetItemList", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Clear();
                   
                    using (SqlDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            Item i = new Item();
                            i.ID = Convert.ToInt32(r["ID"]);
                            i.Name = r["Name"].ToString();
                            i.Description = r["Description"].ToString();
                            i.Provider = r["Provider"].ToString();
                            i.Category = r["Category"].ToString();
                            i.Subcategory = r["Subcategory"].ToString();
                            i.Cost = Convert.ToDecimal(r["Cost"].ToString());
                            i.Price = Convert.ToDecimal(r["Price"].ToString());
                            i.PictureUrl = r["PictureUrl"].ToString();
                            i.Material = r["Material"].ToString();
                            i.InStock = Convert.ToInt32(r["InStock"]);
                            i.Hidden = Convert.ToBoolean(r["Hidden"]);
                            i.Position = Convert.ToInt32(r["Position"]);
                            list.Add(i);
                        }
                    }
                }
            }

            return list;
        }


        public Item Get(int id)
        {
            Item item = new Item();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("GetItem", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader r = command.ExecuteReader())
                    {
                        if (r.Read())
                        {                            
                            item.ID = Convert.ToInt32(r["ID"]);
                            item.Name = r["Name"].ToString();
                            item.Description = r["Description"].ToString();
                            item.Provider = r["Provider"].ToString();
                            item.Category = r["Category"].ToString();
                            item.Subcategory = r["Subcategory"].ToString();
                            item.Cost = Convert.ToDecimal(r["Cost"].ToString());
                            item.Price = Convert.ToDecimal(r["Price"].ToString());
                            item.PictureUrl = r["PictureUrl"].ToString();
                            item.Material = r["Material"].ToString();
                            item.InStock = Convert.ToInt32(r["InStock"]);
                            item.Hidden = Convert.ToBoolean(r["Hidden"]);
                            item.Position = Convert.ToInt32(r["Position"]);
                        }
                    }
                }
            }

            return item;
        }


        public void Update(Item m)
        {            
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("UpdateItem", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Id", m.ID);
                    command.Parameters.AddWithValue("@Name", m.Name);
                    command.Parameters.AddWithValue("@Description", m.Description);
                    command.Parameters.AddWithValue("@Provider", m.Provider);
                    command.Parameters.AddWithValue("@Category", m.Category);
                    command.Parameters.AddWithValue("@Subcategory", m.Subcategory);
                    command.Parameters.AddWithValue("@Cost", m.Cost);
                    command.Parameters.AddWithValue("@Price", m.Price);
                    command.Parameters.AddWithValue("@PictureUrl", m.PictureUrl);
                    command.Parameters.AddWithValue("@Material", m.Material);
                    command.Parameters.AddWithValue("@InStock", m.InStock);
                    command.Parameters.AddWithValue("@Hidden", m.Hidden);
                    command.Parameters.AddWithValue("@Position", m.Position);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}