using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WareHouse.UI.Areas.Admin.Models.DTO
{
    public class CategoryDTO:BaseDTO
    {
        [Required (ErrorMessage ="Plase add category name..!")]
        public string CategoryName{ get; set; }
        [Required(ErrorMessage = "Plase add category description..!")]
        public string CategoryDescription{ get; set; }
    }

}