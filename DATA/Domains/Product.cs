using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
   public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public int ProductTypyId { get; set; }

    }
}
