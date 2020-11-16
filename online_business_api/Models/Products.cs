using online_business_api.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace online_business_api.Models
{
    public class Products
    {

        public int Id { get; set; }


        public decimal price { get; set; }




        public string productDetailImageUrl { get; set; }



        public string productImageUrl { get; set; }

        public string productname { get; set; }



        public static List<Products> GetProductList()
        {
            DataTable dataTable = SqlHelper.ExecuteTable("select *  from  Products");
            List<Products> list = new List<Products>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                list.Add(ToModel(dataTable.Rows[i]));
            }
            return list;
        }

        private static Products ToModel(DataRow dr)
        {
            Products products = new Products();
            products.Id = (int)dr["Id"];
            products.price = (decimal)dr["price"];
            products.productDetailImageUrl = dr["productDetailImageUrl"].ToString();
            products.productImageUrl = dr["productImageUrl"].ToString();
            products.productname = dr["productname"].ToString();
            return products;
        }

    }
}
