using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WareHouse.UI.Areas.Admin.Models.DTO
{
    public class ProductDTO:BaseDTO
    {

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public short? UnitsInStock { get; set; }
        public decimal? UnitPrice { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}