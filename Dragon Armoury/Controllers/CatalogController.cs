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
        public ActionResult Catalog(int catagoryId, int subCatagoryId = 0)
        {
            Catagory catagory = new Catagory();
            if (subCatagoryId == 0)
            {
                 catagory = RetriveCategoryInfo(catagoryId);
            }
            else
            {
                 catagory = RetriveSubCategoryInfo(catagoryId, subCatagoryId);
            }
            ViewBag.Catagory = catagoryId;
            ViewBag.SubCatagory = subCatagoryId;
            ViewBag.Title = catagory.CatagoryName;
            ViewBag.Message = catagory.CatagoryDescription;

            return View();
        }

        private Catagory RetriveSubCategoryInfo(int catagoryId, int subCatagoryId)
        {
            Catagory catagory = new Catagory();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            string script = "SELECT * FROM subCategories WHERE subCatagory_id = " + subCatagoryId;

            connection.Open();
            SqlCommand command = new SqlCommand(script, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                catagory.CatagoryId = catagoryId;
                catagory.CatagoryName = reader["subCatagoryName"].ToString();
                catagory.CatagoryDescription = reader["subCatagoryDescription"].ToString();
            }
            connection.Close();

            return catagory;
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
                subCategory.Id = reader["subCatagory_id"].ToString();
                subCateroryList.Add(subCategory);
            }
            connection.Close();

            var json = new JavaScriptSerializer().Serialize(subCateroryList);
            
            return json;
        }

        public string RetriveSubcategoryProducts(int subCatagoryId)
        {

            List<ProductInfo> productList = new List<ProductInfo>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string script = "Select * FROM Products WHERE subCategory_id = " + subCatagoryId;
            connection.Open();
            SqlCommand command = new SqlCommand(script, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ProductInfo product = new ProductInfo();
                product.Name = reader["name"].ToString();
                product.Description = reader["description"].ToString();
                product.Price = reader["price"].ToString();
                product.ProductId = reader["product_id"].ToString();
                product.StockNumber = reader["stockNumber"].ToString();
                product.PayPalLink = reader["payPallLink"].ToString();
                product.AlwayCustom = reader["alwaysCustom"].ToString();
                productList.Add(product);
            }
            connection.Close();

            var json = new JavaScriptSerializer().Serialize(productList);

            return json;
        }
    }
}