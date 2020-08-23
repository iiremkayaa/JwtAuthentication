using Project.JwtProject.Business.Interfaces;
using Project.JwtProject.DataAccess.Interfaces;
using Project.JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Business.Concrete
{
    public class ProductManager : GenericManager<Product>,IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IGenericDal<Product> genericDal,IProductDal productDal) : base(genericDal)
        {
            _productDal = productDal;

        }
    }
}
