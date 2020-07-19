using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DashBoard.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}