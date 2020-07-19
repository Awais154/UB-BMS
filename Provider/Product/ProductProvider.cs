using DATA.DBFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Product
{
    public class ProductProvider
    {
        public List<DATA.Domains.ProductType> GetProductType()
        {
            using (UbDbcontext context = new UbDbcontext())
            {
                return context.ProductType.ToList();
            }
        }

        public void AddProduct(DATA.Domains.Product product)
        {
            using(UbDbcontext context= new UbDbcontext())
            {
                context.Product.Add(product);
                context.SaveChanges();
            }
        }
    }
}
