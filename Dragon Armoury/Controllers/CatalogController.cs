using Dragon_Armoury.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Dragon_Armoury.Controllers
{
    public class CatalogController : Controller
    {
        public ActionResult Catalog(int catalogId)
        {
            ViewBag.Catagory = catalogId;
            Catagory catagory = RetriveCategoryInfo(catalogId);
            ViewBag.Title = catagory.CatagoryName;
            ViewBag.Message = catagory.CatagoryDescription;

            return View();
        }

        public Catagory RetriveCategoryInfo(int catalogId)
        {

            Catagory catagory = new Catagory();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            string script = "SELECT * FROM Categories WHERE catagory_id = " + catalogId;

            connection.Open();
            SqlCommand command = new SqlCommand(script, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                catagory.CatagoryId = catalogId;
                catagory.CatagoryName = reader["catagoryName"].ToString();
                catagory.CatagoryDescription = reader["catagotyDescription"].ToString();
            }
            connection.Close();

            return catagory;
        }

        public string RetriveCategorySubCatergories(Catagory catagory)
        {

            List<SubCategoryInfo> subCateroryList = new List<SubCategoryInfo>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string script = "SELECT * FROM subCategories WHERE catagory_id = " + catagory.CatagoryId;
            connection.Open();
            SqlCommand command = new SqlCommand(script, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SubCategoryInfo subCategory = new SubCategoryInfo();
                subCategory.Name = reader["subCatagoryName"].ToString();
                subCategory.ImageUrl = reader["subCategoryImageUrl"].ToString();
                subCategory.Description = reader["subCatagoryDescription"].ToString();
                subCateroryList.Add(subCategory);
            }
            connection.Close();

            var json = new JavaScriptSerializer().Serialize(subCateroryList);
            
            return json;
        }
    }
}