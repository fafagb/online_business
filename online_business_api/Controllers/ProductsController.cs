using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_business_api.Models;

namespace online_business_api.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public List<Products> GetProducts()
        {
            
            //返回到前端，前端会自动转换成json数组
            return Products.GetProductList();
        }
    }
}
